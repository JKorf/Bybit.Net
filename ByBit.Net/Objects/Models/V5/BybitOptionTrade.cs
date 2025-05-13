using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Options trade
    /// </summary>
    [SerializationModel]
    public record BybitOptionTrade : BybitTrade
    {
        /// <summary>
        /// Mark price
        /// </summary>
        [JsonPropertyName("mP")]
        public decimal MarkPrice { get; set; }
        /// <summary>
        /// Index price
        /// </summary>
        [JsonPropertyName("iP")]
        public decimal IndexPrice { get; set; }
        /// <summary>
        /// Mark iv
        /// </summary>
        [JsonPropertyName("mIv")]
        public decimal MarkIv { get; set; }
        /// <summary>
        /// Index iv
        /// </summary>
        [JsonPropertyName("iv")]
        public decimal IndexIv { get; set; }
    }
}
