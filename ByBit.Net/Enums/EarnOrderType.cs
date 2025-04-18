using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Earn order type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<EarnOrderType>))]
    public enum EarnOrderType
    {
        /// <summary>
        /// Stake
        /// </summary>
        [Map("Stake")]
        Stake,
        /// <summary>
        /// Redeem
        /// </summary>
        [Map("Redeem")]
        Redeem
    }
}
