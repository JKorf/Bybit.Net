using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Request info
    /// </summary>
    [SerializationModel]
    public record BybitCancelOrderRequest
    {
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// The order id to cancel, either this or ClientOrderId should be provided
        /// </summary>
        [JsonPropertyName("orderId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? OrderId { get; set; }
        /// <summary>
        /// The client order id to cancel, either this or OrderId should be provided
        /// </summary>
        [JsonPropertyName("orderLinkId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Order filter
        /// </summary>
        [JsonPropertyName("orderFilter"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public OrderFilter? OrderFilter { get; set; }
    }

    [SerializationModel]
    internal record BybitSocketCancelOrderRequest: BybitCancelOrderRequest
    {
        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
