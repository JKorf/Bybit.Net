using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bybit.Net.Objects.Models.Socket;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.OrderBook;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Clients;
using System.Threading;

namespace Bybit.Net.SymbolOrderBooks
{
    /// <summary>
    /// Live order book implementation
    /// </summary>
    public class BybitUsdPerpetualSymbolOrderBook : SymbolOrderBook
    {
        private readonly IBybitSocketClient socketClient;
        private readonly bool _socketOwner;
        private readonly TimeSpan _initialDataTimeout;

        /// <summary>
        /// Create a new order book instance
        /// </summary>
        /// <param name="symbol">The symbol the order book is for</param>
        /// <param name="options">Options for the order book</param>
        public BybitUsdPerpetualSymbolOrderBook(string symbol, BybitSymbolOrderBookOptions? options = null) : base("Bybit", symbol, options ?? new BybitSymbolOrderBookOptions())
        {
            socketClient = options?.SocketClient ?? new BybitSocketClient(new BybitSocketClientOptions
            {
                LogLevel = options?.LogLevel ?? LogLevel.Information
            });
            _socketOwner = options?.SocketClient == null;
            _initialDataTimeout = options?.InitialDataTimeout ?? TimeSpan.FromSeconds(30);

            Levels = options?.Limit ?? 25;
        }

        /// <inheritdoc />
        protected override async Task<CallResult<UpdateSubscription>> DoStartAsync(CancellationToken ct)
        {
            var result = await socketClient.UsdPerpetualStreams.SubscribeToOrderBookUpdatesAsync(Symbol, Levels!.Value, ProcessSnapshot, ProcessUpdate).ConfigureAwait(false);
            if (!result)
                return result;

            if (ct.IsCancellationRequested)
            {
                await result.Data.CloseAsync().ConfigureAwait(false);
                return result.AsError<UpdateSubscription>(new CancellationRequestedError());
            }

            Status = OrderBookStatus.Syncing;
            
            var setResult = await WaitForSetOrderBookAsync(_initialDataTimeout, ct).ConfigureAwait(false);
            return setResult ? result : new CallResult<UpdateSubscription>(setResult.Error!);
        }

        /// <inheritdoc />
        protected override void DoReset()
        {
        }

        private void ProcessSnapshot(DataEvent<IEnumerable<BybitOrderBookEntry>> snapshot)
        {
            var askEntries = snapshot.Data.Where(e => e.Side == Bybit.Net.Enums.OrderSide.Sell).ToList();
            var bidEntries = snapshot.Data.Where(e => e.Side == Bybit.Net.Enums.OrderSide.Buy).ToList();
            SetInitialOrderBook(DateTime.UtcNow.Ticks, bidEntries, askEntries);
        }

        private void ProcessUpdate(DataEvent<BybitDeltaUpdate<BybitOrderBookEntry>> data)
        {            
            var bidEntries = new List<BybitOrderBookEntry>();
            var askEntries = new List<BybitOrderBookEntry>();

            foreach(var item in data.Data.Insert)
            {
                if (item.Side == Bybit.Net.Enums.OrderSide.Buy)
                    bidEntries.Add(item);
                else
                    askEntries.Add(item);
            }

            foreach (var item in data.Data.Update)
            {
                if (item.Side == Bybit.Net.Enums.OrderSide.Buy)
                    bidEntries.Add(item);
                else
                    askEntries.Add(item);
            }

            foreach (var item in data.Data.Delete)
            {
                item.Quantity = 0;
                if (item.Side == Bybit.Net.Enums.OrderSide.Buy)
                    bidEntries.Add(item);
                else
                    askEntries.Add(item);
            }

            UpdateOrderBook(DateTime.UtcNow.Ticks, bidEntries, askEntries);            
        }

        /// <inheritdoc />
        protected override async Task<CallResult<bool>> DoResyncAsync(CancellationToken ct)
        {
            return await WaitForSetOrderBookAsync(_initialDataTimeout, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (_socketOwner)
                socketClient?.Dispose();

            base.Dispose(disposing);
        }
    }
}
