using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IBybitClientUsdPerpetualApi
    {
        /// <summary>
        /// Account
        /// </summary>
        IBybitClientUsdPerpetualApiAccount Account { get; }

        /// <summary>
        /// Exc
        /// </summary>
        IBybitClientUsdPerpetualApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Tra
        /// </summary>
        IBybitClientUsdPerpetualApiTrading Trading { get; }
    }
}