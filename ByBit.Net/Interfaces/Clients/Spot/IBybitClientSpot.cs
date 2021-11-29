using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IBybitClientSpot
    {
        /// <summary>
        /// Account
        /// </summary>
        IBybitClientSpotAccount Account { get; }

        /// <summary>
        /// Exc
        /// </summary>
        IBybitClientSpotExchangeData ExchangeData { get; }

        /// <summary>
        /// Tra
        /// </summary>
        IBybitClientSpotTrading Trading { get; }
    }
}