using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.InversePerpetualApi
{
    /// <inheritdoc cref="IBybitClientInversePerpetualApi" />
    public class BybitClientInversePerpetualApi : RestApiClient, IBybitClientInversePerpetualApi
    {
        internal static TimeSyncState TimeSyncState = new TimeSyncState("Inverse Perpetual Api");
        internal BybitClientOptions ClientOptions { get; }

        /// <inheritdoc />
        public IBybitClientInversePerpetualApiAccount Account { get; }
        /// <inheritdoc />
        public IBybitClientInversePerpetualApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBybitClientInversePerpetualApiTrading Trading { get; }

        #region ctor
        internal BybitClientInversePerpetualApi(Log log, BybitClientOptions options)
            : base(log, options, options.InversePerpetualApiOptions)
        {
            if (!string.IsNullOrEmpty(options.Referer))
            {
                StandardRequestHeaders = new Dictionary<string, string>
                {
                    { "x-referer", options.Referer! }
                };
            }

            manualParseError = true;

            ClientOptions = options;

            Account = new BybitClientInversePerpetualApiAccount(this);
            ExchangeData = new BybitClientInversePerpetualApiExchangeData(this);
            Trading = new BybitClientInversePerpetualApiTrading(this);

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
            => new TimeSyncInfo(_log, Options.AutoTimestamp, Options.TimestampRecalculationInterval, TimeSyncState);

        /// <inheritdoc />
        public override TimeSpan? GetTimeOffset()
            => TimeSyncState.TimeOffset;
    }
}
