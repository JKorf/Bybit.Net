using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Oco trigger type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<OcoTriggerType>))]
    public enum OcoTriggerType
    {
        /// <summary>
        /// Trigger by unknown
        /// </summary>
        [Map("OcoTriggerByUnknown")]
        OcoTriggerByUnknown,
        /// <summary>
        /// Trigger by take profit
        /// </summary>
        [Map("OcoTriggerTp")]
        OcoTriggerTp,
        /// <summary>
        /// Trigger by stop loss
        /// </summary>
        [Map("OcoTriggerBySl")]
        OcoTriggerBySl
    }
}
