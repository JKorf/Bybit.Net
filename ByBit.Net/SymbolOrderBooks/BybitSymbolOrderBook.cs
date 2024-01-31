using System;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.OrderBook;
using Microsoft.Extensions.Logging;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Clients;
using System.Threading;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Objects.Sockets;

namespace Bybit.Net.SymbolOrderBooks
{
    /// <summary>
    /// Live order book implementation
    /// </summary>
    public class BybitSymbolOrderBook : SymbolOrderBook
    {
        private readonly IBybitSocketClient _socketClient;
        private readonly bool _clientOwner;
        private readonly TimeSpan _initialDataTimeout;
        private readonly Category _category;
        private readonly int _depth;

        /// <summary>
        /// Create a new order book instance
        /// </summary>
        /// <param name="symbol">The symbol the order book is for</param>
        /// <param name="category">The category</param>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BybitSymbolOrderBook(string symbol, Category category, Action<BybitOrderBookOptions>? optionsDelegate = null)
            : this(symbol, category, optionsDelegate, null, null)
        {
        }

        /// <summary>
        /// Create a new order book instance
        /// </summary>
        /// <param name="symbol">The symbol the order book is for</param>
        /// <param name="category">The category</param>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        /// <param name="logger">Logger</param>
        /// <param name="socketClient">Socket client instance</param>
        public BybitSymbolOrderBook(string symbol,
            Category category,
            Action<BybitOrderBookOptions>? optionsDelegate,
            ILogger<BybitSymbolOrderBook>? logger,
            IBybitSocketClient? socketClient) : base(logger, "Bybit", symbol)
        {
            var options = BybitOrderBookOptions.Default.Copy();
            if (optionsDelegate != null)
                optionsDelegate(options);
            Initialize(options);

            _clientOwner = socketClient == null;
            _socketClient = socketClient ?? new BybitSocketClient();
            _category = category;
            _depth = options.Limit ?? GetDefaultLimit(category);
            _initialDataTimeout = options?.InitialDataTimeout ?? TimeSpan.FromSeconds(30);

            _sequencesAreConsecutive = true;
        }

        /// <inheritdoc />
        protected override async Task<CallResult<UpdateSubscription>> DoStartAsync(CancellationToken ct)
        {
            CallResult<UpdateSubscription> result;
            if (_category == Category.Spot)
                result = await _socketClient.V5SpotApi.SubscribeToOrderbookUpdatesAsync(Symbol, _depth, ProcessUpdate).ConfigureAwait(false);
            else if (_category == Category.Option)
                result = await _socketClient.V5OptionsApi.SubscribeToOrderbookUpdatesAsync(Symbol, _depth, ProcessUpdate).ConfigureAwait(false);
            else
                result = await _socketClient.V5LinearApi.SubscribeToOrderbookUpdatesAsync(Symbol, _depth, ProcessUpdate).ConfigureAwait(false);

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

        private void ProcessUpdate(DataEvent<BybitOrderbook> data)
        {
            if (data.UpdateType == SocketUpdateType.Snapshot)
                SetInitialOrderBook(data.Data.UpdateId, data.Data.Bids, data.Data.Asks);
            else
                UpdateOrderBook(data.Data.UpdateId, data.Data.Bids, data.Data.Asks);
        }

        /// <inheritdoc />
        protected override async Task<CallResult<bool>> DoResyncAsync(CancellationToken ct)
        {
            return await WaitForSetOrderBookAsync(_initialDataTimeout, ct).ConfigureAwait(false);
        }

        private int GetDefaultLimit(Category category)
            => category switch
            {
                Category.Spot => 50,
                Category.Option => 100,
                _ => 50
            };

        /// <summary>
        /// Dispose
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (_clientOwner)
                _socketClient?.Dispose();

            base.Dispose(disposing);
        }
    }
}
