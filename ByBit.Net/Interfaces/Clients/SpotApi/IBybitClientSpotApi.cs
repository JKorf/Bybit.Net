using System;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Bybit spot API endpoints
    /// </summary>
    public interface IBybitClientSpotApi : IDisposable
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
    }
}