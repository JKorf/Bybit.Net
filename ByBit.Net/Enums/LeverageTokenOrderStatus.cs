using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Leverage token purchase status
    /// </summary>
    public enum LeverageTokenOrderStatus
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
        Failed,
    }
}
