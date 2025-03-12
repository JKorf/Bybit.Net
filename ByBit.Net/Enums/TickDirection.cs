using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Tick direction
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TickDirection>))]
    public enum TickDirection
    {
        /// <summary>
        /// Price rise tick
        /// </summary>
        [Map("PlusTick")]
        PlusTick,
        /// <summary>
        /// Trade occurs at the same price as the previous trade, which occurred at a price higher than that for the trade preceding it
        /// </summary>
        [Map("ZeroPlusTick")]
        ZeroPlusTick,
        /// <summary>
        /// Price drop tick
        /// </summary>
        [Map("MinusTick")]
        MinusTick,
        /// <summary>
        /// Trade occurs at the same price as the previous trade, which occurred at a price lower than that for the trade preceding it
        /// </summary>
        [Map("ZeroMinusTick")]
        ZeroMinusTick
    }
}
