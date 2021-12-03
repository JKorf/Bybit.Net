using System;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Bybit inverse perpetual API endpoints
    /// </summary>
    public interface IBybitClientInversePerpetualApi : IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitClientInversePerpetualApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitClientInversePerpetualApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitClientInversePerpetualApiTrading Trading { get; }
    }
}