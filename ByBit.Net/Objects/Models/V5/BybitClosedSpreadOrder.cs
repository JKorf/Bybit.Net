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
    /// Spread order history
    /// </summary>
    public record BybitClosedSpreadOrder
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Contract type
        /// </summary>
        [JsonPropertyName("contractType")]
        public SpreadContractType SpreadContractType { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonPropertyName("orderStatus")]
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("createdAt")]
        public decimal CreateTime { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Leg2 symbol
        /// </summary>
        [JsonPropertyName("leg2Symbol")]
        public string Leg2Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonPropertyName("orderQty")]
        public decimal OrderQuantity { get; set; }
        /// <summary>
        /// Reject reason
        /// </summary>
        [JsonPropertyName("cxlRejReason")]
        public string? RejectReason { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonPropertyName("timeInForce")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public decimal UpdateTime { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide OrderSide { get; set; }
        /// <summary>
        /// Leg 2 side
        /// </summary>
        [JsonPropertyName("leg2Side")]
        public OrderSide? Leg2Side { get; set; }
        /// <summary>
        /// Quantity remaining
        /// </summary>
        [JsonPropertyName("leavesQty")]
        public decimal QuantityRemaining { get; set; }
        /// <summary>
        /// Leg 1 side
        /// </summary>
        [JsonPropertyName("leg1Side")]
        public OrderSide? Leg1Side { get; set; }
        /// <summary>
        /// Settle asset
        /// </summary>
        [JsonPropertyName("settleCoin")]
        public string SettleAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonPropertyName("cumExecQty")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Leg 1 order id
        /// </summary>
        [JsonPropertyName("leg1OrderId")]
        public string Leg1OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Leg 2 order id
        /// </summary>
        [JsonPropertyName("leg2OrderId")]
        public string Leg2OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Leg 2 product type
        /// </summary>
        [JsonPropertyName("leg2ProdType")]
        public SpreadProductType Leg2ProductType { get; set; }
        /// <summary>
        /// Leg1 product type
        /// </summary>
        [JsonPropertyName("leg1ProdType")]
        public SpreadProductType Leg1ProductType { get; set; }
        /// <summary>
        /// Leg1 symbol
        /// </summary>
        [JsonPropertyName("leg1Symbol")]
        public string Leg1Symbol { get; set; } = string.Empty;
    }


}
