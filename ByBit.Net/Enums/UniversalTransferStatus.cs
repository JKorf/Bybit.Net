using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Transfer status
    /// </summary>
    public enum UniversalTransferStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        [Map("Success")]
        Success,
        /// <summary>
        /// Pending
        /// </summary>
        [Map("Pending")]
        Pending,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("Failed")]
        Failed
    }
}
