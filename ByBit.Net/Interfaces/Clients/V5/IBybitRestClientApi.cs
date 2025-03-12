using Bybit.Net.Clients.V5;
using CryptoExchange.Net.Interfaces;

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
        /// Endpoint for crypto loans
        /// </summary>
        IBybitRestClientApiCryptoLoan CryptoLoan { get; }
        /// <summary>
        /// Endpoints for Bybit Earn
        /// </summary>
        IBybitRestClientApiEarn Earn { get; }

        /// <summary>
        /// Get the shared rest requests client. This interface is shared with other exchanges to allow for a common implementation for different exchanges.
        /// </summary>
        public IBybitRestClientApiShared SharedClient { get; }
    }
}