using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Type of trigger
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TriggerType>))]
    public enum TriggerType
    {
        /// <summary>
        /// Last trade price
        /// </summary>
        [Map("LastPrice")]
        LastPrice,
        /// <summary>
        /// Index price
        /// </summary>
        [Map("IndexPrice")]
        IndexPrice,
        /// <summary>
        /// Mark price
        /// </summary>
        [Map("MarkPrice")]
        MarkPrice,
        /// <summary>
        /// Unknown
        /// </summary>
        [Map("UNKNOWN", "0")]
        Unknown
    }
}
