using Bybit.Net.Clients.V5;
using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit V5 API endpoints
    /// </summary>
    public interface IBybitClientApi : IBaseApiClient
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        BybitClientApiAccount Account { get; }
        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        BybitClientApiExchangeData ExchangeData { get; }
        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        BybitClientApiTrading Trading { get; }
    }
}