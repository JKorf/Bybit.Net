using Bybit.Net.Clients.CopyTradingApi;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients.CopyTradingApi;
using CryptoExchange.Net;
using Bybit.Net.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.DerivativesApi;
using Bybit.Net.Clients.DerivativesApi;
using CryptoExchange.Net.Authentication;
using System.Net.Http;
using Bybit.Net.Objects.Options;
using System;
using Microsoft.Extensions.Logging;

namespace Bybit.Net.Clients
{
    /// <inheritdoc cref="IBybitRestClient" />
    public class BybitRestClient : BaseRestClient, IBybitRestClient
    {
        /// <inheritdoc />
        public IBybitRestClientSpotApiV3 SpotApiV3 { get; }
        /// <inheritdoc />
        public IBybitRestClientCopyTradingApi CopyTradingApi { get; }
        /// <inheritdoc />
        public IBybitRestClientDerivativesApi DerivativesApi { get; }
        /// <inheritdoc />
        public Interfaces.Clients.V5.IBybitRestClientApi V5Api { get; }

        #region constructor/destructor
        /// <summary>
        /// Create a new instance of the BybitRestClient using provided options
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BybitRestClient(Action<BybitRestOptions>? optionsDelegate = null) : this(null, null, optionsDelegate)
        {
        }

        /// <summary>
        /// Create a new instance of the BybitRestClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="httpClient">Http client for this client</param>
        public BybitRestClient(HttpClient? httpClient, ILoggerFactory? loggerFactory, Action<BybitRestOptions>? optionsDelegate = null)
            : base(loggerFactory, "Bybit")
        {
            var options = BybitRestOptions.Default.Copy();
            if (optionsDelegate != null)
                optionsDelegate(options);
            Initialize(options);

            SpotApiV3 = AddApiClient(new BybitRestClientSpotApiV3(_logger, httpClient, options));
            CopyTradingApi = AddApiClient(new BybitRestClientCopyTradingApi(_logger, httpClient, options));
            DerivativesApi = AddApiClient(new BybitRestClientDerivativesApi(_logger, httpClient, options));
            V5Api = AddApiClient(new V5.BybitRestClientApi(_logger, httpClient, options));
        }

        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BybitRestOptions> optionsDelegate)
        {
            var options = BybitRestOptions.Default.Copy();
            optionsDelegate(options);
            BybitRestOptions.Default = options;
        }

        /// <inheritdoc />
        public void SetApiCredentials(ApiCredentials credentials)
        {
            SpotApiV3.SetApiCredentials(credentials);
            CopyTradingApi.SetApiCredentials(credentials);
            DerivativesApi.SetApiCredentials(credentials);
            V5Api.SetApiCredentials(credentials);
        }
    }
}
