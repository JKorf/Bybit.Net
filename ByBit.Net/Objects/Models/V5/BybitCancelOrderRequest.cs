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
        /// The order id to cancel, either this or ClientOrderId should be provided
        /// </summary>
        [JsonProperty("orderId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? OrderId { get; set; }
        /// <summary>
        /// The client order id to cancel, either this or OrderId should be provided
        /// </summary>
        [JsonProperty("orderLinkId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ClientOrderId { get; set; }

    }
}
