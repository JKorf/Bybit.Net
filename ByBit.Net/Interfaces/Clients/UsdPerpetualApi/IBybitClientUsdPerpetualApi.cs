using System;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Bybit USD perpetual API endpoints
    /// </summary>
    public interface IBybitClientUsdPerpetualApi: IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitClientUsdPerpetualApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitClientUsdPerpetualApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitClientUsdPerpetualApiTrading Trading { get; }
    }
}