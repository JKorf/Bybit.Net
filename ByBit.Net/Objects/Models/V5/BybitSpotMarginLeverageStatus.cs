using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Marging status and leverage info
    /// </summary>
    [SerializationModel]
    public record BybitSpotMarginLeverageStatus
    {
        /// <summary>
        /// The leverage
        /// </summary>
        [JsonPropertyName("spotLeverage")]
        public decimal? Leverage { get; set; }
        /// <summary>
        /// Is spot margin mode activated
        /// </summary>
        [JsonPropertyName("spotMarginMode"), JsonConverter(typeof(BoolConverter))]
        public bool SpotMarginMode { get; set; }
        /// <summary>
        /// Actual leverage ratio
        /// </summary>
        [JsonPropertyName("effectiveLeverage")]
        public decimal? EffectiveLeverage { get; set; }
    }
}
