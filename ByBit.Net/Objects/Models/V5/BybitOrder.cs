using Bybit.Net.Enums;
using Bybit.Net.Enums.V5;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Order info
    /// </summary>
    public record BybitOrder
    {
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
        /// Block trade id
        /// </summary>
        [JsonPropertyName("blockTradeId")]
        public string? BlockTradeId { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Is leverage order
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("isLeverage")]
        public bool? IsLeverage { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonPropertyName("positionIdx")]
        public PositionIdx? PositionIdx { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonPropertyName("orderStatus")]
        [JsonConverter(typeof(EnumConverter))]
        public Enums.V5.OrderStatus Status { get; set; }
        /// <summary>
        /// Cancel type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("cancelType")]
        public CancelType? CancelType { get; set; }
        /// <summary>
        /// Reject reason
        /// </summary>
        [JsonPropertyName("rejectReason")]
        public string? RejectReason { get; set; }
        /// <summary>
        /// Average fill pricec
        /// </summary>
        [JsonPropertyName("avgPrice")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// Quantity open
        /// </summary>
        [JsonPropertyName("leavesQty")]
        public decimal? QuantityRemaining { get; set; }
        /// <summary>
        /// Estimated value open
        /// </summary>
        [JsonPropertyName("leavesValue")]
        public decimal? ValueRemaining { get; set; }
        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonPropertyName("cumExecQty")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// Value filled
        /// </summary>
        [JsonPropertyName("cumExecValue")]
        public decimal? ValueFilled { get; set; }
        /// <summary>
        /// Fee paid for filled quantity
        /// </summary>
        [JsonPropertyName("cumExecFee")]
        public decimal? ExecutedFee { get; set; }
       /// <summary>
        /// Trading fee asset. for Spot only.
        /// </summary>
        [JsonPropertyName("feeCurrency")]
        public string? FeeAsset { get; set; }   
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("timeInForce")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Stop order type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("stopOrderType")]
        public StopOrderType? StopOrderType { get; set; }
        /// <summary>
        /// Order Iv
        /// </summary>
        [JsonPropertyName("orderIv")]
        public decimal? OrderIv { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonPropertyName("triggerPrice")]
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// Take profit
        /// </summary>
        [JsonPropertyName("takeProfit")]
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// Stop loss
        /// </summary>
        [JsonPropertyName("stopLoss")]
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// Take profit trigger type
        /// </summary>
        [JsonPropertyName("tpTriggerBy")]
        [JsonConverter(typeof(EnumConverter))]
        public TriggerType? TakeProfitTriggerBy { get; set; }
        /// <summary>
        /// Stop loss trigger type
        /// </summary>
        [JsonPropertyName("slTriggerBy")]
        [JsonConverter(typeof(EnumConverter))]
        public TriggerType? StopLossTriggerBy { get; set; }
        /// <summary>
        /// Trigger direction
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("triggerDirection")]
        public TriggerDirection? TriggerDirection { get; set; }
        /// <summary>
        /// Trigger price type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("triggerBy")]
        public TriggerType? TriggerBy { get; set; }
        /// <summary>
        /// Last price when the order was placed
        /// </summary>
        [JsonPropertyName("lastPriceOnCreated")]
        public decimal? LastPriceOnCreated { get; set; }
        /// <summary>
        /// Close on trigger
        /// </summary>
        [JsonPropertyName("closeOnTrigger")]
        public bool? CloseOnTrigger { get; set; }
        /// <summary>
        /// Reduce only
        /// </summary>
        [JsonPropertyName("reduceOnly")]
        public bool? ReduceOnly { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("updatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Order create type
        /// </summary>
        [JsonPropertyName("createType")]
        public string? CreateType { get; set; }
        /// <summary>
        /// Market unit for quantity
        /// </summary>
        [JsonPropertyName("marketUnit"), JsonConverter(typeof(EnumConverter))]
        public MarketUnit? MarketUnit { get; set; }
        /// <summary>
        /// Oco trigger type
        /// </summary>
        [JsonPropertyName("ocoTriggerType"), JsonConverter(typeof(EnumConverter))]
        public OcoTriggerType? OcoTriggerType { get; set; }
        /// <summary>
        /// Take profit limit price
        /// </summary>
        [JsonPropertyName("tpLimitPrice")]
        public decimal? TakeProfitLimitPrice { get; set; }
        /// <summary>
        /// Stop loss limit price
        /// </summary>
        [JsonPropertyName("slLimitPrice")]
        public decimal? StopLossLimitPrice { get; set; }

        /// <summary>
        /// Self match prevention type
        /// </summary>
        [JsonPropertyName("smpType"), JsonConverter(typeof(EnumConverter))]
        public SelfMatchPreventionType? SelfMatchPreventionType { get; set; }
        /// <summary>
        /// Self match prevention group, 0 by default
        /// </summary>
        [JsonPropertyName("smpGroup")]
        public int? SelfMatchPreventionGroup { get; set; }
        /// <summary>
        /// The counterparty's orderID which triggers this SMP execution
        /// </summary>
        [JsonPropertyName("smpOrderId")]
        public string? SelfMatchPreventionOrderId { get; set; }
        /// <summary>
        /// Take profit/stop loss mode
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("tpslMode")]
        public StopLossTakeProfitMode? TpSlMode { get; set; }
        /// <summary>
        /// Place type (option only)
        /// </summary>
        [JsonPropertyName("placeType")]
        public string? PlaceType { get; set; }
    }
}
