using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Tp/Sl mode
    /// </summary>
    public class BybitTakeProfitStopLossMode
    {
        /// <summary>
        /// Tpsl mode
        /// </summary>
        [JsonProperty("tpSlMode")]
        [JsonConverter(typeof(EnumConverter))]
        public StopLossTakeProfitMode TakeProfitStopLossMode { get; set; }
    }
}
