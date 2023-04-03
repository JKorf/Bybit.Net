using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Ticker info
    /// </summary>
    public class BybitOptionTicker
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
        /// Best bid IV
        /// </summary>
        [JsonProperty("bid1lv")]
        public decimal BestBidIv { get; set; }
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
        /// Best ask IV
        /// </summary>
        [JsonProperty("ask1lv")]
        public decimal BestAskIv { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        public decimal LastPrice { get; set; }
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
        /// Mark price
        /// </summary>
        public decimal MarkPrice { get; set; }
        /// <summary>
        /// Index price
        /// </summary>
        public decimal IndexPrice { get; set; }
        /// <summary>
        /// Mark iv
        /// </summary>
        public decimal MarkIv { get; set; }
        /// <summary>
        /// Underlying asset price
        /// </summary>
        public decimal UnderlyingPrice { get; set; }
        /// <summary>
        /// Open interest
        /// </summary>
        public decimal OpenInterest { get; set; }
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
        /// Total volume
        /// </summary>
        public decimal TotalVolume { get; set; }
        /// <summary>
        /// Total turnover
        /// </summary>
        public decimal TotalTurnover { get; set; }
        /// <summary>
        /// Delta
        /// </summary>
        public decimal Delta { get; set; }
        /// <summary>
        /// Gamma
        /// </summary>
        public decimal Gamma { get; set; }
        /// <summary>
        /// Vega
        /// </summary>
        public decimal Vega { get; set; }
        /// <summary>
        /// Theta
        /// </summary>
        public decimal Theta { get; set; }
        /// <summary>
        /// Predicted delivery price
        /// </summary>
        public decimal PredictedDeliveryPrice { get; set; }
        /// <summary>
        /// Change since 24h ago
        /// </summary>
        [JsonProperty("change24h")]
        public decimal Change24h { get; set; }
    }
}
