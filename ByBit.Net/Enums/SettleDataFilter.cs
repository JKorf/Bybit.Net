using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum SettleDataFilter
    {
        /// <summary>
        /// Get all positions regardless zero or not based on settle coin
        /// </summary>
        [Map("full")]
        Full,
        /// <summary>
        /// Get valid positions based on settle coin
        /// </summary>
        [Map("valid")]
        Valid
    }
}
