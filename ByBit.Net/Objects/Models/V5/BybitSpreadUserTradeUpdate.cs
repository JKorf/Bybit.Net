using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Spread user trade update
    /// </summary>
    public record BybitSpreadUserTradeUpdate
    {
        /// <summary>
        /// Leg Category
        /// </summary>
        [JsonPropertyName("category")]
        public SpreadLegCategory SpreadLegCategory { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Closed quantity
        /// </summary>
        [JsonPropertyName("closedSize")]
        public decimal? ClosedQuantity { get; set; }
        /// <summary>
        /// Trade fee
        /// </summary>
        [JsonPropertyName("execFee")]
        public decimal? Fee { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("execId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Parent trade id
        /// </summary>
        [JsonPropertyName("parentExecId")]
        public string? ParentTradeId { get; set; }
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonPropertyName("execPrice")]
        public decimal TradePrice { get; set; }
        /// <summary>
        /// Traded quantity
        /// </summary>
        [JsonPropertyName("execQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonPropertyName("execType")]
        public TradeType TradeType { get; set; }
        /// <summary>
        /// Traded value
        /// </summary>
        [JsonPropertyName("execValue")]
        public decimal? Value { get; set; }
        /// <summary>
        /// Fee rate
        /// </summary>
        [JsonPropertyName("feeRate")]
        public decimal? FeeRate { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// Order quantity remaining
        /// </summary>
        [JsonPropertyName("leavesQty")]
        public decimal QuantityRemaining { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonPropertyName("orderPrice")]
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonPropertyName("orderQty")]
        public decimal OrderQuantity { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonPropertyName("execTime")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Is leverage
        /// </summary>
        [JsonPropertyName("isLeverage")]
        public bool? IsLeverage { get; set; }
        /// <summary>
        /// Is maker
        /// </summary>
        [JsonPropertyName("isMaker")]
        public bool IsMaker { get; set; }
        /// <summary>
        /// Sequence number
        /// </summary>
        [JsonPropertyName("seq")]
        public long Sequence { get; set; }
        /// <summary>
        /// Create type
        /// </summary>
        [JsonPropertyName("createType")]
        public string? CreateType { get; set; }
        /// <summary>
        /// Trade profit and loss
        /// </summary>
        [JsonPropertyName("execPnl")]
        public decimal? Pnl { get; set; }
    }


}
