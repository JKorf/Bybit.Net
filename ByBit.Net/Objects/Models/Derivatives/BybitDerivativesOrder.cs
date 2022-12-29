using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Order
    /// </summary>
    public abstract class BybitDerivativesOrder
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Block trade id
        /// </summary>
        public string? BlockTradeId { get; set; } = string.Empty;

        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("orderType"), JsonConverter(typeof(OrderTypeConverter))]
        public OrderType Type { get; set; }

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
        /// True means close order, false means open position
        /// </summary>
        public bool? ReduceOnly { get; set; }

        /// <summary>
        /// Time in force
        /// </summary>
        [JsonConverter(typeof(TimeInForceConverter))]
        public TimeInForce TimeInForce { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("orderStatus"), JsonConverter(typeof(OrderStatusConverter))]
        public OrderStatus? Status { get; set; }

        /// <summary>
        /// Estimated value of the corresponding remaining maker order quantity
        /// </summary>
        public decimal? LeavesValue { get; set; }
        /// <summary>
        /// Remaining order quantity
        /// </summary>
        [JsonProperty("leavesQty")]
        public decimal? LeavesQuantity { get; set; }

        /// <summary>
        /// Accumulative trading volume
        /// </summary>
        [JsonProperty("cumExecQty")]
        public decimal? AccumulativeTradingVolume { get; set; }

        /// <summary>
        /// Accumulative trading value
        /// </summary>
        [JsonProperty("cumExecValue")]
        public decimal? AccumulativeTradingValue { get; set; }

        /// <summary>
        /// Accumulative trading fees
        /// </summary>
        [JsonProperty("cumExecFee")]
        public decimal? AccumulativeTradingFee { get; set; }

        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string? ClientOrderId { get; set; }

        /// <summary>
        /// Reason for reject
        /// </summary>
        public string? RejectReason { get; set; }

        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("createdTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updatedTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// Take profit price
        /// </summary>
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// If the stop_order_type is TrailingProfit, it is the activation price, otherwise, it is the trigger price
        /// </summary>
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// Take profit trigger type
        /// </summary>
        [JsonProperty("tpTriggerBy"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType? TakeProfitTriggerType { get; set; }
        /// <summary>
        /// Stop loss trigger type
        /// </summary>
        [JsonProperty("slTriggerBy"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType? StopLossTriggerType { get; set; }

        /// <summary>
        /// Trigger type
        /// </summary>
        [JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType? TriggerBy { get; set; }

        /// <summary>
        /// Is close on trigger order
        /// </summary>
        public bool? CloseOnTrigger { get; set; }

        /// <summary>
        /// Conditional order type
        /// </summary>
        [JsonProperty("stopOrderType"), JsonConverter(typeof(StopOrderTypeConverter))]
        public StopOrderType? ConditionalOrderType { get; set; }
    }
}
