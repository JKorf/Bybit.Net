using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Ticker info
    /// </summary>
    [SerializationModel]
    public record BybitSpotTicker
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonPropertyName("bid1Price")]
        public decimal? BestBidPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonPropertyName("bid1Size")]
        public decimal? BestBidQuantity { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonPropertyName("ask1Price")]
        public decimal? BestAskPrice { get; set; }
        /// <summary>
        /// Best ask quantity
        /// </summary>
        [JsonPropertyName("ask1Size")]
        public decimal? BestAskQuantity { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonPropertyName("lastPrice")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Price 24h ago
        /// </summary>
        [JsonPropertyName("prevPrice24h")]
        public decimal PreviousPrice24h { get; set; }
        /// <summary>
        /// Price change percentage since 24h ago
        /// </summary>
        [JsonPropertyName("price24hPcnt")]
        public decimal PriceChangePercentag24h { get; set; }
        /// <summary>
        /// High price last 24h
        /// </summary>
        [JsonPropertyName("highPrice24h")]
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// Low price last 24h
        /// </summary>
        [JsonPropertyName("lowPrice24h")]
        public decimal LowPrice24h { get; set; }
        /// <summary>
        /// Turnover last 24h
        /// </summary>
        [JsonPropertyName("turnover24h")]
        public decimal Turnover24h { get; set; }
        /// <summary>
        /// Volume last 24h
        /// </summary>
        [JsonPropertyName("volume24h")]
        public decimal Volume24h { get; set; }
        /// <summary>
        /// Usd index price
        /// </summary>
        [JsonPropertyName("usdIndexPrice")]
        public decimal UsdIndexPrice { get; set; }
    }
}
