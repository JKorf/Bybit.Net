using Bybit.Net.Clients.InversePerpetualApi;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.UsdPerpetualApi
{
    /// <inheritdoc cref="IBybitClientUsdPerpetualApi" />
    public class BybitClientUsdPerpetualApi : RestApiClient, IBybitClientUsdPerpetualApi
    {
        private readonly BybitClient _baseClient;
        private readonly BybitClientOptions _options;
        private readonly Log _log;

        internal BybitClientOptions ClientOptions { get; }

        /// <inheritdoc />
        public IBybitClientUsdPerpetualApiAccount Account { get; }
        /// <inheritdoc />
        public IBybitClientUsdPerpetualApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBybitClientUsdPerpetualApiTrading Trading { get; }

        #region ctor
        internal BybitClientUsdPerpetualApi(Log log, BybitClient baseClient, BybitClientOptions options)
            : base(options, options.UsdPerpetualApiOptions)
        {
            _baseClient = baseClient;
            _log = log;
            _options = options;
            ClientOptions = options;

            Account = new BybitClientUsdPerpetualApiAccount(baseClient, this);
            ExchangeData = new BybitClientUsdPerpetualApiExchangeData(this);
            Trading = new BybitClientUsdPerpetualApiTrading(this);
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

        /// <inheritdoc />
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        protected override TimeSyncInfo GetTimeSyncInfo()
            => new TimeSyncInfo(_log, _options.UsdPerpetualApiOptions.AutoTimestamp, BybitClientInversePerpetualApi.TimeSyncState);

        /// <inheritdoc />
        public override TimeSpan GetTimeOffset()
            => BybitClientInversePerpetualApi.TimeSyncState.TimeOffset;
    }
}
