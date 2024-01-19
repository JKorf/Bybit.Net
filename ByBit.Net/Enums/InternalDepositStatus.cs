using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Internal deposit status
    /// </summary>
    public enum InternalDepositStatus
    {
        /// <summary>
        /// Processing
        /// </summary>
        [Map("1")]
        Processing,
        /// <summary>
        /// Success
        /// </summary>
        [Map("2")]
        Succes,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("3")]
        Failed
    }
}
