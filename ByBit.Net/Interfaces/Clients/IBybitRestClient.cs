using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects.Options;

namespace Bybit.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Bybit Rest API. 
    /// </summary>
    public interface IBybitRestClient: IRestClient
    {
        /// <summary>
        /// V5 API endpoints
        /// </summary>
        /// <see cref="IBybitRestClientApi"/>
        IBybitRestClientApi V5Api { get; }

        /// <summary>
        /// Update specific options
        /// </summary>
        /// <param name="options">Options to update. Only specific options are changeable after the client has been created</param>
        void SetOptions(UpdateOptions options);

        /// <summary>
        /// Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.
        /// </summary>
        /// <param name="credentials">The credentials to set</param>
        void SetApiCredentials(ApiCredentials credentials);
    }
}
