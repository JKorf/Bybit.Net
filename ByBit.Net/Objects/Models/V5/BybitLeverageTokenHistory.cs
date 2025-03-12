using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Leverage token order record
    /// </summary>
    [SerializationModel]
    public record BybitLeverageTokenHistory
    {
        /// <summary>
        /// Token abbreviation
        /// </summary>
        [JsonPropertyName("ltCoin")]
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// Order status
        /// </summary>
        [JsonPropertyName("ltOrderStatus")]
        public LeverageTokenOrderStatus Status { get; set; }
        /// <summary>
        /// Order record type
        /// </summary>
        [JsonPropertyName("ltOrderType")]
        public LeverageTokenRecordType OrderType { get; set; }
        /// <summary>
        /// Filled value
        /// </summary>
        [JsonPropertyName("value")]
        public decimal? Value { get; set; }
        /// <summary>
        /// Filled quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string PurchaseId { get; set; } = string.Empty;
        /// <summary>
        /// Serial number
        /// </summary>
        [JsonPropertyName("serialNo")]
        public string? ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonPropertyName("valueCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("updateTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Order time
        /// </summary>
        [JsonPropertyName("orderTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Orderime { get; set; }
    }
}
