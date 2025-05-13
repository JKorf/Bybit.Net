using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Trigger direction
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TriggerDirection>))]
    public enum TriggerDirection
    {
        /// <summary>
        /// Market price rises to triggerPrice
        /// </summary>
        [Map("1")]
        Rise = 1,
        /// <summary>
        /// Market price falls to triggerPrice
        /// </summary>
        [Map("2")]
        Fall = 2
    }
}
