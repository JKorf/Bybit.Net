using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Stop order id
    /// </summary>
    public class BybitStopOrderId
    {
        /// <summary>
        /// Stop order id
        /// </summary>
        [JsonProperty("stop_order_id")]
        public string StopOrderId { get; set; } = string.Empty;
    }
}
