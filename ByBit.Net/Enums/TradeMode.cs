using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Trigger direction
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TradeMode>))]
    public enum TradeMode
    {
        /// <summary>
        /// Cross margin mode
        /// </summary>
        [Map("0")]
        CrossMargin,
        /// <summary>
        /// Isolated mode
        /// </summary>
        [Map("1")]
        Isolated
    }
}
