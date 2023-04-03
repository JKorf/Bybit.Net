using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Ticker info
    /// </summary>
    public class BybitSpotTicker
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("bid1Price")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonProperty("bid1Size")]
        public decimal BestBidQuantity { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("ask1Price")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Best ask quantity
        /// </summary>
        [JsonProperty("ask1Size")]
        public decimal BestAskQuantity { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Price 24h ago
        /// </summary>
        [JsonProperty("prevPrice24h")]
        public decimal PreviousPrice24h { get; set; }
        /// <summary>
        /// Price change percentage since 24h ago
        /// </summary>
        [JsonProperty("price24hPcnt")]
        public decimal PriceChangePercentag24h { get; set; }
        /// <summary>
        /// High price last 24h
        /// </summary>
        [JsonProperty("highPrice24h")]
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// Low price last 24h
        /// </summary>
        [JsonProperty("lowPrice24h")]
        public decimal LowPrice24h { get; set; }
        /// <summary>
        /// Turnover last 24h
        /// </summary>
        [JsonProperty("turnover24h")]
        public decimal Turnover24h { get; set; }
        /// <summary>
        /// Volume last 24h
        /// </summary>
        [JsonProperty("volume24h")]
        public decimal Volume24h { get; set; }
        /// <summary>
        /// Usd index price
        /// </summary>
        [JsonProperty("usdIndexPrice")]
        public decimal UsdIndexPrice { get; set; }
    }
}
