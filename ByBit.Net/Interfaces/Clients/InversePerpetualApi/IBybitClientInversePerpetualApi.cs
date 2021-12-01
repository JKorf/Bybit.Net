using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IBybitClientInversePerpetualApi
    {
        /// <summary>
        /// Account
        /// </summary>
        IBybitClientInversePerpetualApiAccount Account { get; }

        /// <summary>
        /// Exc
        /// </summary>
        IBybitClientInversePerpetualApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Tra
        /// </summary>
        IBybitClientInversePerpetualApiTrading Trading { get; }
    }
}