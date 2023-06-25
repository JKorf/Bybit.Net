using Bybit.Net.Interfaces.Clients.InverseFuturesApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.InverseFuturesApi
{
    /// <inheritdoc cref="IBybitRestClientInverseFuturesApi" />
    public class BybitRestClientInverseFuturesApi : RestApiClient, IBybitRestClientInverseFuturesApi
    {

        internal static TimeSyncState _timeSyncState = new TimeSyncState("Inverse Futures Api");
        /// <summary>
        /// Options
        /// </summary>
        public new BybitRestOptions ClientOptions => (BybitRestOptions)base.ClientOptions;

        /// <inheritdoc />
        public IBybitRestClientInverseFuturesApiAccount Account { get; }
        /// <inheritdoc />
        public IBybitRestClientInverseFuturesApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBybitRestClientInverseFuturesApiTrading Trading { get; }

        #region ctor
        internal BybitRestClientInverseFuturesApi(ILogger logger, HttpClient? httpClient, BybitRestOptions options) :
            base(logger, httpClient, options.Environment.RestBaseAddress, options, options.InverseFuturesOptions)
        {
            if (!string.IsNullOrEmpty(options.Referer))
            {
                StandardRequestHeaders = new Dictionary<string, string>
                {
                    { "x-referer", options.Referer! }
                };
            }

            manualParseError = true;

            Account = new BybitRestClientInverseFuturesApiAccount(this);
            ExchangeData = new BybitRestClientInverseFuturesApiExchangeData(this);
            Trading = new BybitRestClientInverseFuturesApiTrading(this);

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

        internal async Task<WebCallResult<BybitResult<T>>> SendRequestWrapperAsync<T>(
             Uri uri,
             HttpMethod method,
             CancellationToken cancellationToken,
             Dictionary<string, object>? parameters = null,
             bool signed = false,
             JsonSerializer? deserializer = null,
             bool ignoreRatelimit = false) where T : class
        {
            var result = await base.SendRequestAsync<BybitResult<T>>(uri, method, cancellationToken, parameters, signed, deserializer: deserializer, ignoreRatelimit: ignoreRatelimit).ConfigureAwait(false);
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
            var result = await base.SendRequestAsync<BybitResult<T>>(uri, method, cancellationToken, parameters, signed, deserializer: deserializer).ConfigureAwait(false);
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
