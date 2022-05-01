using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Order info
    /// </summary>
    public abstract class BybitOrder: BybitOrderBase
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("order_id")]
        public override string Id { get; set; } = string.Empty;
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("order_status"), JsonConverter(typeof(OrderStatusConverter))]
        public OrderStatus? Status { get; set; }
        /// <summary>
        /// Time of last fill
        /// </summary>
        [JsonProperty("last_exec_time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? LastTradeTime { get; set; }
        /// <summary>
        /// Price of last fill
        /// </summary>
        [JsonProperty("last_exec_price")]
        public decimal? LastTradePrice { get; set; }        
        /// <summary>
        /// Quote quantity filled
        /// </summary>
        public abstract decimal? QuoteQuantityFilled { get; set; }
        /// <summary>
        /// Base quantity filled
        /// </summary>
        public abstract decimal? BaseQuantityFilled { get; set; }
        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonProperty("cum_exec_fee")]
        public decimal? Fee { get; set; }
        /// <summary>
        /// Reason for reject
        /// </summary>
        [JsonProperty("reject_reason")]
        public string? RejectReason { get; set; }
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("order_link_id")]
        public string? ClientOrderId { get; set; }        
        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonProperty("take_profit")]
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonProperty("stop_loss")]
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// Take profit trigger type
        /// </summary>
        [JsonProperty("tp_trigger_by"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType? TakeProfitTriggerType { get; set; }
        /// <summary>
        /// Stop loss trigger type
        /// </summary>
        [JsonProperty("sl_trigger_by"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType? StopLossTriggerType { get; set; }
        /// <summary>
        /// True means close order, false means open position
        /// </summary>
        [JsonProperty("reduce_only")]
        public bool? ReduceOnly { get; set; }
        /// <summary>
        /// Is close on trigger order
        /// </summary>
        [JsonProperty("close_on_trigger")]
        public bool? CloseOnTrigger { get; set; }
    }

    /// <inheritdoc />
    public class BybitUsdPerpetualOrder : BybitOrder
    {
        /// <inheritdoc />
        [JsonProperty("cum_exec_value")]
        public override decimal? QuoteQuantityFilled { get; set; }

        /// <inheritdoc />
        [JsonProperty("cum_exec_qty")]
        public override decimal? BaseQuantityFilled { get; set; }
    }

    /// <inheritdoc />
    public class BybitInverseOrder : BybitOrder
    {
        /// <inheritdoc />
        [JsonProperty("cum_exec_qty")]
        public override decimal? QuoteQuantityFilled { get; set; }

        /// <inheritdoc />
        [JsonProperty("cum_exec_value")]
        public override decimal? BaseQuantityFilled { get; set; }
    }

}
