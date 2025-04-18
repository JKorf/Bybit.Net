using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// StopLoss/TakeProfit mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter<StopLossTakeProfitMode>))]
    public enum StopLossTakeProfitMode
    {
        /// <summary>
        /// Full take profit/stop loss mode (a single TP order and a single SL order can be placed, covering the entire position)
        /// </summary>
        [Map("Full")]
        Full,
        /// <summary>
        /// Partial take profit/stop loss mode (multiple TP and SL orders can be placed, covering portions of the position)
        /// </summary>
        [Map("Partial")]
        Partial,
        /// <summary>
        /// Unknown, when placed on the website
        /// </summary>
        [Map("UNKNOWN")]
        Unknown
    }
}
