using Bybit.Net;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.ExchangeInterfaces;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.Rest.Futures
{
    public class BybitClientInverseFutures : RestSubClient, IBybitClientInverseFutures
    {
        private readonly BybitClient _baseClient;

        internal new BybitClientOptions ClientOptions { get; }

        public IBybitClientInverseFuturesAccount Account { get; }
        public IBybitClientInverseFuturesExchangeData ExchangeData { get; }
        public IBybitClientInverseFuturesTrading Trading { get; }

        #region ctor
        /// <summary>
        /// Create a new instance of BybitClientFutures using the provided options
        /// </summary>
        public BybitClientInverseFutures(BybitClient baseClient, BybitClientOptions options) 
            : base(options.OptionsInverseFutures, options.OptionsInverseFutures.ApiCredentials == null ? null : new BybitAuthenticationProvider(options.OptionsInverseFutures.ApiCredentials))
        {
            _baseClient = baseClient;
            ClientOptions = options;

            Account = new BybitClientInverseFuturesAccount(this);
            ExchangeData = new BybitClientInverseFuturesExchangeData(this);
            Trading = new BybitClientInverseFuturesTrading(this);
        }
        #endregion

        /// <summary>
        /// Get url for an endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        internal Uri GetUrl(string endpoint)
        {
            return new Uri($"{BaseAddress}/{endpoint}");
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
    }
}
