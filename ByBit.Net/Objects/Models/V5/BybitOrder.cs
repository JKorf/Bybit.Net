using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Order info
    /// </summary>
    [SerializationModel]
    public record BybitOrder
    {
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>orderLinkId</c>"] Client order id
        /// </summary>
        [JsonPropertyName("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// ["<c>parentOrderLinkId</c>"] Linked parent order for stop loss / take profit orders for futures/options orders 
        /// </summary>
        [JsonPropertyName("parentOrderLinkId")]
        public string? ParentOrderId { get; set; }
        /// <summary>
        /// ["<c>blockTradeId</c>"] Block trade id
        /// </summary>
        [JsonPropertyName("blockTradeId")]
        public string? BlockTradeId { get; set; }
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>price</c>"] Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// ["<c>qty</c>"] Quantity
        /// </summary>
        [JsonPropertyName("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>side</c>"] Order side
        /// </summary>

        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// ["<c>isLeverage</c>"] Is leverage order
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("isLeverage")]
        public bool? IsLeverage { get; set; }
        /// <summary>
        /// ["<c>positionIdx</c>"] Position mode
        /// </summary>
        [JsonPropertyName("positionIdx")]
        public PositionIdx? PositionIdx { get; set; }
        /// <summary>
        /// ["<c>orderStatus</c>"] Order status
        /// </summary>
        [JsonPropertyName("orderStatus")]

        public OrderStatus Status { get; set; }
        /// <summary>
        /// ["<c>cancelType</c>"] Cancel type
        /// </summary>

        [JsonPropertyName("cancelType")]
        public CancelType? CancelType { get; set; }
        /// <summary>
        /// ["<c>rejectReason</c>"] Reject reason
        /// </summary>
        [JsonPropertyName("rejectReason")]
        public string? RejectReason { get; set; }
        /// <summary>
        /// ["<c>avgPrice</c>"] Average fill pricec
        /// </summary>
        [JsonPropertyName("avgPrice")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// ["<c>leavesQty</c>"] Quantity open
        /// </summary>
        [JsonPropertyName("leavesQty")]
        public decimal? QuantityRemaining { get; set; }
        /// <summary>
        /// ["<c>leavesValue</c>"] Estimated value open
        /// </summary>
        [JsonPropertyName("leavesValue")]
        public decimal? ValueRemaining { get; set; }
        /// <summary>
        /// ["<c>cumExecQty</c>"] Quantity filled
        /// </summary>
        [JsonPropertyName("cumExecQty")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// ["<c>cumExecValue</c>"] Value filled
        /// </summary>
        [JsonPropertyName("cumExecValue")]
        public decimal? ValueFilled { get; set; }
        /// <summary>
        /// ["<c>cumExecFee</c>"] Fee paid for filled quantity
        /// </summary>
        [JsonPropertyName("cumExecFee")]
        public decimal? ExecutedFee { get; set; }
       /// <summary>
        /// ["<c>feeCurrency</c>"] Trading fee asset. for Spot only.
        /// </summary>
        [JsonPropertyName("feeCurrency")]
        public string? FeeAsset { get; set; }   
        /// <summary>
        /// ["<c>timeInForce</c>"] Time in force
        /// </summary>

        [JsonPropertyName("timeInForce")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// ["<c>orderType</c>"] Order type
        /// </summary>

        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// ["<c>stopOrderType</c>"] Stop order type
        /// </summary>

        [JsonPropertyName("stopOrderType")]
        public StopOrderType? StopOrderType { get; set; }
        /// <summary>
        /// ["<c>orderIv</c>"] Order Iv
        /// </summary>
        [JsonPropertyName("orderIv")]
        public decimal? OrderIv { get; set; }
        /// <summary>
        /// ["<c>triggerPrice</c>"] Trigger price
        /// </summary>
        [JsonPropertyName("triggerPrice")]
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// ["<c>takeProfit</c>"] Take profit
        /// </summary>
        [JsonPropertyName("takeProfit")]
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// ["<c>stopLoss</c>"] Stop loss
        /// </summary>
        [JsonPropertyName("stopLoss")]
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// ["<c>tpTriggerBy</c>"] Take profit trigger type
        /// </summary>
        [JsonPropertyName("tpTriggerBy")]

        public TriggerType? TakeProfitTriggerBy { get; set; }
        /// <summary>
        /// ["<c>slTriggerBy</c>"] Stop loss trigger type
        /// </summary>
        [JsonPropertyName("slTriggerBy")]

        public TriggerType? StopLossTriggerBy { get; set; }
        /// <summary>
        /// ["<c>triggerDirection</c>"] Trigger direction
        /// </summary>

        [JsonPropertyName("triggerDirection")]
        public TriggerDirection? TriggerDirection { get; set; }
        /// <summary>
        /// ["<c>triggerBy</c>"] Trigger price type
        /// </summary>

        [JsonPropertyName("triggerBy")]
        public TriggerType? TriggerBy { get; set; }
        /// <summary>
        /// ["<c>lastPriceOnCreated</c>"] Last price when the order was placed
        /// </summary>
        [JsonPropertyName("lastPriceOnCreated")]
        public decimal? LastPriceOnCreated { get; set; }
        /// <summary>
        /// ["<c>closeOnTrigger</c>"] Close on trigger
        /// </summary>
        [JsonPropertyName("closeOnTrigger")]
        public bool? CloseOnTrigger { get; set; }
        /// <summary>
        /// ["<c>reduceOnly</c>"] Reduce only
        /// </summary>
        [JsonPropertyName("reduceOnly")]
        public bool? ReduceOnly { get; set; }
        /// <summary>
        /// ["<c>createdTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>updatedTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("updatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// ["<c>createType</c>"] Order create type
        /// </summary>
        [JsonPropertyName("createType")]
        public string? CreateType { get; set; }
        /// <summary>
        /// ["<c>marketUnit</c>"] Market unit for quantity
        /// </summary>
        [JsonPropertyName("marketUnit")]
        public MarketUnit? MarketUnit { get; set; }
        /// <summary>
        /// ["<c>ocoTriggerType</c>"] Oco trigger type
        /// </summary>
        [JsonPropertyName("ocoTriggerType")]
        public OcoTriggerType? OcoTriggerType { get; set; }
        /// <summary>
        /// ["<c>tpLimitPrice</c>"] Take profit limit price
        /// </summary>
        [JsonPropertyName("tpLimitPrice")]
        public decimal? TakeProfitLimitPrice { get; set; }
        /// <summary>
        /// ["<c>slLimitPrice</c>"] Stop loss limit price
        /// </summary>
        [JsonPropertyName("slLimitPrice")]
        public decimal? StopLossLimitPrice { get; set; }

        /// <summary>
        /// ["<c>smpType</c>"] Self match prevention type
        /// </summary>
        [JsonPropertyName("smpType")]
        public SelfMatchPreventionType? SelfMatchPreventionType { get; set; }
        /// <summary>
        /// ["<c>smpGroup</c>"] Self match prevention group, 0 by default
        /// </summary>
        [JsonPropertyName("smpGroup")]
        public int? SelfMatchPreventionGroup { get; set; }
        /// <summary>
        /// ["<c>smpOrderId</c>"] The counterparty's orderID which triggers this SMP execution
        /// </summary>
        [JsonPropertyName("smpOrderId")]
        public string? SelfMatchPreventionOrderId { get; set; }
        /// <summary>
        /// ["<c>tpslMode</c>"] Take profit/stop loss mode
        /// </summary>

        [JsonPropertyName("tpslMode")]
        public StopLossTakeProfitMode? TpSlMode { get; set; }
        /// <summary>
        /// ["<c>placeType</c>"] Place type (option only)
        /// </summary>
        [JsonPropertyName("placeType")]
        public string? PlaceType { get; set; }
        /// <summary>
        /// ["<c>slippageToleranceType</c>"] Slippage tolerance types
        /// </summary>
        [JsonPropertyName("slippageToleranceType")]
        public SlippageToleranceType SlippageToleranceType { get; set; }
        /// <summary>
        /// ["<c>slippageTolerance</c>"] Slippage tolerance value
        /// </summary>
        [JsonPropertyName("slippageTolerance")]
        public decimal? SlippageTolerance { get; set; }
        /// <summary>
        /// ["<c>cumFeeDetail</c>"] Fee details
        /// </summary>
        [JsonPropertyName("cumFeeDetail")]
        public Dictionary<string, decimal> FeeDetails { get; set; } = new();
        /// <summary>
        /// ["<c>rpiTakerAccess</c>"] Whether the order has matched with an RPI order as the counterparty
        /// </summary>
        [JsonPropertyName("rpiTakerAccess")]
        public bool? RpiMatch { get; set; }
        /// <summary>
        /// ["<c>rpiMatchedQty</c>"] Cumulative quantity matched against RPI orders as the counterparty
        /// </summary>
        [JsonPropertyName("rpiMatchedQty")]
        public decimal? RpiMatchedQuantity { get; set; }
    }
}
