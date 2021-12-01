using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IBybitClientSpotApi
    {
        /// <summary>
        /// Account
        /// </summary>
        IBybitClientSpotApiAccount Account { get; }

        /// <summary>
        /// Exc
        /// </summary>
        IBybitClientSpotApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Tra
        /// </summary>
        IBybitClientSpotApiTrading Trading { get; }
    }
}