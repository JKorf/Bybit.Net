using Bybit.Net.Clients.V5;
using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit V5 API endpoints
    /// </summary>
    public interface IBybitRestClientApi : IBaseApiClient
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        BybitRestClientApiAccount Account { get; }
        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        BybitRestClientApiExchangeData ExchangeData { get; }
        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        BybitRestClientApiTrading Trading { get; }
    }
}