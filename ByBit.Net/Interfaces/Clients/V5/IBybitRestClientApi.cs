using Bybit.Net.Clients.V5;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.CommonClients;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit V5 API endpoints
    /// </summary>
    public interface IBybitRestClientApi : IBaseApiClient, IRestApiClient
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitRestClientApiAccount Account { get; }
        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitRestClientApiExchangeData ExchangeData { get; }
        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitRestClientApiTrading Trading { get; }
        /// <summary>
        /// Endpoint for managing sub accounts
        /// </summary>
        IBybitRestClientApiSubAccounts SubAccount { get; }

        /// <summary>
        /// Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.
        /// </summary>
        /// <returns></returns>
        public ISpotClient CommonSpotClient { get; }
    }
}