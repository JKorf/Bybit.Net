using Bybit.Net.Clients.CopyTradingApi;
using Bybit.Net.Clients.InversePerpetualApi;
using Bybit.Net.Interfaces.Clients.GeneralApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.GeneralApi
{
    /// <inheritdoc cref="IBybitRestClientGeneralApi" />
    public class BybitRestClientGeneralApi : RestApiClient, IBybitRestClientGeneralApi
    {
        private readonly BybitRestClient _baseClient;

        /// <summary>
        /// Options
        /// </summary>
        public new BybitRestOptions ClientOptions => (BybitRestOptions)base.ClientOptions;

        /// <inheritdoc />
        public IBybitRestClientGeneralApiTransfer Transfer { get; }
        /// <inheritdoc />
        public IBybitRestClientGeneralApiWithdrawDeposit WithdrawDeposit { get; }

        #region ctor
        internal BybitRestClientGeneralApi(ILogger logger, BybitRestClient restClient, HttpClient? httpClient, BybitRestOptions options) :
            base(logger, httpClient, options.Environment.RestBaseAddress, options, options.InversePerpetualOptions)
        {
            if (!string.IsNullOrEmpty(options.Referer))
            {
                StandardRequestHeaders = new Dictionary<string, string>
                {
                    { "x-referer", options.Referer! }
                };
            }

            _baseClient = restClient;

            Transfer = new BybitRestClientGeneralApiTransfer(this);
            WithdrawDeposit = new BybitRestClientGeneralApiWithdrawDeposit(this);

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
            => _baseClient.InversePerpetualApi.ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override TimeSyncInfo? GetTimeSyncInfo()
            => new TimeSyncInfo(_logger, (ApiOptions.AutoTimestamp ?? ClientOptions.AutoTimestamp), (ApiOptions.TimestampRecalculationInterval ?? ClientOptions.TimestampRecalculationInterval), BybitRestClientInversePerpetualApi._timeSyncState);

        /// <inheritdoc />
        public override TimeSpan? GetTimeOffset()
            => BybitRestClientCopyTradingApi._timeSyncState.TimeOffset;
    }
}
