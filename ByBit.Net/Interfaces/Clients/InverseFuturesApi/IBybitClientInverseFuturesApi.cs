using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IBybitClientInverseFuturesApi
    {
        /// <summary>
        /// Account
        /// </summary>
        IBybitClientInverseFuturesApiAccount Account { get; }

        /// <summary>
        /// Exc
        /// </summary>
        IBybitClientInverseFuturesApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Tra
        /// </summary>
        IBybitClientInverseFuturesApiTrading Trading { get; }
    }
}