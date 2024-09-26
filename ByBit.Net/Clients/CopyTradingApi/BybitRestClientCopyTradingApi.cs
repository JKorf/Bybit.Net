using Bybit.Net.Interfaces.Clients.CopyTradingApi;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.CopyTradingApi
{
    /// <inheritdoc cref="IBybitRestClientCopyTradingApi" />
    internal class BybitRestClientCopyTradingApi : RestApiClient, IBybitRestClientCopyTradingApi
    {
        internal static TimeSyncState _timeSyncState = new TimeSyncState("CopyTrade Api");

        /// <summary>
        /// Options
        /// </summary>
        public new BybitRestOptions ClientOptions => (BybitRestOptions)base.ClientOptions;

        /// <inheritdoc />
        public string ExchangeName => "Bybit";

        /// <inheritdoc />
        public IBybitRestClientCopyTradingApiAccount Account { get; }
        /// <inheritdoc />
        public IBybitRestClientCopyTradingApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBybitRestClientCopyTradingApiTrading Trading { get; }

        #region ctor

        internal BybitRestClientCopyTradingApi(ILogger logger, HttpClient? httpClient, BybitRestOptions options) :
            base(logger, httpClient, options.Environment.RestBaseAddress, options, options.CopyTradingOptions)
        {
            if (!string.IsNullOrEmpty(options.Referer))
            {
                StandardRequestHeaders = new Dictionary<string, string>
                {
                    { "x-referer", options.Referer! }
                };
            }

            Account = new BybitRestClientCopyTradingApiAccount(this);
            ExchangeData = new BybitRestClientCopyTradingApiExchangeData(this);
            Trading = new BybitRestClientCopyTradingApiTrading(this);

            RequestBodyFormat = RequestBodyFormat.FormData;
            ParameterPositions[HttpMethod.Delete] = HttpMethodParameterPosition.InUri;
        }
        #endregion

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null) => baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();

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
             bool signed = false) where T : class
        {
            var result = await base.SendRequestAsync<BybitResult<T>>(uri, method, cancellationToken, parameters, signed, requestWeight: 0).ConfigureAwait(false);
            if (!result)
                return result.As<BybitResult<T>>(default);

            if (result.Data.ReturnCode != 0)
                return result.AsError<BybitResult<T>>(new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));               

            return result.As(result.Data);
        }

        internal async Task<WebCallResult<IEnumerable<T>>> SendRequestListAsync<T>(
             Uri uri,
             HttpMethod method,
             CancellationToken cancellationToken,
             Dictionary<string, object>? parameters = null,
             bool signed = false)
        {
            var result = await base.SendRequestAsync<BybitCopyTradingResult<BybitList<T>>>(uri, method, cancellationToken, parameters, signed, requestWeight: 0).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<T>>(default);

            if (result.Data.ReturnCode != 0)
                return result.AsError<IEnumerable<T>>(new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));

            return result.As(result.Data.Result.List);
        }

        internal async Task<WebCallResult<T>> SendRequestAsync<T>(
             Uri uri,
             HttpMethod method,
             CancellationToken cancellationToken,
             Dictionary<string, object>? parameters = null,
             bool signed = false)
        {
            var result = await base.SendRequestAsync<BybitCopyTradingResult<T>>(uri, method, cancellationToken, parameters, signed, requestWeight: 0).ConfigureAwait(false);
            if (!result)
                return result.As<T>(default);

            if (result.Data.ReturnCode != 0)
                return result.AsError<T>(new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));
                
            return result.As(result.Data.Result);
        }

        /// <inheritdoc />
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override TimeSyncInfo? GetTimeSyncInfo()
            => new TimeSyncInfo(_logger, (ApiOptions.AutoTimestamp ?? ClientOptions.AutoTimestamp), (ApiOptions.TimestampRecalculationInterval ?? ClientOptions.TimestampRecalculationInterval), _timeSyncState);

        /// <inheritdoc />
        public override TimeSpan? GetTimeOffset()
            => _timeSyncState.TimeOffset;
    }
}
