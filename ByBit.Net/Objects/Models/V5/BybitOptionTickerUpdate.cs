using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Option ticker update
    /// </summary>
    [SerializationModel]
    public record BybitOptionTickerUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonPropertyName("bidPrice")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonPropertyName("bidSize")]
        public decimal BestBidQuantity { get; set; }
        /// <summary>
        /// Bid IV
        /// </summary>
        [JsonPropertyName("bidIv")]
        public decimal BidIv { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonPropertyName("askPrice")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Best ask quantity
        /// </summary>
        [JsonPropertyName("askSize")]
        public decimal BestAskQuantity { get; set; }
        /// <summary>
        /// Ask IV
        /// </summary>
        [JsonPropertyName("askIv")]
        public decimal AskIv { get; set; }
        /// <summary>
        /// Last price
        /// </summary>
        [JsonPropertyName("lastPrice")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// 24h high price
        /// </summary>
        [JsonPropertyName("highPrice24h")]
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// 24h low price
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
        /// Mark price iv
        /// </summary>
        [JsonPropertyName("markPriceIv")]
        public decimal MarkPriceIv { get; set; }
        /// <summary>
        /// Underlying price
        /// </summary>
        [JsonPropertyName("underlyingPrice")]
        public decimal UnderlyingPrice { get; set; }
        /// <summary>
        /// Open interest
        /// </summary>
        [JsonPropertyName("openInterest")]
        public decimal OpenInterest { get; set; }
        /// <summary>
        /// Turnover 24h
        /// </summary>
        [JsonPropertyName("turnover24h")]
        public decimal Turnover24h { get; set; }
        /// <summary>
        /// Volume 24h
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
        /// 24h change
        /// </summary>
        [JsonPropertyName("change24h")]
        public decimal Change24h { get; set; }
    }
}
