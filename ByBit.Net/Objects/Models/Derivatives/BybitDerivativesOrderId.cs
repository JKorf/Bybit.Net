using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Order id
    /// </summary>
    public class BybitDerivativesOrderId
    {
        /// <summary>
        /// Order id
        /// </summary>
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Strategy linked order ID
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string ClientOrderId { get; set; } = string.Empty;
    }
}
