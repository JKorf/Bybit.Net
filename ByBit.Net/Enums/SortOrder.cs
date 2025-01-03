using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Sort order
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// Searches in descending order
        /// </summary>
        [Map("desc")]
        Descending,
        /// <summary>
        /// Searched in ascending order
        /// </summary>
        [Map("asc")]
        Ascending
    }
}
