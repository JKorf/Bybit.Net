using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.CommonClients;
using System;

namespace Bybit.Net.Interfaces.Clients.SpotApi.v1
{
    /// <summary>
    /// Bybit spot API endpoints (v1)
    /// </summary>
    public interface IBybitClientSpotApiV1 : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitClientSpotApiAccountV1 Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitClientSpotApiExchangeDataV1 ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades 
        /// </summary>
        IBybitClientSpotApiTradingV1 Trading { get; }

        /// <summary>
        /// Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.
        /// </summary>
        /// <returns></returns>
        public ISpotClient CommonSpotClient { get; }
    }
}