using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Borrow status
    /// </summary>
    public enum BorrowStatus
    {
        /// <summary>
        /// Total
        /// </summary>
        [Map("0")]
        Total,
        /// <summary>
        /// Cleared
        /// </summary>
        [Map("1")]
        Cleared,
        /// <summary>
        /// Not cleared
        /// </summary>
        [Map("2")]
        NotCleared
    }
}
