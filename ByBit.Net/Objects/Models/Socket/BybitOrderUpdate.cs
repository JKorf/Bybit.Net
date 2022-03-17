using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// Order info
    /// </summary>
    public abstract class BybitOrderUpdate: BybitOrderBase
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("order_id")]
        public override string Id { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("order_link_id")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Create type
        /// </summary>
        [JsonProperty("create_type")]
        public string CreateType { get; set; } = string.Empty;
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("order_status"), JsonConverter(typeof(OrderStatusConverter))]
        public OrderStatus? Status { get; set; }
        /// <summary>
        /// Quote quantity filled
        /// </summary>
        [JsonProperty("cum_exec_value")]
        public abstract decimal? QuoteQuantityFilled { get; set; }
        /// <summary>
        /// Base quantity filled
        /// </summary>
        [JsonProperty("cum_exec_qty")]
        public abstract decimal? BaseQuantityFilled { get; set; }
        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonProperty("cum_exec_fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }
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
        /// Trailing stop
        /// </summary>
        [JsonProperty("trailing_stop")]
        public decimal? TrailingStop { get; set; }

        /// <summary>
        /// Trailing stop active price
        /// </summary>
        [JsonProperty("trailing_active")]
        public decimal? TrailingActive { get; set; }
        /// <summary>
        /// Price of last fill
        /// </summary>
        [JsonProperty("last_exec_price")]
        public decimal LastTradePrice { get; set; }
        /// <summary>
        /// True means your position can only reduce in size if this order is triggered
        /// </summary>
        [JsonProperty("reduce_only")]
        public bool ReduceOnly { get; set; }
        /// <summary>
        /// For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.
        /// </summary>
        [JsonProperty("close_on_trigger")]
        public bool CloseOnTrigger { get; set; }

        /// <summary>
        /// Position mode (only availaable on USD perpetual)
        /// </summary>
        [JsonConverter(typeof(PositionModeConverter))]
        [JsonProperty("position_idx")]
        public PositionMode? PositionMode { get; set; }
    }

    /// <inheritdoc />
    public class BybitUsdPerpetualOrderUpdate : BybitOrderUpdate
    {
        /// <inheritdoc />
        [JsonProperty("cum_exec_value")]
        public override decimal? QuoteQuantityFilled { get; set; }

        /// <inheritdoc />
        [JsonProperty("cum_exec_qty")]
        public override decimal? BaseQuantityFilled { get; set; }
    }

    /// <inheritdoc />
    public class BybitInverseOrderUpdate : BybitOrderUpdate
    {
        /// <inheritdoc />
        [JsonProperty("cum_exec_qty")]
        public override decimal? QuoteQuantityFilled { get; set; }

        /// <inheritdoc />
        [JsonProperty("cum_exec_value")]
        public override decimal? BaseQuantityFilled { get; set; }
    }
}
