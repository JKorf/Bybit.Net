using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IBybitClientFutures: IRestClient
    {
        /// <summary>
        /// Account
        /// </summary>
        IBybitClientFuturesAccount Account { get; }

        /// <summary>
        /// Exc
        /// </summary>
        IBybitClientFuturesExchangeData ExchangeData { get; }

        /// <summary>
        /// Tra
        /// </summary>
        IBybitClientFuturesTrading Trading { get; }

        /// <summary>
        /// Set 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="apiSecret"></param>
        void SetApiCredentials(string apiKey, string apiSecret);
    }
}