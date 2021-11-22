using CryptoExchange.Net.Interfaces;

namespace ByBit.Net.Clients.Rest.InversePerpetual
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IBybitClientInversePerpetual: IRestClient
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

        /// <summary>
        /// Set 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="apiSecret"></param>
        void SetApiCredentials(string apiKey, string apiSecret);
    }
}