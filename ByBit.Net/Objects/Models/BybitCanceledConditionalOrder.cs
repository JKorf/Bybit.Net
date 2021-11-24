using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Canceled order info
    /// </summary>
    public class BybitCanceledConditionalOrder : BybitOrderBase
    {
        /// <summary>
        /// Cancel order id
        /// </summary>
        [JsonProperty("clOrdID")]
        public override string Id { get; set; } = string.Empty;
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("order_status"), JsonConverter(typeof(OrderStatusConverter))]
        public OrderStatus? Status { get; set; }
        /// <summary>
        /// The state of initiating a matchmaking request
        /// </summary>
        [JsonProperty("cross_status"), JsonConverter(typeof(StopOrderStatusConverter))]
        public StopOrderStatus CrossStatus { get; set; }
        /// <summary>
        /// Trigger scenario for single action
        /// </summary>
        [JsonProperty("create_type")]
        public string? CreateType { get; set; }
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonProperty("cross_seq")]
        public decimal CrossSequence { get; set; }
        /// <summary>
        /// Stop order type
        /// </summary>
        [JsonProperty("stop_order_type"), JsonConverter(typeof(StopOrderTypeConverter))]
        public StopOrderType StopOrderType { get; set; }
        /// <summary>
        /// Trigger type
        /// </summary>
        [JsonProperty("trigger_by"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType? TriggerType { get; set; }
        /// <summary>
        /// Base price
        /// </summary>
        [JsonProperty("base_price")]
        public decimal BasePrice { get; set; }
        /// <summary>
        /// Expected direction
        /// </summary>
        [JsonProperty("expected_direction")]
        public string? ExpectedDirection { get; set; }
    }
}
