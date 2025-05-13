using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Leverage token market info
    /// </summary>
    [SerializationModel]
    public record BybitLeverageTokenMarket
    {
        /// <summary>
        /// Basket
        /// </summary>
        [JsonPropertyName("basket")]
        public decimal Basket { get; set; }
        /// <summary>
        /// Circulating supply in the secondary market
        /// </summary>
        [JsonPropertyName("circulation")]
        public decimal Circulation { get; set; }
        /// <summary>
        /// Real leverage calculated by last traded price
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Net value
        /// </summary>
        [JsonPropertyName("nav")]
        public decimal Nav { get; set; }
        /// <summary>
        /// Update time for net asset value
        /// </summary>
        [JsonPropertyName("navTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime NavTime { get; set; }
        /// <summary>
        /// Token name
        /// </summary>
        [JsonPropertyName("ltCoin")]
        public string Token { get; set; } = string.Empty;
    }
}
