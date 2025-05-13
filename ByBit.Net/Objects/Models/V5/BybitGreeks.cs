using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Greeks
    /// </summary>
    [SerializationModel]
    public record BybitGreeks
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Delta
        /// </summary>
        [JsonPropertyName("totalDelta")]
        public decimal TotalDelta { get; set; }
        /// <summary>
        /// Gamma
        /// </summary>
        [JsonPropertyName("totalGamma")]
        public decimal TotalGamma { get; set; }
        /// <summary>
        /// Vega
        /// </summary>
        [JsonPropertyName("totalVega")]
        public decimal TotalVega { get; set; }
        /// <summary>
        /// Theta
        /// </summary>
        [JsonPropertyName("totalTheta")]
        public decimal TotalTheta { get; set; }
    }
}
