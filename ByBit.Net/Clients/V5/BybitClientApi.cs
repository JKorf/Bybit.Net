using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Logging;
using Bybit.Net.Interfaces.Clients.V5;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitClientApi"/>
    public class BybitClientApi : RestApiClient, IBybitClientApi
    {
        internal TimeSyncState TimeSyncState = new TimeSyncState("Bybit V5 API");
        internal BybitClientOptions ClientOptions { get; }

        /// <inheritdoc />
        public BybitClientApiAccount Account { get; }
        /// <inheritdoc />
        public BybitClientApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public BybitClientApiTrading Trading { get; }

        #region ctor
        internal BybitClientApi(Log log, BybitClientOptions options)
            : base(log, options, options.InverseFuturesApiOptions)
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

            Account = new BybitClientApiAccount(this);
            ExchangeData = new BybitClientApiExchangeData(this);
            Trading = new BybitClientApiTrading(this);

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
        protected override async Task<WebCallResult<DateTime>> GetServerTimestampAsync()
        {
            var time = await ExchangeData.GetServerTimeAsync().ConfigureAwait(false);
            if (!time)
                return time.As<DateTime>(default);

            return time.As(time.Data.TimeNano);
        }

        /// <inheritdoc />
        public override TimeSyncInfo? GetTimeSyncInfo()
            => new TimeSyncInfo(_log, Options.AutoTimestamp, Options.TimestampRecalculationInterval, TimeSyncState);

        /// <inheritdoc />
        public override TimeSpan? GetTimeOffset()
            => TimeSyncState.TimeOffset;

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
    }
}
