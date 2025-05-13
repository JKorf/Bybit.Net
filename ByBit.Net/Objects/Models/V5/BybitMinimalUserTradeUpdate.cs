using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Minimal user trade update
    /// </summary>
    [SerializationModel]
    public record BybitMinimalUserTradeUpdate
    {
        /// <summary>
        /// Category
        /// </summary>

        [JsonPropertyName("category")]
        public Category Category { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id trade belongs to
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id trade belongs to
        /// </summary>
        [JsonPropertyName("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Side
        /// </summary>

        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonPropertyName("orderPrice")]
        public decimal? OrderPrice { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("execId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Is maker trade
        /// </summary>
        [JsonPropertyName("isMaker")]
        public bool IsMaker { get; set; }
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonPropertyName("execPrice")]
        public decimal Price { get; set; }
        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonPropertyName("execQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("execTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Cross sequence, used to associate each fill and each position update
        /// </summary>
        [JsonPropertyName("seq")]
        public long? Sequence { get; set; }
    }
}
