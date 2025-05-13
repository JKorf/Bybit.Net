using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Leveraged token nav info
    /// </summary>
    [SerializationModel]
    public record BybitLeveragedTokenNav
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("time")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Net asset value
        /// </summary>
        [JsonPropertyName("nav")]
        public decimal Nav { get; set; }
        /// <summary>
        /// Basket position
        /// </summary>
        [JsonPropertyName("basketPosition")]
        public decimal BasketPosition { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Basket loan
        /// </summary>
        [JsonPropertyName("basketLoan")]
        public decimal BasketLoan { get; set; }
        /// <summary>
        /// Circulation
        /// </summary>
        [JsonPropertyName("circulation")]
        public decimal Circulation { get; set; }
        /// <summary>
        /// Basket
        /// </summary>
        [JsonPropertyName("basket")]
        public decimal Basket { get; set; }
    }
}
