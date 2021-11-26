using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bybit.Net.Clients.Socket;
using Bybit.Net.Objects.Models.Socket;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.OrderBook;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace Bitfinex.Net.SymbolOrderBooks
{
    /// <summary>
    /// Live order book implementation
    /// </summary>
    public class BybitCoinFuturesSymbolOrderBook: SymbolOrderBook
    {
        private readonly BybitSocketClientCoinFutures socketClient;
        private readonly bool _socketOwner;

        /// <summary>
        /// Create a new order book instance
        /// </summary>
        /// <param name="symbol">The symbol the order book is for</param>
        /// <param name="limit">The limit of entries in the order book, either 25 or 200</param>
        /// <param name="options">Options for the order book</param>
        public BybitCoinFuturesSymbolOrderBook(string symbol, int limit, BybitFuturesSymbolOrderBookOptions? options = null) : base("Bybit[Futures]", symbol, options ?? new BybitFuturesSymbolOrderBookOptions())
        {
            socketClient = options?.SocketClient ?? new BybitSocketClientCoinFutures(new BybitSocketClientFuturesOptions
            {
                LogLevel = options?.LogLevel ?? LogLevel.Information
            });
            _socketOwner = options?.SocketClient == null;

            Levels = limit;
        }

        /// <inheritdoc />
        protected override async Task<CallResult<UpdateSubscription>> DoStartAsync()
        {
            var result = await socketClient.SubscribeToOrderBookUpdatesAsync(Symbol, Levels!.Value, ProcessSnapshot, ProcessUpdate).ConfigureAwait(false);
            if (!result)
                return result;

            Status = OrderBookStatus.Syncing;
            
            var setResult = await WaitForSetOrderBookAsync(30000).ConfigureAwait(false);
            return setResult ? result : new CallResult<UpdateSubscription>(null, setResult.Error);
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
        protected override async Task<CallResult<bool>> DoResyncAsync()
        {
            return await WaitForSetOrderBookAsync(30000).ConfigureAwait(false);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public override void Dispose()
        {
            processBuffer.Clear();
            asks.Clear();
            bids.Clear();

            if(_socketOwner)
                socketClient?.Dispose();
        }
    }
}
