using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Spot ticker update
    /// </summary>
    [SerializationModel]
    public record BybitSpotTickerUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Last price
        /// </summary>
        [JsonPropertyName("lastPrice")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// High price in last 24h
        /// </summary>
        [JsonPropertyName("highPrice24h")]
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// Low price in last 24h
        /// </summary>
        [JsonPropertyName("lowPrice24h")]
        public decimal LowPrice24h { get; set; }
        /// <summary>
        /// Previous price in last 24h
        /// </summary>
        [JsonPropertyName("prevPrice24h")]
        public decimal PreviousPrice24h { get; set; }
        /// <summary>
        /// Volume last 24h
        /// </summary>
        [JsonPropertyName("volume24h")]
        public decimal Volume24h { get; set; }
        /// <summary>
        /// Turnover last 24h
        /// </summary>
        [JsonPropertyName("turnover24h")]
        public decimal Turnover24h { get; set; }
        /// <summary>
        /// Price change percentage since 24h ago
        /// </summary>
        [JsonPropertyName("price24hPcnt")]
        public decimal PricePercentage24h { get; set; }
        /// <summary>
        /// Usd index price
        /// </summary>
        [JsonPropertyName("usdIndexPrice")]
        public decimal? UsdIndexPrice { get; set; }
    }
}
