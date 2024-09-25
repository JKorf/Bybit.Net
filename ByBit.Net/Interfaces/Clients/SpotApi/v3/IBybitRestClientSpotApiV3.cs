using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.CommonClients;
using System;

namespace Bybit.Net.Interfaces.Clients.SpotApi.v3
{
    /// <summary>
    /// Bybit spot API endpoints (v3)
    /// </summary>
    public interface IBybitRestClientSpotApiV3 : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitRestClientSpotApiAccountV3 Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitRestClientSpotApiExchangeDataV3 ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitRestClientSpotApiTradingV3 Trading { get; }

        /// <summary>
        /// DEPRECATED; use <see cref="CryptoExchange.Net.SharedApis.ISharedClient" /> instead for common/shared functionality. See <see href="https://jkorf.github.io/CryptoExchange.Net/docs/index.html#shared" /> for more info.
        /// </summary>
        public ISpotClient CommonSpotClient { get; }
    }
}