using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Order type
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// Limit order. An order for a set (or better) price
        /// </summary>
        [Map("Limit")]
        Limit,
        /// <summary>
        /// Market order. An order for the best price available upon placing
        /// </summary>
        [Map("Market")]
        Market,
        /// <summary>
        /// Limit maker order, only available for SPOT
        /// </summary>
        LimitMaker
    }
}
