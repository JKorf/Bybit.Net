using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.CopyTrading
{
    /// <summary>
    /// Copy trading order info
    /// </summary>
    public class BybitCopyTradingOrder
    {
        /// <summary>
        /// Order id
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Copy trade order status
        /// </summary>
        public string CopyTradeOrderStatus { get; set; } = string.Empty;
        /// <summary>
        /// Order price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonConverter(typeof(TimeInForceConverter))]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Remaining quantity
        /// </summary>
        [JsonProperty("leavesQty")]
        public decimal QuanitityRemaining { get; set; }
        /// <summary>
        /// Is isolated
        /// </summary>
        public bool IsIsolated { get; set; }
        /// <summary>
        /// Remaining value
        /// </summary>
        [JsonProperty("leavesValue")]
        public decimal ValueRemaining { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        public decimal Leverage { get; set; }
        /// <summary>
        /// Value filled
        /// </summary>
        [JsonProperty("cumExecValue")]
        public decimal ValueFilled { get; set; }
        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonProperty("cumExecFee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Creation time of the order
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("createdTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("updatedTime")]
        public DateTime UpdateTime { get; set; }
    }
}
