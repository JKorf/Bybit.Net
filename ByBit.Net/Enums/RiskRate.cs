using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Order status
    /// </summary>
    public enum RiskRate
    {
        /// <summary>
        /// Completed
        /// </summary>
        [Map("1")]
        Completed,
        /// <summary>
        /// In progress
        /// </summary>
        [Map("2")]
        InProgress,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("3")]
        Failed
    }
}
