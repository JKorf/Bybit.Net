using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Earn category
    /// </summary>
    [JsonConverter(typeof(EnumConverter<EarnCategory>))]
    public enum EarnCategory
    {
        /// <summary>
        /// Flexible saving
        /// </summary>
        [Map("FlexibleSaving")]
        FlexibleSaving,
        /// <summary>
        /// On chain
        /// </summary>
        [Map("OnChain")]
        OnChain
    }
}
