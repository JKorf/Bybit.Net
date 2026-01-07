using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Position status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PositionStatus>))]
    public enum PositionStatus
    {
        /// <summary>
        /// Normal
        /// </summary>
        [Map("Normal")]
        Normal,
        /// <summary>
        /// Liquidation
        /// </summary>
        [Map("Liq")]
        Liquidation,
        /// <summary>
        /// Auto deleverage
        /// </summary>
        [Map("Adl")]
        AutoDeleverage,
        /// <summary>
        /// Inactive
        /// </summary>
        [Map("Inactive")]
        Inactive
    }
}
