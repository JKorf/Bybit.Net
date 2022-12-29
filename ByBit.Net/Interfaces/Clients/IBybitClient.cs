using Bybit.Net.Interfaces.Clients.CopyTradingApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi;
using Bybit.Net.Interfaces.Clients.GeneralApi;
using Bybit.Net.Interfaces.Clients.InverseFuturesApi;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Interfaces.Clients.SpotApi.v1;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Bybit Rest API. 
    /// </summary>
    public interface IBybitClient: IRestClient
    {
        /// <summary>
        /// General API endpoints
        /// </summary>
        IBybitClientGeneralApi GeneralApi { get; }
        /// <summary>
        /// Inverse perpetual API endpoints
        /// </summary>
        IBybitClientInversePerpetualApi InversePerpetualApi { get; }
        /// <summary>
        /// USD perpetual API endpoints
        /// </summary>
        IBybitClientUsdPerpetualApi UsdPerpetualApi { get; }
        /// <summary>
        /// Inverse futures API endpoints
        /// </summary>
        IBybitClientInverseFuturesApi InverseFuturesApi { get; }
        /// <summary>
        /// Spot API endpoints (v1)
        /// </summary>
        IBybitClientSpotApiV1 SpotApiV1 { get; }
        /// <summary>
        /// Spot API endpoints (v3)
        /// </summary>
        IBybitClientSpotApiV3 SpotApiV3 { get; }
        /// <summary>
        /// Copy trading API endpoints
        /// </summary>
        IBybitClientCopyTradingApi CopyTradingApi { get; }

        /// <summary>
        /// Derivatives API endpoints
        /// </summary>
        IBybitClientDerivativesApi DerivativesApi { get; }
    }
}
