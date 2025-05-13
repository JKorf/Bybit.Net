using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Product info
    /// </summary>
    [SerializationModel]
    public record BybitEarnProduct
    {
        /// <summary>
        /// Earn category
        /// </summary>
        [JsonPropertyName("category")]
        public EarnCategory Category { get; set; }
        /// <summary>
        /// Estimate APR
        /// </summary>
        [JsonPropertyName("estimateApr")]
        public string EstimateApr { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Min stake quantity
        /// </summary>
        [JsonPropertyName("minStakeAmount")]
        public decimal MinStakeQuantity { get; set; }
        /// <summary>
        /// Max stake quantity
        /// </summary>
        [JsonPropertyName("maxStakeAmount")]
        public decimal MaxStakeQuantity { get; set; }
        /// <summary>
        /// Precision
        /// </summary>
        [JsonPropertyName("precision")]
        public int Precision { get; set; }
        /// <summary>
        /// Product id
        /// </summary>
        [JsonPropertyName("productId")]
        public string ProductId { get; set; } = string.Empty;
        /// <summary>
        /// Earn product status
        /// </summary>
        [JsonPropertyName("status")]
        public EarnProductStatus Status { get; set; }
    }


}
