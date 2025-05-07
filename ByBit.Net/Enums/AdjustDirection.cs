using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Adjust direction
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AdjustDirection>))]
    public enum AdjustDirection
    {
        /// <summary>
        /// Add
        /// </summary>
        [Map("0")]
        Add,
        /// <summary>
        /// Reduce
        /// </summary>
        [Map("1")]
        Reduce
    }
}
