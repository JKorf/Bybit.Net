using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Trading type of option
    /// </summary>
    [JsonConverter(typeof(EnumConverter<OptionType>))]
    public enum OptionType
    {
        /// <summary>
        /// Call
        /// </summary>
        [Map("Call")]
        Call,
        /// <summary>
        /// Put
        /// </summary>
        [Map("Put")]
        Put
    }
}
