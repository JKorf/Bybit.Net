using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IBybitClientUsdPerpetual
    {
        /// <summary>
        /// Account
        /// </summary>
        IBybitClientUsdPerpetualAccount Account { get; }

        /// <summary>
        /// Exc
        /// </summary>
        IBybitClientUsdPerpetualExchangeData ExchangeData { get; }

        /// <summary>
        /// Tra
        /// </summary>
        IBybitClientUsdPerpetualTrading Trading { get; }
    }
}