using CryptoExchange.Net.ExchangeInterfaces;
using System;

namespace Bybit.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Bybit spot API endpoints
    /// </summary>
    public interface IBybitClientSpotApi : IExchangeClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitClientSpotApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitClientSpotApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitClientSpotApiTrading Trading { get; }

        /// <summary>
        /// Get the IExchangeClient for this client
        /// </summary>
        /// <returns></returns>
        IExchangeClient AsExchangeClient();
    }
}