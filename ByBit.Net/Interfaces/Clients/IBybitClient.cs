using Bybit.Net.Clients.Rest.Futures;
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
        public IBybitClientGeneralApi GeneralApi { get; }
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
    }
}
