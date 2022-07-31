using Bybit.Net.Interfaces.Clients.CopyTradingApi;
using Bybit.Net.Interfaces.Clients.GeneralApi;
using Bybit.Net.Interfaces.Clients.InverseFuturesApi;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
using Bybit.Net.Interfaces.Clients.SpotApi;
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
        /// Spot API endpoints
        /// </summary>
        IBybitClientSpotApi SpotApi { get; }
        /// <summary>
        /// Copy trading API endpoints
        /// </summary>
        IBybitClientCopyTradingApi CopyTradingApi { get; }
    }
}
