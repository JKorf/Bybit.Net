using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket.Derivatives
{
    /// <summary>
    /// Kline update
    /// </summary>
    public class BybitDerivativesKlineUpdate : BybitKlineUpdate
    {
        /// <summary>
        /// Data refresh interval
        /// </summary>
        [JsonConverter(typeof(KlineIntervalConverter))]
        public KlineInterval Interval { get; set; }
    }
}
