﻿using Bybit.Net.Clients.CopyTradingApi;
using Bybit.Net.Clients.InversePerpetualApi;
using Bybit.Net.Interfaces.Clients.GeneralApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.GeneralApi
{
    /// <inheritdoc cref="IBybitClientGeneralApi" />
    public class BybitClientGeneralApi : RestApiClient, IBybitClientGeneralApi
    {
        private readonly BybitClient _baseClient;
        internal BybitClientOptions ClientOptions { get; }

        /// <inheritdoc />
        public IBybitClientGeneralApiTransfer Transfer { get; }
        /// <inheritdoc />
        public IBybitClientGeneralApiWithdrawDeposit WithdrawDeposit { get; }

        #region ctor
        internal BybitClientGeneralApi(Log log, BybitClient baseClient, BybitClientOptions options)
            : base(log, options, options.SpotApiOptions)
        {
            if (!string.IsNullOrEmpty(options.Referer))
            {
                StandardRequestHeaders = new Dictionary<string, string>
                {
                    { "x-referer", options.Referer! }
                };
            }

            _baseClient = baseClient;
            ClientOptions = options;

            Transfer = new BybitClientGeneralApiTransfer(this);
            WithdrawDeposit = new BybitClientGeneralApiWithdrawDeposit(this);

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
        public override TimeSyncInfo GetTimeSyncInfo()
            => new TimeSyncInfo(_log, Options.AutoTimestamp, Options.TimestampRecalculationInterval, BybitClientInversePerpetualApi.TimeSyncState);

        /// <inheritdoc />
        public override TimeSpan GetTimeOffset()
            => BybitClientCopyTradingApi.TimeSyncState.TimeOffset;
    }
}
