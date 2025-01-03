using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Set risk limit info
    /// </summary>
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
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
