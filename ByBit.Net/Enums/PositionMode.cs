using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Position mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter<PositionMode>))]
    public enum PositionMode
    {
        /// <summary>
        /// Merge single
        /// </summary>
        [Map("0")]
        MergedSingle,
        /// <summary>
        /// Both sides
        /// </summary>
        [Map("3")]
        BothSides
    }
}
