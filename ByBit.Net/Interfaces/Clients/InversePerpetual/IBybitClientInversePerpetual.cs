using CryptoExchange.Net.Interfaces;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IBybitClientInversePerpetual
    {
        /// <summary>
        /// Account
        /// </summary>
        IBybitClientInversePerpetualAccount Account { get; }

        /// <summary>
        /// Exc
        /// </summary>
        IBybitClientInversePerpetualExchangeData ExchangeData { get; }

        /// <summary>
        /// Tra
        /// </summary>
        IBybitClientInversePerpetualTrading Trading { get; }
    }
}