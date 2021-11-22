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
        public string Id { get; set; } = string.Empty;
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
        /// Reason for reject
        /// </summary>
        [JsonProperty("reject_reason")]
        public string? RejectReason { get; set; }
    }
}
