using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.SpotApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.ExchangeInterfaces;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.SpotApi
{
    /// <inheritdoc cref="IBybitClientSpotApi" />
    public class BybitClientSpotApi : RestApiClient, IBybitClientSpotApi, IExchangeClient
    {
        private readonly BybitClient _baseClient;
        private readonly BybitClientOptions _options;
        private readonly Log _log;

        internal static TimeSyncState TimeSyncState = new TimeSyncState();

        /// <inheritdoc />
        public event Action<ICommonOrderId>? OnOrderPlaced;
        /// <inheritdoc />
        public event Action<ICommonOrderId>? OnOrderCanceled;

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
                return new WebCallResult<BybitResult<T>>(result.ResponseStatusCode, result.ResponseHeaders, default, new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));

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
                return new WebCallResult<T>(result.ResponseStatusCode, result.ResponseHeaders, default, new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));

            return result.As(result.Data.Result);
        }

        #region Common interface
        /// <inheritdoc />
        public string GetSymbolName(string baseAsset, string quoteAsset)
        {
            return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();
        }

#pragma warning disable 1066
        async Task<WebCallResult<IEnumerable<ICommonSymbol>>> IExchangeClient.GetSymbolsAsync()
        {
            var result = await ExchangeData.GetSymbolsAsync().ConfigureAwait(false);
            return result.As<IEnumerable<ICommonSymbol>>(result.Data);
        }

        async Task<WebCallResult<IEnumerable<ICommonTicker>>> IExchangeClient.GetTickersAsync()
        {
            var result = await ExchangeData.GetTickersAsync().ConfigureAwait(false);
            return result.As<IEnumerable<ICommonTicker>>(result.Data);
        }

        async Task<WebCallResult<ICommonTicker>> IExchangeClient.GetTickerAsync(string symbol)
        {
            var result = await ExchangeData.GetTickerAsync(symbol).ConfigureAwait(false);
            return result.As<ICommonTicker>(result.Data);
        }

        async Task<WebCallResult<IEnumerable<ICommonKline>>> IExchangeClient.GetKlinesAsync(string symbol, TimeSpan timespan, DateTime? startTime = null, DateTime? endTime = null, int? limit = null)
        {
            var result = await ExchangeData.GetKlinesAsync(symbol, TimeSpanToInterval(timespan), startTime, endTime, limit).ConfigureAwait(false);
            return result.As<IEnumerable<ICommonKline>>(result.Data);
        }

        async Task<WebCallResult<ICommonOrderBook>> IExchangeClient.GetOrderBookAsync(string symbol)
        {
            var result = await ExchangeData.GetOrderBookAsync(symbol).ConfigureAwait(false);
            return result.As<ICommonOrderBook>(result.Data);
        }

        async Task<WebCallResult<IEnumerable<ICommonRecentTrade>>> IExchangeClient.GetRecentTradesAsync(string symbol)
        {
            var result = await ExchangeData.GetTradeHistoryAsync(symbol).ConfigureAwait(false);
            return result.As<IEnumerable<ICommonRecentTrade>>(result.Data);
        }

        async Task<WebCallResult<ICommonOrderId>> IExchangeClient.PlaceOrderAsync(string symbol, IExchangeClient.OrderSide side, IExchangeClient.OrderType type, decimal quantity, decimal? price = null, string? accountId = null)
        {
            var result = await Trading.PlaceOrderAsync(
                symbol,
                side == IExchangeClient.OrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                type == IExchangeClient.OrderType.Limit ? OrderType.Limit : OrderType.Market,
                quantity,
                price,
                type == IExchangeClient.OrderType.Limit ? TimeInForce.GoodTillCanceled : (TimeInForce?)null
                ).ConfigureAwait(false);
            return result.As<ICommonOrderId>(result.Data);
        }

        async Task<WebCallResult<ICommonOrder>> IExchangeClient.GetOrderAsync(string orderId, string? symbol = null)
        {
            var result = await Trading.GetOrderAsync(long.Parse(orderId)).ConfigureAwait(false);
            return result.As<ICommonOrder>(result.Data);
        }

        async Task<WebCallResult<IEnumerable<ICommonTrade>>> IExchangeClient.GetTradesAsync(string orderId, string? symbol = null)
        {
            var result = await Trading.GetUserTradesAsync(fromId: long.Parse(orderId), toId: long.Parse(orderId)).ConfigureAwait(false);
            return result.As<IEnumerable<ICommonTrade>>(result.Data);
        }

        async Task<WebCallResult<IEnumerable<ICommonOrder>>> IExchangeClient.GetOpenOrdersAsync(string? symbol = null)
        {
            var result = await Trading.GetOpenOrdersAsync(symbol).ConfigureAwait(false);
            return result.As<IEnumerable<ICommonOrder>>(result.Data);
        }

        async Task<WebCallResult<IEnumerable<ICommonOrder>>> IExchangeClient.GetClosedOrdersAsync(string? symbol = null)
        {
            var result = await Trading.GetOrdersAsync(symbol).ConfigureAwait(false);
            return result.As<IEnumerable<ICommonOrder>>(result.Data);
        }

        async Task<WebCallResult<ICommonOrderId>> IExchangeClient.CancelOrderAsync(string orderId, string? symbol = null)
        {
            var result = await Trading.CancelOrderAsync(long.Parse(orderId)).ConfigureAwait(false);
            return result.As<ICommonOrderId>(result.Data);
        }

        async Task<WebCallResult<IEnumerable<ICommonBalance>>> IExchangeClient.GetBalancesAsync(string? accountId = null)
        {
            var result = await Account.GetBalancesAsync().ConfigureAwait(false);
            return result.As<IEnumerable<ICommonBalance>>(result.Data);
        }
#pragma warning restore

        private KlineInterval TimeSpanToInterval(TimeSpan timeSpan)
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

        internal void InvokeOrderPlaced(ICommonOrderId id)
        {
            OnOrderPlaced?.Invoke(id);
        }

        internal void InvokeOrderCanceled(ICommonOrderId id)
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
        public IExchangeClient AsExchangeClient() => this;
    }
}
