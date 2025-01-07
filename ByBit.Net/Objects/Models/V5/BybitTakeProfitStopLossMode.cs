using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Tp/Sl mode
    /// </summary>
    public record BybitTakeProfitStopLossMode
    {
        /// <summary>
        /// Tpsl mode
        /// </summary>
        [JsonPropertyName("tpSlMode")]
        [JsonConverter(typeof(EnumConverter))]
        public StopLossTakeProfitMode TakeProfitStopLossMode { get; set; }
    }
}
