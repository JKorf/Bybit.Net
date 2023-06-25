using CryptoExchange.Net.Interfaces;
using System;

namespace Bybit.Net.Interfaces.Clients.InversePerpetualApi
{
    /// <summary>
    /// Bybit inverse perpetual API endpoints
    /// </summary>
    public interface IBybitRestClientInversePerpetualApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitRestClientInversePerpetualApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitRestClientInversePerpetualApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitRestClientInversePerpetualApiTrading Trading { get; }
    }
}