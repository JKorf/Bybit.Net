using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Side of a position
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PositionSide>))]
    public enum PositionSide
    {
        /// <summary>
        /// Buy
        /// </summary>
        [Map("Buy")]
        Buy,
        /// <summary>
        /// Sell
        /// </summary>
        [Map("Sell")]
        Sell,
        /// <summary>
        /// None
        /// </summary>
        [Map("None")]
        None
    }
}
