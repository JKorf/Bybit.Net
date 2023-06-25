using CryptoExchange.Net.Interfaces;
using System;

namespace Bybit.Net.Interfaces.Clients.InverseFuturesApi
{
    /// <summary>
    /// Bybit inverse futures API endpoints
    /// </summary>
    public interface IBybitRestClientInverseFuturesApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitRestClientInverseFuturesApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitRestClientInverseFuturesApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitRestClientInverseFuturesApiTrading Trading { get; }
    }
}