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
    public class BybitOrder: BybitOrderBase
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("order_id")]
        public string Id { get; set; } = string.Empty;        
        /// <summary>
        /// Time of last fill
        /// </summary>
        [JsonProperty("last_exec_time"), JsonConverter(typeof(TimestampSecondsConverter))]
        public DateTime? LastTradeTime { get; set; }
        /// <summary>
        /// Price of last fill
        /// </summary>
        [JsonProperty("last_exec_price")]
        public decimal LastTradePrice { get; set; }        
        /// <summary>
        /// Quote quantity filled
        /// </summary>
        [JsonProperty("cum_exec_qty")]
        public decimal QuoteQuantityFilled { get; set; }
        /// <summary>
        /// Base quantity filled
        /// </summary>
        [JsonProperty("cum_exec_value")]
        public decimal BaseQuantityFilled { get; set; }
        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonProperty("cum_exec_fee")]
        public decimal Fee { get; set; }
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
    }
}
