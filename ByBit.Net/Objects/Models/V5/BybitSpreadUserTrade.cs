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
    /// Spread user trade info
    /// </summary>
    public record BybitSpreadUserTrade
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide OrderSide { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonPropertyName("execPrice")]
        public decimal Price { get; set; }
        /// <summary>
        /// Legs
        /// </summary>
        [JsonPropertyName("legs")]
        public BybitSpreadUserTradeLeg[] Legs { get; set; } = [];
        /// <summary>
        /// Trade time
        /// </summary>
        [JsonPropertyName("execTime")]
        public DateTime TradeTime { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonPropertyName("execType")]
        public TradeType TradeType { get; set; }
        /// <summary>
        /// Traded quantity
        /// </summary>
        [JsonPropertyName("execQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("execId")]
        public string TradeId { get; set; } = string.Empty;
    }

    /// <summary>
    /// User trade leg
    /// </summary>
    public record BybitSpreadUserTradeLeg
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide OrderSide { get; set; }
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonPropertyName("execPrice")]
        public decimal Price { get; set; }
        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonPropertyName("execTime")]
        public DateTime TradeTime { get; set; }
        /// <summary>
        /// Traded value
        /// </summary>
        [JsonPropertyName("execValue")]
        public decimal Value { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonPropertyName("execType")]
        public TradeType TradeType { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;
        /// <summary>
        /// Traded quantity
        /// </summary>
        [JsonPropertyName("execQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade fee
        /// </summary>
        [JsonPropertyName("execFee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Trade fee
        /// </summary>
        [JsonPropertyName("execFeeV2")]
        public decimal FeeV2 { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonPropertyName("feeCurrency")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("execId")]
        public string TradeId { get; set; } = string.Empty;
    }


}
