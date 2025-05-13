using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Risk limit info
    /// </summary>
    [SerializationModel]
    public record BybitRiskLimit
    {
        /// <summary>
        /// Risk limit id
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Risk limit value
        /// </summary>
        [JsonPropertyName("riskLimitValue")]
        public decimal RiskLimitValue { get; set; }
        /// <summary>
        /// Maintenance margin
        /// </summary>
        [JsonPropertyName("maintenanceMargin")]
        public decimal MaintenanceMargin { get; set; }
        /// <summary>
        /// Initial margin
        /// </summary>
        [JsonPropertyName("initialMargin")]
        public decimal InitialMargin { get; set; }
        /// <summary>
        /// Is lowest risk
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("isLowestRisk")]
        public bool IsLowestRisk { get; set; }
        /// <summary>
        /// Max leverage
        /// </summary>
        [JsonPropertyName("maxLeverage")]
        public decimal MaxLeverage { get; set; }

        /// <summary>
        /// Maintenance Margin Deduction
        /// </summary>
        [JsonPropertyName("mmDeduction")]
        public decimal? MaintenanceMarginDeduction { get; set; }
    }
}
