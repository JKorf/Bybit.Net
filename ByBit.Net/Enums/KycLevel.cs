using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// KnowYourCustomer level
    /// </summary>
    [JsonConverter(typeof(EnumConverter<KycLevel>))]
    public enum KycLevel
    {
        /// <summary>
        /// Default level
        /// </summary>
        [Map("LEVEL_DEFAULT")]
        Default,
        /// <summary>
        /// Level 1
        /// </summary>
        [Map("LEVEL_1")]
        Level1,
        /// <summary>
        /// Level 2
        /// </summary>
        [Map("LEVEL_2")]
        Level2
    }
}
