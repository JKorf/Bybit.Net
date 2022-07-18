using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Borrow type
    /// </summary>
    public enum BorrowType
    {
        /// <summary>
        /// Manual
        /// </summary>
        [Map("1")]
        Manual,
        /// <summary>
        /// Auto
        /// </summary>
        [Map("2")]
        Auto
    }
}
