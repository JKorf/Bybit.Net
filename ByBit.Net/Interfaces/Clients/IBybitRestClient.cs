using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects.Options;

namespace Bybit.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Bybit Rest API. 
    /// </summary>
    public interface IBybitRestClient: IRestClient<BybitCredentials>
    {
        /// <summary>
        /// V5 API endpoints
        /// </summary>
        /// <see cref="IBybitRestClientApi"/>
        IBybitRestClientApi V5Api { get; }
    }
}
