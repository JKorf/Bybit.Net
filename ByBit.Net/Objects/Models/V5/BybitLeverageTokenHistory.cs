using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Leverage token order record
    /// </summary>
    public class BybitLeverageTokenHistory
    {
        /// <summary>
        /// Token abbreviation
        /// </summary>
        [JsonProperty("ltCoin")]
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("ltOrderStatus"), JsonConverter(typeof(EnumConverter))]
        public LeverageTokenOrderStatus Status { get; set; }
        /// <summary>
        /// Order record type
        /// </summary>
        [JsonProperty("ltOrderType"), JsonConverter(typeof(EnumConverter))]
        public LeverageTokenRecordType OrderType { get; set; }
        /// <summary>
        /// Filled value
        /// </summary>
        [JsonProperty("value")]
        public decimal? Value { get; set; }
        /// <summary>
        /// Filled quantity
        /// </summary>
        [JsonProperty("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public string PurchaseId { get; set; } = string.Empty;
        /// <summary>
        /// Serial number
        /// </summary>
        [JsonProperty("serialNo")]
        public string? ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonProperty("valueCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Fee
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updateTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Order time
        /// </summary>
        [JsonProperty("orderTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Orderime { get; set; }
    }
}
