using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Minimal user trade update
    /// </summary>
    public record BybitMinimalUserTradeUpdate
    {
        /// <summary>
        /// Category
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public Category Category { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id trade belongs to
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id trade belongs to
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        public decimal? OrderPrice { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("execId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Is maker trade
        /// </summary>
        [JsonProperty("isMaker")]
        public bool IsMaker { get; set; }
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonProperty("execPrice")]
        public decimal Price { get; set; }
        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonProperty("execQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("execTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Cross sequence, used to associate each fill and each position update
        /// </summary>
        [JsonProperty("seq")]
        public long? Sequence { get; set; }
    }
}
