using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Trigger direction
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
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
