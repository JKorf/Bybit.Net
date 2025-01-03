using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Search direction
    /// </summary>
    public enum SearchDirection
    {
        /// <summary>
        /// Searches in ascending order
        /// </summary>
        [Map("prev")]
        Previous,
        /// <summary>
        /// Searched in descending order
        /// </summary>
        [Map("next")]
        Next
    }
}
