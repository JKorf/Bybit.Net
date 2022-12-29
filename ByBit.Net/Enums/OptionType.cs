using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Trading type of option
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
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
