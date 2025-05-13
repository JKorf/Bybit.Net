using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Adjustment history
    /// </summary>
    [SerializationModel]
    public record BybitAdjustHistory
    {
        /// <summary>
        /// Adjust id
        /// </summary>
        [JsonPropertyName("adjustId")]
        public string AdjustId { get; set; } = string.Empty;
        /// <summary>
        /// Adjust time
        /// </summary>
        [JsonPropertyName("adjustTime")]
        public DateTime AdjustTime { get; set; }
        /// <summary>
        /// After LTV
        /// </summary>
        [JsonPropertyName("afterLTV")]
        public decimal AfterLtv { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Collateral asset
        /// </summary>
        [JsonPropertyName("collateralCurrency")]
        public string CollateralAsset { get; set; } = string.Empty;
        /// <summary>
        /// Adjustment direction
        /// </summary>
        [JsonPropertyName("direction")]
        public AdjustDirection AdjustDirection { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Pre LTV
        /// </summary>
        [JsonPropertyName("preLTV")]
        public decimal PreLtv { get; set; }
    }


}
