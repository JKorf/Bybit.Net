using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Order id
    /// </summary>
    public class BybitOrderId
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; } = string.Empty;
    }
}
