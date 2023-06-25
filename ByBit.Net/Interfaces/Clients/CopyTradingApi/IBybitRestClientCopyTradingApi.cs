using CryptoExchange.Net.Interfaces;
using System;

namespace Bybit.Net.Interfaces.Clients.CopyTradingApi
{
    /// <summary>
    /// Bybit Copy Trading endpoints
    /// </summary>
    public interface IBybitRestClientCopyTradingApi: IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitRestClientCopyTradingApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitRestClientCopyTradingApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitRestClientCopyTradingApiTrading Trading { get; }
    }
}
