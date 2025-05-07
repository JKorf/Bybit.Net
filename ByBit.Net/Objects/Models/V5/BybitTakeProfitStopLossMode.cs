using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Tp/Sl mode
    /// </summary>
    [SerializationModel]
    public record BybitTakeProfitStopLossMode
    {
        /// <summary>
        /// Tpsl mode
        /// </summary>
        [JsonPropertyName("tpSlMode")]

        public StopLossTakeProfitMode TakeProfitStopLossMode { get; set; }
    }
}
