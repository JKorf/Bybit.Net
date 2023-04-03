using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Order type for new orders
    /// </summary>
    public enum NewOrderType
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
        Market
    }
}
