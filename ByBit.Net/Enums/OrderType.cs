using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Order type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<OrderType>))]
    public enum OrderType
    {
        /// <summary>
        /// Limit order. An order for a set (or better) price
        /// </summary>
        [Map("Limit", "LIMIT", "LIMIT_OF_QUOTE", "LIMIT_OF_BASE")]
        Limit,
        /// <summary>
        /// Market order. An order for the best price available upon placing
        /// </summary>
        [Map("Market", "MARKET", "MARKET_OF_QUOTE", "MARKET_OF_BASE")]
        Market,
        /// <summary>
        /// Limit maker order, only available for SPOT
        /// </summary>
        [Map("LIMIT_MAKER")]
        LimitMaker,
        /// <summary>
        /// Unknown order type
        /// </summary>
        [Map("UNKNOWN")]
        Unknown
    }
}
