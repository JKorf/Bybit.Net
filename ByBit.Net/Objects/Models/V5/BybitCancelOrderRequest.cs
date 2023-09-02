using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Request info
    /// </summary>
    public class BybitCancelOrderRequest
    {
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// The order id to cancel
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; } = string.Empty;

    }
}
