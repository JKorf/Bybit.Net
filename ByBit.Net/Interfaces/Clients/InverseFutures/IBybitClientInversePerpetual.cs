using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IBybitClientInverseFutures
    {
        /// <summary>
        /// Account
        /// </summary>
        IBybitClientInverseFuturesAccount Account { get; }

        /// <summary>
        /// Exc
        /// </summary>
        IBybitClientInverseFuturesExchangeData ExchangeData { get; }

        /// <summary>
        /// Tra
        /// </summary>
        IBybitClientInverseFuturesTrading Trading { get; }
    }
}