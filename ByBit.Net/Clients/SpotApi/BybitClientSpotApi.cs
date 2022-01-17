using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.SpotApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.SpotApi
{
    /// <inheritdoc cref="IBybitClientSpotApi" />
    public class BybitClientSpotApi : RestApiClient, IBybitClientSpotApi, ISpotClient
    {
        private readonly BybitClient _baseClient;
        private readonly BybitClientOptions _options;
        private readonly Log _log;

        internal static TimeSyncState TimeSyncState = new TimeSyncState();

        /// <inheritdoc />
        public event Action<OrderId>? OnOrderPlaced;
        /// <inheritdoc />
        public event Action<OrderId>? OnOrderCanceled;

        internal BybitClientOptions ClientOptions { get; }

        /// <inheritdoc />
        public string ExchangeName => "Bybit";

        /// <inheritdoc />
        public IBybitClientSpotApiAccount Account { get; }
        /// <inheritdoc />
        public IBybitClientSpotApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBybitClientSpotApiTrading Trading { get; }

        #region ctor
        internal BybitClientSpotApi(Log log, BybitClient baseClient, BybitClientOptions options)
            : base(options, options.SpotApiOptions)
        {
            _baseClient = baseClient;
            _log = log;
            _options = options;
            ClientOptions = options;

            Account = new BybitClientSpotApiAccount(this);
            ExchangeData = new BybitClientSpotApiExchangeData(this);
            Trading = new BybitClientSpotApiTrading(this);
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

        internal async Task<WebCallResult<BybitResult<T>>> SendRequestWrapperAsync<T>(
             Uri uri,
             HttpMethod method,
             CancellationToken cancellationToken,
             Dictionary<string, object>? parameters = null,
             bool signed = false,
             JsonSerializer? deserializer = null) where T : class
        {
            var result = await _baseClient.SendRequestInternal<BybitResult<T>>(this, uri, method, cancellationToken, parameters, signed, deserializer: deserializer).ConfigureAwait(false);
            if (!result)
                return result.As<BybitResult<T>>(default);

            if (result.Data.ReturnCode != 0)
                return result.AsError<BybitResult<T>>(new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));               

            return result.As(result.Data);
        }

        internal async Task<WebCallResult<T>> SendRequestAsync<T>(
             Uri uri,
             HttpMethod method,
             CancellationToken cancellationToken,
             Dictionary<string, object>? parameters = null,
             bool signed = false,
             JsonSerializer? deserializer = null)
        {
            var result = await _baseClient.SendRequestInternal<BybitResult<T>>(this, uri, method, cancellationToken, parameters, signed, deserializer: deserializer).ConfigureAwait(false);
            if (!result)
                return result.As<T>(default);

            if (result.Data.ReturnCode != 0)
                return result.AsError<T>(new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));
                
            return result.As(result.Data.Result);
        }

        #region Common interface
        /// <inheritdoc />
        public string GetSymbolName(string baseAsset, string quoteAsset)
        {
            return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();
        }

#pragma warning disable 1066
        async Task<WebCallResult<IEnumerable<Symbol>>> IBaseRestClient.GetSymbolsAsync()
        {
            var result = await ExchangeData.GetSymbolsAsync().ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Symbol>>(null);

            return result.As(result.Data.Select(r => new Symbol
            {
                SourceObject = r,
                Name = r.Name,
                MinTradeQuantity = r.MinOrderQuantity,
                PriceStep = r.PricePrecision,
                QuantityStep = r.BasePrecision
            }));
        }

        async Task<WebCallResult<IEnumerable<Ticker>>> IBaseRestClient.GetTickersAsync()
        {
            var result = await ExchangeData.GetTickersAsync().ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Ticker>>(null);

            return result.As(result.Data.Select(r => new Ticker
            {
                SourceObject = r,
                Symbol = r.Symbol,
                HighPrice = r.HighPrice,
                LastPrice = r.LastPrice,
                LowPrice = r.LowPrice,
                Price24H = r.OpenPrice,
                Volume = r.Volume
            }));
        }

        async Task<WebCallResult<Ticker>> IBaseRestClient.GetTickerAsync(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetTickerAsync), nameof(symbol));

            var result = await ExchangeData.GetTickerAsync(symbol).ConfigureAwait(false);
            if (!result)
                return result.As<Ticker>(null);

            return result.As(new Ticker
            {
                SourceObject = result.Data,
                Symbol = result.Data.Symbol,
                HighPrice = result.Data.HighPrice,
                LastPrice = result.Data.LastPrice,
                LowPrice = result.Data.LowPrice,
                Price24H = result.Data.OpenPrice,
                Volume = result.Data.Volume
            });
        }

        async Task<WebCallResult<IEnumerable<Kline>>> IBaseRestClient.GetKlinesAsync(string symbol, TimeSpan timespan, DateTime? startTime = null, DateTime? endTime = null, int? limit = null)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetKlinesAsync), nameof(symbol));

            var result = await ExchangeData.GetKlinesAsync(symbol, TimeSpanToInterval(timespan), startTime, endTime, limit).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Kline>>(null);

            return result.As(result.Data.Select(r => new Kline
            {
                SourceObject = r,
                HighPrice = r.HighPrice,
                LowPrice = r.LowPrice,
                Volume = r.Volume,
                ClosePrice = r.ClosePrice,
                OpenPrice = r.OpenPrice,
                OpenTime = r.OpenTime
            }));
        }

        async Task<WebCallResult<OrderBook>> IBaseRestClient.GetOrderBookAsync(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetOrderBookAsync), nameof(symbol));

            var result = await ExchangeData.GetOrderBookAsync(symbol).ConfigureAwait(false);
            if (!result)
                return result.As<OrderBook>(null);

            return result.As(new OrderBook
            {
                SourceObject = result.Data,
                Asks = result.Data.Asks.Select(a => new OrderBookEntry { Price = a.Price, Quantity = a.Quantity }),
                Bids = result.Data.Bids.Select(b => new OrderBookEntry { Price = b.Price, Quantity = b.Quantity })
            });
        }

        async Task<WebCallResult<IEnumerable<Trade>>> IBaseRestClient.GetRecentTradesAsync(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.GetRecentTradesAsync), nameof(symbol));

            var result = await ExchangeData.GetTradeHistoryAsync(symbol).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Trade>>(null);

            return result.As(result.Data.Select(r => new Trade
            {
                SourceObject = r,
                Price = r.Price,
                Quantity = r.Quantity,
                Symbol = symbol,
                Timestamp = r.TradeTime
            }));
        }

        async Task<WebCallResult<OrderId>> ISpotClient.PlaceOrderAsync(string symbol, CryptoExchange.Net.CommonObjects.OrderSide side, CryptoExchange.Net.CommonObjects.OrderType type, decimal quantity, decimal? price = null, string? accountId = null)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentException(nameof(symbol) + " required for Bybit " + nameof(ISpotClient.PlaceOrderAsync), nameof(symbol));

            var result = await Trading.PlaceOrderAsync(
                symbol,
                side == CryptoExchange.Net.CommonObjects.OrderSide.Buy ? Enums.OrderSide.Buy : Enums.OrderSide.Sell,
                type == CryptoExchange.Net.CommonObjects.OrderType.Limit ? Enums.OrderType.Limit : Enums.OrderType.Market,
                quantity,
                price,
                type == CryptoExchange.Net.CommonObjects.OrderType.Limit ? TimeInForce.GoodTillCanceled : (TimeInForce?)null
                ).ConfigureAwait(false);
            if (!result)
                return result.As<OrderId>(null);

            return result.As(new OrderId
            {
                SourceObject = result.Data,
                Id = result.Data.Id.ToString(CultureInfo.InvariantCulture)
            });
        }

        async Task<WebCallResult<Order>> IBaseRestClient.GetOrderAsync(string orderId, string? symbol = null)
        {
            if (!long.TryParse(orderId, out var id))
                throw new ArgumentException($"Invalid order id for Bybit {nameof(ISpotClient.GetOrderAsync)}", nameof(orderId));

            var result = await Trading.GetOrderAsync(id).ConfigureAwait(false);
            if (!result)
                return result.As<Order>(null);

            return result.As(new Order
            {
                SourceObject = result.Data,
                Id = result.Data.Id.ToString(CultureInfo.InvariantCulture),
                Price = result.Data.Price,
                Quantity = result.Data.Quantity,
                QuantityFilled = result.Data.QuantityFilled,
                Timestamp = result.Data.CreateTime,
                Symbol = result.Data.Symbol,
                Side = result.Data.Side == Enums.OrderSide.Buy ? CryptoExchange.Net.CommonObjects.OrderSide.Buy : CryptoExchange.Net.CommonObjects.OrderSide.Sell,
                Type = result.Data.Type == Enums.OrderType.Limit ? CryptoExchange.Net.CommonObjects.OrderType.Limit : result.Data.Type == Enums.OrderType.Market ? CryptoExchange.Net.CommonObjects.OrderType.Market : CryptoExchange.Net.CommonObjects.OrderType.Other,
                Status = result.Data.Status == Enums.OrderStatus.Canceled ? CryptoExchange.Net.CommonObjects.OrderStatus.Canceled : result.Data.Status == Enums.OrderStatus.Filled ? CryptoExchange.Net.CommonObjects.OrderStatus.Filled : CryptoExchange.Net.CommonObjects.OrderStatus.Active
            });
        }

        async Task<WebCallResult<IEnumerable<UserTrade>>> IBaseRestClient.GetOrderTradesAsync(string orderId, string? symbol = null)
        {
            if (!long.TryParse(orderId, out var id))
                throw new ArgumentException($"Invalid order id for Bybit {nameof(ISpotClient.GetOrderAsync)}", nameof(orderId));

            var result = await Trading.GetUserTradesAsync(fromId: id, toId: long.Parse(orderId)).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<UserTrade>>(null);

            return result.As(result.Data.Select(r => new UserTrade
            {
                SourceObject = r,
                Id = r.Id.ToString(CultureInfo.InvariantCulture),
                OrderId = r.OrderId.ToString(CultureInfo.InvariantCulture),
                Symbol = r.Symbol,
                Fee = r.Fee,
                FeeAsset = r.FeeAsset,
                Price = r.Price,
                Quantity = r.Quantity,
                Timestamp = r.TradeTime
            }));
        }

        async Task<WebCallResult<IEnumerable<Order>>> IBaseRestClient.GetOpenOrdersAsync(string? symbol = null)
        {
            var result = await Trading.GetOpenOrdersAsync(symbol).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Order>>(null);

            return result.As(result.Data.Select(r => new Order
            {
                SourceObject = r,
                Id = r.Id.ToString(CultureInfo.InvariantCulture),
                Price = r.Price,
                Quantity = r.Quantity,
                QuantityFilled = r.QuantityFilled,
                Timestamp = r.CreateTime,
                Symbol = r.Symbol,
                Side = r.Side == Enums.OrderSide.Buy ? CryptoExchange.Net.CommonObjects.OrderSide.Buy : CryptoExchange.Net.CommonObjects.OrderSide.Sell,
                Type = r.Type == Enums.OrderType.Limit ? CryptoExchange.Net.CommonObjects.OrderType.Limit: r.Type == Enums.OrderType.Market ? CryptoExchange.Net.CommonObjects.OrderType.Market: CryptoExchange.Net.CommonObjects.OrderType.Other,
                Status = r.Status == Enums.OrderStatus.Canceled ? CryptoExchange.Net.CommonObjects.OrderStatus.Canceled: r.Status == Enums.OrderStatus.Filled ? CryptoExchange.Net.CommonObjects.OrderStatus.Filled: CryptoExchange.Net.CommonObjects.OrderStatus.Active
            }));
        }

        async Task<WebCallResult<IEnumerable<Order>>> IBaseRestClient.GetClosedOrdersAsync(string? symbol = null)
        {
            var result = await Trading.GetOrdersAsync(symbol).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Order>>(null);

            return result.As(result.Data.Select(r => new Order
            {
                SourceObject = r,
                Id = r.Id.ToString(CultureInfo.InvariantCulture),
                Price = r.Price,
                Quantity = r.Quantity,
                QuantityFilled = r.QuantityFilled,
                Timestamp = r.CreateTime,
                Symbol = r.Symbol,
                Side = r.Side == Enums.OrderSide.Buy ? CryptoExchange.Net.CommonObjects.OrderSide.Buy : CryptoExchange.Net.CommonObjects.OrderSide.Sell,
                Type = r.Type == Enums.OrderType.Limit ? CryptoExchange.Net.CommonObjects.OrderType.Limit : r.Type == Enums.OrderType.Market ? CryptoExchange.Net.CommonObjects.OrderType.Market : CryptoExchange.Net.CommonObjects.OrderType.Other,
                Status = r.Status == Enums.OrderStatus.Canceled ? CryptoExchange.Net.CommonObjects.OrderStatus.Canceled : r.Status == Enums.OrderStatus.Filled ? CryptoExchange.Net.CommonObjects.OrderStatus.Filled : CryptoExchange.Net.CommonObjects.OrderStatus.Active
            }));
        }

        async Task<WebCallResult<OrderId>> IBaseRestClient.CancelOrderAsync(string orderId, string? symbol = null)
        {
            if (!long.TryParse(orderId, out var id))
                throw new ArgumentException($"Invalid order id for Bybit {nameof(ISpotClient.GetOrderAsync)}", nameof(orderId));

            var result = await Trading.CancelOrderAsync(id).ConfigureAwait(false);
            if (!result)
                return result.As<OrderId>(null);

            return result.As(new OrderId { SourceObject = result.Data, Id = result.Data.Id.ToString(CultureInfo.InvariantCulture) });
        }

        async Task<WebCallResult<IEnumerable<Balance>>> IBaseRestClient.GetBalancesAsync(string? accountId = null)
        {
            var result = await Account.GetBalancesAsync().ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<Balance>>(null);

            return result.As(result.Data.Select(r => new Balance
            {
                SourceObject = r,
                Asset = r.Asset,
                Available = r.Available,
                Total = r.Total
            }));
        }
#pragma warning restore

        private static KlineInterval TimeSpanToInterval(TimeSpan timeSpan)
        {
            if (timeSpan.TotalMinutes == 1)
                return KlineInterval.OneMinute;
            if (timeSpan.TotalMinutes == 3)
                return KlineInterval.ThreeMinutes;
            if (timeSpan.TotalMinutes == 5)
                return KlineInterval.FiveMinutes;
            if (timeSpan.TotalMinutes == 15)
                return KlineInterval.FifteenMinutes;
            if (timeSpan.TotalMinutes == 30)
                return KlineInterval.ThirtyMinutes;
            if (timeSpan.TotalMinutes == 60)
                return KlineInterval.OneHour;
            if (timeSpan.TotalMinutes == 120)
                return KlineInterval.TwoHours;
            if (timeSpan.TotalMinutes == 240)
                return KlineInterval.FourHours;
            if (timeSpan.TotalMinutes == 360)
                return KlineInterval.SixHours;
            if (timeSpan.TotalMinutes == 720)
                return KlineInterval.TwelveHours;
            if (timeSpan.TotalMinutes == 1440)
                return KlineInterval.OneDay;
            if (timeSpan.TotalDays == 7)
                return KlineInterval.OneWeek;
            if (timeSpan.TotalDays == 30
             || timeSpan.TotalDays == 31)
                return KlineInterval.OneMonth;

            throw new ArgumentException("Unsupported timespan for Bybit Klines, check supported intervals using Bybit.Net.Enums.KlineInterval");
        }

        internal void InvokeOrderPlaced(OrderId id)
        {
            OnOrderPlaced?.Invoke(id);
        }

        internal void InvokeOrderCanceled(OrderId id)
        {
            OnOrderCanceled?.Invoke(id);
        }
        #endregion

        /// <inheritdoc />
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        protected override TimeSyncInfo GetTimeSyncInfo()
            => new TimeSyncInfo(_log, _options.SpotApiOptions.AutoTimestamp, TimeSyncState);

        /// <inheritdoc />
        public override TimeSpan GetTimeOffset()
            => TimeSyncState.TimeOffset;

        /// <inheritdoc />
        public ISpotClient CommonSpotClient => this;
    }
}
