using Bybit.Net.Interfaces.Clients.CopyTradingApi;
using Bybit.Net.Interfaces.Clients.DerivativesApi;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Bybit Rest API. 
    /// </summary>
    public interface IBybitRestClient: IRestClient
    {
        /// <summary>
        /// Spot API endpoints (v3)
        /// </summary>
        IBybitRestClientSpotApiV3 SpotApiV3 { get; }
        /// <summary>
        /// Copy trading API endpoints
        /// </summary>
        IBybitRestClientCopyTradingApi CopyTradingApi { get; }

        /// <summary>
        /// Derivatives API endpoints
        /// </summary>
        IBybitRestClientDerivativesApi DerivativesApi { get; }

        /// <summary>
        /// V5 API endpoints
        /// </summary>
        V5.IBybitRestClientApi V5Api { get; }

        /// <summary>
        /// Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.
        /// </summary>
        /// <param name="credentials">The credentials to set</param>
        void SetApiCredentials(ApiCredentials credentials);
    }
}
