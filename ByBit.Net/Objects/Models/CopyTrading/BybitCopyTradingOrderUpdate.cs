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
    public class BybitCopyTradingOrderUpdate
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
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonConverter(typeof(OrderTypeConverter))]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Copy trade order status
        /// </summary>
        public string CopyTradeOrderStatus { get; set; } = string.Empty;
        /// <summary>
        /// Order price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Transaction quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Executed quantity
        /// </summary>
        [JsonProperty("cumExecQty")]
        public decimal QuantityExecuted { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonConverter(typeof(TimeInForceConverter))]
        public TimeInForce TimeInForce { get; set; }
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
        /// <summary>
        /// Last executed fill price
        /// </summary>
        [JsonProperty("lastExecPrice")]
        public decimal LastFillPrice { get; set; }
        /// <summary>
        /// Last executed fill price
        /// </summary>
        [JsonProperty("positionIdx")]
        [JsonConverter(typeof(PositionModeConverter))]
        public PositionMode PositionMode { get; set; }
    }
}
