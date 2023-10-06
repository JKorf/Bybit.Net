using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Bybit.Net.Interfaces.Clients.V5;
using Microsoft.Extensions.Logging;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.CommonObjects;
using System.Linq;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitRestClientApi"/>
    public class BybitRestClientApi : RestApiClient, IBybitRestClientApi, ISpotClient
    {
        internal TimeSyncState _timeSyncState = new TimeSyncState("Bybit V5 API");

        /// <inheritdoc />
        public event Action<OrderId>? OnOrderPlaced;
        /// <inheritdoc />
        public event Action<OrderId>? OnOrderCanceled;

        /// <inheritdoc />
        public ISpotClient CommonSpotClient => this;

        /// <summary>
        /// Options
        /// </summary>
        public new BybitRestOptions ClientOptions => (BybitRestOptions)base.ClientOptions;

        /// <inheritdoc />
        public BybitRestClientApiAccount Account { get; }
        /// <inheritdoc />
        public BybitRestClientApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public BybitRestClientApiTrading Trading { get; }

        /// <inheritdoc />
        public string ExchangeName => "Bybit";

        #region ctor
        internal BybitRestClientApi(ILogger logger, HttpClient? httpClient, BybitRestOptions options) :
            base(logger, httpClient, options.Environment.RestBaseAddress, options, options.V5Options)
        {
            if (!string.IsNullOrEmpty(options.Referer))
            {
                StandardRequestHeaders = new Dictionary<string, string>
                {
                    { "x-referer", options.Referer! }
                };
            }

            manualParseError = true;

            Account = new BybitRestClientApiAccount(this);
            ExchangeData = new BybitRestClientApiExchangeData(this);
            Trading = new BybitRestClientApiTrading(this);

            requestBodyFormat = RequestBodyFormat.Json;
            ParameterPositions[HttpMethod.Delete] = HttpMethodParameterPosition.InUri;
        }
        #endregion

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

        /// <summary>
        /// Get url for an endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        internal Uri GetUrl(string endpoint)
        {
            return new Uri(BaseAddress.AppendPath(endpoint));
        }

        /// <inheritdoc />
        protected override async Task<WebCallResult<DateTime>> GetServerTimestampAsync()
        {
            var time = await ExchangeData.GetServerTimeAsync().ConfigureAwait(false);
            if (!time)
                return time.As<DateTime>(default);

            return time.As(time.Data.TimeNano);
        }

        /// <inheritdoc />
        public override TimeSyncInfo? GetTimeSyncInfo()
            => new TimeSyncInfo(_logger, (ApiOptions.AutoTimestamp ?? ClientOptions.AutoTimestamp), (ApiOptions.TimestampRecalculationInterval ?? ClientOptions.TimestampRecalculationInterval), _timeSyncState);

        /// <inheritdoc />
        public override TimeSpan? GetTimeOffset()
            => _timeSyncState.TimeOffset;

        internal async Task<WebCallResult<BybitExtResult<T, U>>> SendRequestFullResponseAsync<T,U>(
             Uri uri,
             HttpMethod method,
             CancellationToken cancellationToken,
             Dictionary<string, object>? parameters = null,
             bool signed = false,
             JsonSerializer? deserializer = null)
        {
            return await base.SendRequestAsync<BybitExtResult<T, U>>(uri, method, cancellationToken, parameters, signed, deserializer: deserializer).ConfigureAwait(false);
        }

        internal async Task<WebCallResult<T>> SendRequestAsync<T>(
             Uri uri,
             HttpMethod method,
             CancellationToken cancellationToken,
             Dictionary<string, object>? parameters = null,
             bool signed = false,
             JsonSerializer? deserializer = null)
        {
            var result = await base.SendRequestAsync<BybitResult<T>>(uri, method, cancellationToken, parameters, signed, deserializer: deserializer).ConfigureAwait(false);
            if (!result)
                return result.As<T>(default);

            if (result.Data.ReturnCode != 0)
                return result.AsError<T>(new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));

            return result.As(result.Data.Result);
        }

        internal async Task<WebCallResult> SendRequestAsync(
             Uri uri,
             HttpMethod method,
             CancellationToken cancellationToken,
             Dictionary<string, object>? parameters = null,
             bool signed = false,
             JsonSerializer? deserializer = null)
        {
            var result = await base.SendRequestAsync<BybitResult<object>>(uri, method, cancellationToken, parameters, signed, deserializer: deserializer).ConfigureAwait(false);
            if (!result)
                return result.AsDataless();

            if (result.Data.ReturnCode != 0)
                return result.AsDatalessError(new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));

            return result.AsDataless();
        }

        internal void InvokeOrderPlaced(OrderId id)
        {
            OnOrderPlaced?.Invoke(id);
        }

        internal void InvokeOrderCanceled(OrderId id)
        {
            OnOrderCanceled?.Invoke(id);
        }

        async Task<WebCallResult<OrderId>> ISpotClient.PlaceOrderAsync(string symbol, CommonOrderSide side, CommonOrderType type, decimal quantity, decimal? price, string? accountId, string? clientOrderId, CancellationToken ct)
        {
            if (symbol == null)
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.PlaceOrderAsync), nameof(symbol));

            var result = await Trading.PlaceOrderAsync(
                Enums.Category.Spot,
                symbol,
                side == CommonOrderSide.Buy ? Enums.OrderSide.Buy : Enums.OrderSide.Sell,
                type == CommonOrderType.Limit ? Enums.NewOrderType.Limit : Enums.NewOrderType.Market,
                quantity,
                price,
                clientOrderId: clientOrderId).ConfigureAwait(false);

            if (!result)
                return result.As<OrderId>(default);

            return result.As(new OrderId
            {
                Id = result.Data.OrderId,
                SourceObject = result.Data
            });
        }
        
        /// <inheritdoc />
        public string GetSymbolName(string baseAsset, string quoteAsset) => baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();
        
        async Task<WebCallResult<IEnumerable<Symbol>>> IBaseRestClient.GetSymbolsAsync(CancellationToken ct)
        {
            var symbols = await ExchangeData.GetSpotSymbolsAsync().ConfigureAwait(false);
            if (!symbols)
                return symbols.As<IEnumerable<Symbol>>(default);

            return symbols.As(symbols.Data.List.Select(l => new Symbol
            {
                SourceObject = l,
                Name = l.Name,
                PriceStep = l.PriceFilter?.TickSize,
                MinTradeQuantity = l.LotSizeFilter?.MinOrderQuantity,
                QuantityStep = l.LotSizeFilter?.BasePrecision
            }));
        }

        async Task<WebCallResult<Ticker>> IBaseRestClient.GetTickerAsync(string symbol, CancellationToken ct)
        {
            if (symbol == null)
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetTickerAsync), nameof(symbol));

            var tickers = await ExchangeData.GetSpotTickersAsync(symbol).ConfigureAwait(false);
            if (!tickers)
                return tickers.As<Ticker>(default);

            var ticker = tickers.Data.Rows.Single();
            return tickers.As(new Ticker
            {
                HighPrice = ticker.HighPrice24h,
                LastPrice = ticker.LastPrice,
                LowPrice = ticker.LowPrice24h,
                Price24H = ticker.PreviousPrice24h,
                Symbol = symbol,
                Volume = ticker.Volume24h,
                SourceObject = ticker
            });
        }

        async Task<WebCallResult<IEnumerable<Ticker>>> IBaseRestClient.GetTickersAsync(CancellationToken ct)
        {
            var tickers = await ExchangeData.GetSpotTickersAsync().ConfigureAwait(false);
            if (!tickers)
                return tickers.As<IEnumerable<Ticker>>(default);

            return tickers.As(tickers.Data.Rows.Select(t => new Ticker
            {
                HighPrice = t.HighPrice24h,
                LastPrice = t.LastPrice,
                LowPrice = t.LowPrice24h,
                Price24H = t.PreviousPrice24h,
                Symbol = t.Symbol,
                Volume = t.Volume24h,
                SourceObject = t
            }));
        }

        async Task<WebCallResult<IEnumerable<Kline>>> IBaseRestClient.GetKlinesAsync(string symbol, TimeSpan timespan, DateTime? startTime, DateTime? endTime, int? limit, CancellationToken ct)
        {
            if (symbol == null)
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetKlinesAsync), nameof(symbol));

            var klineInterval = (Enums.KlineInterval)timespan.TotalSeconds;
            if (!Enum.IsDefined(typeof(Enums.KlineInterval), klineInterval))
                throw new ArgumentException("Unsupported timespan for Bybit Klines, check supported intervals using Bybit.Net.Enums.KlineInterval");

            var symbols = await ExchangeData.GetKlinesAsync(Enums.Category.Spot, symbol, klineInterval, startTime, endTime, limit).ConfigureAwait(false);
            if (!symbols)
                return symbols.As<IEnumerable<Kline>>(default);

            return symbols.As(symbols.Data.Rows.Select(t => new Kline
            {
                HighPrice = t.HighPrice,
                ClosePrice = t.ClosePrice,
                LowPrice = t.LowPrice,
                OpenPrice = t.OpenPrice,
                OpenTime = t.StartTime,
                Volume = t.Volume,
                SourceObject = t
            }));
        }

        async Task<WebCallResult<OrderBook>> IBaseRestClient.GetOrderBookAsync(string symbol, CancellationToken ct)
        {
            if (symbol == null)
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetOrderBookAsync), nameof(symbol));

            var book = await ExchangeData.GetOrderbookAsync(Enums.Category.Spot, symbol).ConfigureAwait(false);
            if (!book)
                return book.As<OrderBook>(default);

            return book.As(new OrderBook
            {
                Asks = book.Data.Asks.Select(a => new OrderBookEntry { Price = a.Price, Quantity = a.Quantity }),
                Bids = book.Data.Bids.Select(a => new OrderBookEntry { Price = a.Price, Quantity = a.Quantity }),
                SourceObject = book
            });
        }

        async Task<WebCallResult<IEnumerable<Trade>>> IBaseRestClient.GetRecentTradesAsync(string symbol, CancellationToken ct)
        {
            if (symbol == null)
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetRecentTradesAsync), nameof(symbol));

            var tickers = await ExchangeData.GetTradeHistoryAsync(Enums.Category.Spot, symbol).ConfigureAwait(false);
            if (!tickers)
                return tickers.As<IEnumerable<Trade>>(default);

            return tickers.As(tickers.Data.Rows.Select(t => new Trade
            {
                Quantity = t.Quantity,
                Price = t.Price,
                Timestamp = t.Timestamp,
                Symbol = t.Symbol,
                SourceObject = t
            }));
        }

        async Task<WebCallResult<IEnumerable<Balance>>> IBaseRestClient.GetBalancesAsync(string? accountId, CancellationToken ct)
        {
            var balances = await Account.GetAllAssetBalancesAsync(Enums.AccountType.Spot).ConfigureAwait(false);
            if (!balances)
                return balances.As<IEnumerable<Balance>>(default);

            return balances.As(balances.Data.Balances.Select(t => new Balance
            {
                Asset = t.Asset,
                Available = t.TransferBalance,
                Total = t.WalletBalance,
                SourceObject = t
            }));
        }

        async Task<WebCallResult<Order>> IBaseRestClient.GetOrderAsync(string orderId, string? symbol, CancellationToken ct)
        {
            if (orderId == null)
                throw new ArgumentException(nameof(orderId) + " required for Bybit " + nameof(ISpotClient.GetOrderAsync), nameof(orderId));

            if (symbol == null)
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetOrderAsync), nameof(symbol));

            var orders = await Trading.GetOrdersAsync(Enums.Category.Spot, symbol, orderId: orderId).ConfigureAwait(false);
            if (!orders)
                return orders.As<Order>(default);

            var order = orders.Data.List.Single();

            return orders.As(new Order
            {
                Id = orderId,
                Price = order.Price,
                Quantity = order.Quantity,
                QuantityFilled = order.QuantityFilled,
                Side = order.Side == Enums.OrderSide.Sell ? CommonOrderSide.Sell : CommonOrderSide.Buy,
                Symbol = order.Symbol,
                Timestamp = order.CreateTime,
                Type = order.OrderType == Enums.OrderType.Market ? CommonOrderType.Market : order.OrderType == Enums.OrderType.Limit ? CommonOrderType.Limit : CommonOrderType.Other,
                Status = order.Status == Enums.V5.OrderStatus.Cancelled ? CommonOrderStatus.Canceled :
                         order.Status == Enums.V5.OrderStatus.Filled ? CommonOrderStatus.Filled :
                         CommonOrderStatus.Active,
                SourceObject = order
            });
        }

        async Task<WebCallResult<IEnumerable<UserTrade>>> IBaseRestClient.GetOrderTradesAsync(string orderId, string? symbol, CancellationToken ct)
        {
            if (orderId == null)
                throw new ArgumentException(nameof(orderId) + " required for Bybit " + nameof(ISpotClient.GetOrderTradesAsync), nameof(orderId));

            if (symbol == null)
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetOrderTradesAsync), nameof(symbol));

            var trades = await Trading.GetUserTradesAsync(Enums.Category.Spot, symbol, orderId: orderId).ConfigureAwait(false);
            if (!trades)
                return trades.As<IEnumerable<UserTrade>>(default);

            return trades.As(trades.Data.List.Select(t => new UserTrade
            {
                Price = t.Price,
                Quantity = t.Quantity,
                Symbol = t.Symbol,
                Timestamp = t.Timestamp,
                SourceObject = t
            }));
        }

        async Task<WebCallResult<IEnumerable<Order>>> IBaseRestClient.GetOpenOrdersAsync(string? symbol, CancellationToken ct)
        {
            if (symbol == null)
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetOpenOrdersAsync), nameof(symbol));

            var orders = await Trading.GetOrdersAsync(Enums.Category.Spot, symbol).ConfigureAwait(false);
            if (!orders)
                return orders.As<IEnumerable<Order>>(default);

            return orders.As(orders.Data.List.Select(o => new Order
            {
                Id = o.OrderId,
                Price = o.Price,
                Quantity = o.Quantity,
                QuantityFilled = o.QuantityFilled,
                Side = o.Side == Enums.OrderSide.Sell ? CommonOrderSide.Sell : CommonOrderSide.Buy,
                Symbol = o.Symbol,
                Timestamp = o.CreateTime,
                Type = o.OrderType == Enums.OrderType.Market ? CommonOrderType.Market : o.OrderType == Enums.OrderType.Limit ? CommonOrderType.Limit : CommonOrderType.Other,
                Status = o.Status == Enums.V5.OrderStatus.Cancelled ? CommonOrderStatus.Canceled :
                         o.Status == Enums.V5.OrderStatus.Filled ? CommonOrderStatus.Filled :
                         CommonOrderStatus.Active,
                SourceObject = o
            }));
        }

        async Task<WebCallResult<IEnumerable<Order>>> IBaseRestClient.GetClosedOrdersAsync(string? symbol, CancellationToken ct)
        {
            if (symbol == null)
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetClosedOrdersAsync), nameof(symbol));

            var orders = await Trading.GetOrderHistoryAsync(Enums.Category.Spot, symbol).ConfigureAwait(false);
            if (!orders)
                return orders.As<IEnumerable<Order>>(default);

            return orders.As(orders.Data.List.Select(o => new Order
            {
                Id = o.OrderId,
                Price = o.Price,
                Quantity = o.Quantity,
                QuantityFilled = o.QuantityFilled,
                Side = o.Side == Enums.OrderSide.Sell ? CommonOrderSide.Sell : CommonOrderSide.Buy,
                Symbol = o.Symbol,
                Timestamp = o.CreateTime,
                Type = o.OrderType == Enums.OrderType.Market ? CommonOrderType.Market : o.OrderType == Enums.OrderType.Limit ? CommonOrderType.Limit : CommonOrderType.Other,
                Status = o.Status == Enums.V5.OrderStatus.Cancelled ? CommonOrderStatus.Canceled :
                         o.Status == Enums.V5.OrderStatus.Filled ? CommonOrderStatus.Filled :
                         CommonOrderStatus.Active,
                SourceObject = o
            }));
        }

        async Task<WebCallResult<OrderId>> IBaseRestClient.CancelOrderAsync(string orderId, string? symbol, CancellationToken ct)
        {
            if (orderId == null)
                throw new ArgumentException(nameof(orderId) + " required for Bybit " + nameof(ISpotClient.CancelOrderAsync), nameof(orderId));

            if (symbol == null)
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.CancelOrderAsync), nameof(symbol));

            var orders = await Trading.CancelOrderAsync(Enums.Category.Spot, symbol, orderId).ConfigureAwait(false);
            if (!orders)
                return orders.As<OrderId>(default);

            return orders.As(new OrderId
            {
                Id = orderId,
                SourceObject = orders.Data
            });
        }
    }
}
