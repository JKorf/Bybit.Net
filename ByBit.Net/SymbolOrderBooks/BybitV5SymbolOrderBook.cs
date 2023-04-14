using System;
using System.Threading.Tasks;
using Bybit.Net.Objects;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.OrderBook;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Clients;
using Bybit.Net.Objects.Models.Socket.Spot;
using System.Threading;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;

namespace Bybit.Net.SymbolOrderBooks
{
    /// <summary>
    /// Live order book implementation
    /// </summary>
    public class BybitV5SymbolOrderBook : SymbolOrderBook
    {
        private readonly IBybitSocketClient socketClient;
        private readonly bool _socketOwner;
        private readonly TimeSpan _initialDataTimeout;
        private readonly Category _category;
        private readonly int _depth;

        /// <summary>
        /// Create a new order book instance
        /// </summary>
        /// <param name="symbol">The symbol the order book is for</param>
        /// <param name="category">Category</param>
        /// <param name="depth">Book depth</param>
        /// <param name="options">Options for the order book</param>
        public BybitV5SymbolOrderBook(string symbol, Category category, int depth, BybitSymbolOrderBookOptions? options = null) : base("Bybit", symbol, options ?? new BybitSymbolOrderBookOptions())
        {
            socketClient = options?.SocketClient ?? new BybitSocketClient(new BybitSocketClientOptions
            {
                LogLevel = options?.LogLevel ?? LogLevel.Information
            });
            _socketOwner = options?.SocketClient == null;
            _category = category;
            _depth = depth;
            _initialDataTimeout = options?.InitialDataTimeout ?? TimeSpan.FromSeconds(30);

            sequencesAreConsecutive = true;
        }

        /// <inheritdoc />
        protected override async Task<CallResult<UpdateSubscription>> DoStartAsync(CancellationToken ct)
        {
            CallResult<UpdateSubscription> result;
            if (_category == Category.Spot)
                result = await socketClient.V5SpotStreams.SubscribeToOrderbookUpdatesAsync(Symbol, _depth, ProcessSnapshotUpdate, ProcessPartialUpdate).ConfigureAwait(false);
            else if(_category == Category.Option)
                result = await socketClient.V5OptionsStreams.SubscribeToOrderbookUpdatesAsync(Symbol, _depth, ProcessSnapshotUpdate, ProcessPartialUpdate).ConfigureAwait(false);
            else
                result = await socketClient.V5LinearStreams.SubscribeToOrderbookUpdatesAsync(Symbol, _depth, ProcessSnapshotUpdate, ProcessPartialUpdate).ConfigureAwait(false);

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

        private void ProcessSnapshotUpdate(DataEvent<BybitOrderbook> data)
        {
            SetInitialOrderBook(data.Data.UpdateId, data.Data.Bids, data.Data.Asks);
        }

        private void ProcessPartialUpdate(DataEvent<BybitOrderbook> data)
        {
            UpdateOrderBook(data.Data.UpdateId, data.Data.Bids, data.Data.Asks);          
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
