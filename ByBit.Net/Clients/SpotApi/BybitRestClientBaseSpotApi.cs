using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.SpotApi
{
    /// <summary>
    /// Base client for the Bybit rest spot API
    /// </summary>
    public abstract class BybitRestClientBaseSpotApi : RestApiClient, ISpotClient
    {
        internal static TimeSyncState _timeSyncState = new TimeSyncState("Spot Api");

        /// <summary>
        /// Options
        /// </summary>
        public new BybitRestOptions ClientOptions => (BybitRestOptions)base.ClientOptions;

        /// <inheritdoc />
        public event Action<OrderId>? OnOrderPlaced;
        /// <inheritdoc />
        public event Action<OrderId>? OnOrderCanceled;

        /// <inheritdoc />
        public abstract Task<WebCallResult<OrderId>> PlaceOrderAsync(string symbol, CommonOrderSide side, CommonOrderType type, decimal quantity, decimal? price = null, string? accountId = null, string? clientOrderId = null, CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<OrderId>> CancelOrderAsync(string orderId, string? symbol = null, CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public string ExchangeName => "Bybit";

     
        #region ctor
        internal BybitRestClientBaseSpotApi(ILogger logger, HttpClient? httpClient, string baseAddress, BybitRestOptions options, RestApiOptions apiOptions)
            : base(logger, httpClient, baseAddress, options, apiOptions)
        {
            manualParseError = true;

            requestBodyFormat = RequestBodyFormat.FormData;
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
        protected override Task<ServerError?> TryParseErrorAsync(JToken data)
        {
            var responseCode = data["ret_code"];
            if (responseCode != null && responseCode.ToString() != "0")
            {
                var errorMessage = data["ret_msg"];
                return Task.FromResult(new ServerError(responseCode.Value<int>(), errorMessage!.ToString()))!;
            }

            return Task.FromResult<ServerError?>(null);
        }

        internal async Task<WebCallResult<T>> SendRequestAsync<T>(
             Uri uri,
             HttpMethod method,
             CancellationToken cancellationToken,
             Dictionary<string, object>? parameters = null,
             bool signed = false,
             JsonSerializer? deserializer = null,
             bool ignoreRatelimit = false)
        {
            var result = await base.SendRequestAsync<BybitResult<T>>(uri, method, cancellationToken, parameters, signed, deserializer: deserializer, ignoreRatelimit: ignoreRatelimit).ConfigureAwait(false);
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

        /// <inheritdoc />
        public abstract Task<WebCallResult<IEnumerable<Symbol>>> GetSymbolsAsync(CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<Ticker>> GetTickerAsync(string symbol, CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<IEnumerable<Ticker>>> GetTickersAsync(CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<IEnumerable<Kline>>> GetKlinesAsync(string symbol, TimeSpan timespan, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<OrderBook>> GetOrderBookAsync(string symbol, CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<IEnumerable<Trade>>> GetRecentTradesAsync(string symbol, CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<IEnumerable<Balance>>> GetBalancesAsync(string? accountId = null, CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<Order>> GetOrderAsync(string orderId, string? symbol = null, CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<IEnumerable<UserTrade>>> GetOrderTradesAsync(string orderId, string? symbol = null, CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<IEnumerable<Order>>> GetOpenOrdersAsync(string? symbol = null, CancellationToken ct = new CancellationToken());

        /// <inheritdoc />
        public abstract Task<WebCallResult<IEnumerable<Order>>> GetClosedOrdersAsync(string? symbol = null, CancellationToken ct = new CancellationToken());

        /// <summary>
        /// Timespan to kline interval
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected static KlineInterval TimeSpanToInterval(TimeSpan timeSpan)
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
            {
                return KlineInterval.OneMonth;
            }

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
        public override TimeSyncInfo? GetTimeSyncInfo()
            => new TimeSyncInfo(_logger, (ApiOptions.AutoTimestamp ?? ClientOptions.AutoTimestamp), (ApiOptions.TimestampRecalculationInterval ?? ClientOptions.TimestampRecalculationInterval), _timeSyncState);

        /// <inheritdoc />
        public override TimeSpan? GetTimeOffset()
            => _timeSyncState.TimeOffset;

        /// <inheritdoc />
        public ISpotClient CommonSpotClient => this;
    }
}
