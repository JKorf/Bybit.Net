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
        /// DEPRECATED; use <see cref="CryptoExchange.Net.SharedApis.ISharedClient" /> instead for common/shared functionality. See <see href="https://jkorf.github.io/CryptoExchange.Net/docs/index.html#shared" /> for more info.
        /// </summary>
        public ISpotClient CommonSpotClient { get; }

        /// <summary>
        /// Get the shared rest requests client. This interface is shared with other exhanges to allow for a common implementation for different exchanges.
        /// </summary>
        public IBybitRestClientApiShared SharedClient { get; }
    }
}