using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Ticker info
    /// </summary>
    [SerializationModel]
    public record BybitOptionTicker
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
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonPropertyName("bid1Size")]
        public decimal BestBidQuantity { get; set; }
        /// <summary>
        /// Best bid IV
        /// </summary>
        [JsonPropertyName("bid1Iv")]
        public decimal BestBidIv { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonPropertyName("ask1Price")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Best ask quantity
        /// </summary>
        [JsonPropertyName("ask1Size")]
        public decimal BestAskQuantity { get; set; }
        /// <summary>
        /// Best ask IV
        /// </summary>
        [JsonPropertyName("ask1Iv")]
        public decimal BestAskIv { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonPropertyName("lastPrice")]
        public decimal LastPrice { get; set; }
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
        /// Mark price
        /// </summary>
        [JsonPropertyName("markPrice")]
        public decimal MarkPrice { get; set; }
        /// <summary>
        /// Index price
        /// </summary>
        [JsonPropertyName("indexPrice")]
        public decimal IndexPrice { get; set; }
        /// <summary>
        /// Mark iv
        /// </summary>
        [JsonPropertyName("markIv")]
        public decimal MarkIv { get; set; }
        /// <summary>
        /// Underlying asset price
        /// </summary>
        [JsonPropertyName("underlyingPrice")]
        public decimal UnderlyingPrice { get; set; }
        /// <summary>
        /// Open interest
        /// </summary>
        [JsonPropertyName("openInterest")]
        public decimal OpenInterest { get; set; }
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
        /// Total volume
        /// </summary>
        [JsonPropertyName("totalVolume")]
        public decimal TotalVolume { get; set; }
        /// <summary>
        /// Total turnover
        /// </summary>
        [JsonPropertyName("totalTurnover")]
        public decimal TotalTurnover { get; set; }
        /// <summary>
        /// Delta
        /// </summary>
        [JsonPropertyName("delta")]
        public decimal Delta { get; set; }
        /// <summary>
        /// Gamma
        /// </summary>
        [JsonPropertyName("gamma")]
        public decimal Gamma { get; set; }
        /// <summary>
        /// Vega
        /// </summary>
        [JsonPropertyName("vega")]
        public decimal Vega { get; set; }
        /// <summary>
        /// Theta
        /// </summary>
        [JsonPropertyName("theta")]
        public decimal Theta { get; set; }
        /// <summary>
        /// Predicted delivery price
        /// </summary>
        [JsonPropertyName("predictedDeliveryPrice")]
        public decimal PredictedDeliveryPrice { get; set; }
        /// <summary>
        /// Change since 24h ago
        /// </summary>
        [JsonPropertyName("change24h")]
        public decimal Change24h { get; set; }
    }
}
