using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Set risk limit info
    /// </summary>
    [SerializationModel]
    public record BybitSetRiskLimit
    {
        /// <summary>
        /// The risk id
        /// </summary>
        [JsonPropertyName("riskId")]
        public int RiskId { get; set; }
        /// <summary>
        /// Risk limit value
        /// </summary>
        [JsonPropertyName("riskLimitValue")]
        public decimal RiskLimitValue { get; set; }
        /// <summary>
        /// Category
        /// </summary>

        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
