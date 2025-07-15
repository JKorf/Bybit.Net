using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Delivery record
    /// </summary>
    [SerializationModel]
    public record BybitDeliveryRecord
    {
        /// <summary>
        /// Delivery time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("deliveryTime")]
        public DateTime DeliveryTime { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order side
        /// </summary>

        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Executed quantity
        /// </summary>
        [JsonPropertyName("position")]
        public decimal Position { get; set; }
        /// <summary>
        /// Delivery price
        /// </summary>
        [JsonPropertyName("deliveryPrice")]
        public decimal DeliveryPrice { get; set; }
        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonPropertyName("entryPrice")]
        public decimal? AverageEntryPrice { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("strike")]
        public decimal Strike { get; set; }
        /// <summary>
        /// Fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Realized profit and loss
        /// </summary>
        [JsonPropertyName("deliveryRpl")]
        public decimal RealizedPnl { get; set; }
    }
}
