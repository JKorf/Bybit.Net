using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Trigger direction
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
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
