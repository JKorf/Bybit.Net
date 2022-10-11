using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Conditional order info
    /// </summary>
    public class BybitConditionalOrder: BybitOrderBase
    {
        /// <summary>
        /// Stop order id
        /// </summary>
        [JsonProperty("stop_order_id")]
        public override string Id { get; set; } = string.Empty;
        [JsonProperty("order_id")]
        internal string? _stopId { get => Id; set { if (value != null) Id = value; } }
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("order_link_id")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        public string? Remark { get; set; }
        /// <summary>
        /// Stop price
        /// </summary>
        [JsonProperty("stop_px")]
        public decimal StopPrice { get; set; }
        /// <summary>
        /// Base price
        /// </summary>
        [JsonProperty("base_price")]
        public decimal BasePrice { get; set; }
        /// <summary>
        /// Reason for reject
        /// </summary>
        [JsonProperty("reject_reason")]
        public string? RejectReason { get; set; }
        /// <summary>
        /// Type of the stop order
        /// </summary>
        [JsonProperty("stop_order_type"), JsonConverter(typeof(StopOrderTypeConverter))]
        public StopOrderType? StopOrderType { get; set; }

        /// <summary>
        /// Stop order status
        /// </summary>
        [JsonProperty("stop_order_status"), JsonConverter(typeof(StopOrderStatusConverter))]
        public StopOrderStatus Status { get; set; }
        [JsonProperty("order_status"), JsonConverter(typeof(StopOrderStatusConverter))]
        internal StopOrderStatus? _status { get => Status; set { if (value != null) Status = value.Value; } }

        /// <summary>
        /// Quote quantity filled
        /// </summary>
        [JsonProperty("cum_exec_qty")]
        public decimal QuoteQuantityFilled { get; set; }
        /// <summary>
        /// Base quantity filled
        /// </summary>
        [JsonProperty("cum_exec_value")]
        public decimal? BaseQuantityFilled { get; set; }
        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonProperty("cum_exec_fee")]
        public decimal? Fee { get; set; }

        /// <summary>
        /// Trigger type
        /// </summary>
        [JsonProperty("trigger_by"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType? TriggerType { get; set; }
        /// <summary>
        /// Trigger type for take profit
        /// </summary>
        [JsonProperty("tp_trigger_by"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType? TakeProfitTriggerType { get; set; }
        /// <summary>
        /// Trigger type for stop loss
        /// </summary>
        [JsonProperty("sl_trigger_by"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType? StopLossTriggerType { get; set; }

        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonProperty("take_profit")]
        public decimal? TakeProfitPrice { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonProperty("stop_loss")]
        public decimal? StopLossPrice { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonProperty("trigger_price")]
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// Reduce only
        /// </summary>
        [JsonProperty("reduce_only")]
        public bool ReduceOnly { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonProperty("position_idx")]
        [JsonConverter(typeof(PositionModeConverter))]
        public PositionMode? PositionMode { get; set; }
    }
}
