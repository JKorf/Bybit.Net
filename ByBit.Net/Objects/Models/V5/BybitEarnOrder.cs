using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Earn order info
    /// </summary>
    [SerializationModel]
    public record BybitEarnOrder
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Order value
        /// </summary>
        [JsonPropertyName("orderValue")]
        public decimal OrderValue { get; set; }
        /// <summary>
        /// Earn order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public EarnOrderType OrderType { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Order link id
        /// </summary>
        [JsonPropertyName("orderLinkId")]
        public string OrderLinkId { get; set; } = string.Empty;
        /// <summary>
        /// Earn status
        /// </summary>
        [JsonPropertyName("status")]
        public EarnOrderStatus Status { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Product id
        /// </summary>
        [JsonPropertyName("productId")]
        public string ProductId { get; set; } = string.Empty;
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public DateTime? UpdateTime { get; set; }
    }


}
