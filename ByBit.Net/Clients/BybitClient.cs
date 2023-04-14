using Bybit.Net.Clients.CopyTradingApi;
using Bybit.Net.Clients.GeneralApi;
using Bybit.Net.Clients.InverseFuturesApi;
using Bybit.Net.Clients.InversePerpetualApi;
using Bybit.Net.Clients.UsdPerpetualApi;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Interfaces.Clients.CopyTradingApi;
using Bybit.Net.Interfaces.Clients.GeneralApi;
using Bybit.Net.Interfaces.Clients.InverseFuturesApi;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Interfaces.Clients.SpotApi.v1;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
using Bybit.Net.Objects;
using CryptoExchange.Net;
using Bybit.Net.Clients.SpotApi.v1;
using Bybit.Net.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.DerivativesApi;
using Bybit.Net.Clients.DerivativesApi;
using CryptoExchange.Net.Authentication;

namespace Bybit.Net.Clients
{
    /// <inheritdoc cref="IBybitClient" />
    public class BybitClient : BaseRestClient, IBybitClient
    {
        /// <inheritdoc />
        public IBybitClientGeneralApi GeneralApi { get; }
        /// <inheritdoc />
        public IBybitClientSpotApiV1 SpotApiV1 { get; }
        /// <inheritdoc />
        public IBybitClientSpotApiV3 SpotApiV3 { get; }
        /// <inheritdoc />
        public IBybitClientInversePerpetualApi InversePerpetualApi { get; }
        /// <inheritdoc />
        public IBybitClientInverseFuturesApi InverseFuturesApi { get; }
        /// <inheritdoc />
        public IBybitClientUsdPerpetualApi UsdPerpetualApi { get; }
        /// <inheritdoc />
        public IBybitClientCopyTradingApi CopyTradingApi { get; }
        /// <inheritdoc />
        public IBybitClientDerivativesApi DerivativesApi { get; }
        /// <inheritdoc />
        public Interfaces.Clients.V5.IBybitClientApi V5Api { get; }

        #region constructor/destructor
        /// <summary>
        /// Create a new instance of the BybitClient using the default options
        /// </summary>
        public BybitClient() : this(BybitClientOptions.Default)
        {
        }

        /// <summary>
        /// Create a new instance of the BybitClient using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public BybitClient(BybitClientOptions options) : base("Bybit", options)
        {
            InversePerpetualApi = AddApiClient(new BybitClientInversePerpetualApi(log, options));
            InverseFuturesApi = AddApiClient(new BybitClientInverseFuturesApi(log, options));
            UsdPerpetualApi = AddApiClient(new BybitClientUsdPerpetualApi(log, options));
            SpotApiV1 = AddApiClient(new BybitClientSpotApiV1(log, options));
            SpotApiV3 = AddApiClient(new BybitClientSpotApiV3(log, options));
            GeneralApi = AddApiClient(new BybitClientGeneralApi(log, this, options));
            CopyTradingApi = AddApiClient(new BybitClientCopyTradingApi(log, options));
            DerivativesApi = AddApiClient(new BybitClientDerivativesApi(log, options));
            V5Api = AddApiClient(new V5.BybitClientApi(log, options));
        }
        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="options"></param>
        public static void SetDefaultOptions(BybitClientOptions options)
        {
            BybitClientOptions.Default = options;
        }

        /// <inheritdoc />
        public void SetApiCredentials(ApiCredentials credentials)
        {
            InversePerpetualApi.SetApiCredentials(credentials);
            InverseFuturesApi.SetApiCredentials(credentials);
            UsdPerpetualApi.SetApiCredentials(credentials);
            SpotApiV1.SetApiCredentials(credentials);
            SpotApiV3.SetApiCredentials(credentials);
            GeneralApi.SetApiCredentials(credentials);
            CopyTradingApi.SetApiCredentials(credentials);
            DerivativesApi.SetApiCredentials(credentials);
            V5Api.SetApiCredentials(credentials);
        }
    }
}
