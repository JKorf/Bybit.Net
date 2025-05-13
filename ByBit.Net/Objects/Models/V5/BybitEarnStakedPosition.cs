using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Staked Earn position
    /// </summary>
    [SerializationModel]
    public record BybitEarnStakedPosition
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Product id
        /// </summary>
        [JsonPropertyName("productId")]
        public string ProductId { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Total pnl
        /// </summary>
        [JsonPropertyName("totalPnl")]
        public decimal TotalPnl { get; set; }
        /// <summary>
        /// Claimable yield
        /// </summary>
        [JsonPropertyName("claimableYield")]
        public decimal ClaimableYield { get; set; }
    }


}
