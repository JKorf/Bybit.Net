using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Order info
    /// </summary>
    public class BybitOrder
    {
        /// <summary>
        /// Order id
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Block trade id
        /// </summary>
        public string? BlockTradeId { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Price
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Is leverage order
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool? IsLeverage { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonProperty("positionIdx")]
        public PositionMode? PositionMode { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("orderStatus")]
        [JsonConverter(typeof(EnumConverter))]
        public Enums.V5.OrderStatus Status { get; set; }
        /// <summary>
        /// Cancel type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public CancelType? CancelType { get; set; }
        /// <summary>
        /// Reject reason
        /// </summary>
        public string? RejectReason { get; set; } 
        /// <summary>
        /// Average fill pricec
        /// </summary>
        [JsonProperty("avgPrice")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// Quantity open
        /// </summary>
        [JsonProperty("leavesQty")]
        public decimal? QuantityRemaining { get; set; }
        /// <summary>
        /// Estimated value open
        /// </summary>
        [JsonProperty("leavesValue")]
        public decimal? ValueRemaining { get; set; }
        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonProperty("cumExecQty")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// Value filled
        /// </summary>
        [JsonProperty("cumExecValue")]
        public decimal? ValueFilled { get; set; }
        /// <summary>
        /// Fee paid for filled quantity
        /// </summary>
        [JsonProperty("cumExecFee")]
        public decimal? ExecutedFee { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Stop order type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public StopOrderType? StopOrderType { get; set; }
        /// <summary>
        /// Order Iv
        /// </summary>
        public decimal? OrderIv { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// Take profit
        /// </summary>
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// Stop loss
        /// </summary>
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// Take profit trigger type
        /// </summary>
        [JsonProperty("tpTriggerBy")]
        [JsonConverter(typeof(EnumConverter))]
        public TriggerType? TakeProfitTriggerBy { get; set; }
        /// <summary>
        /// Stop loss trigger type
        /// </summary>
        [JsonProperty("slTriggerBy")]
        [JsonConverter(typeof(EnumConverter))]
        public TriggerType? StopLossTriggerBy { get; set; }
        /// <summary>
        /// Trigger direction
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public TriggerDirection? TriggerDirection { get; set; }
        /// <summary>
        /// Trigger price type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public TriggerType? TriggerBy { get; set; }
        /// <summary>
        /// Last price when the order was placed
        /// </summary>
        public decimal? LastPriceOnCreated { get; set; }
        /// <summary>
        /// Close on trigger
        /// </summary>
        public bool? CloseOnTrigger { get; set; }
        /// <summary>
        /// Reduce only
        /// </summary>
        public bool? ReduceOnly { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
    }
}
