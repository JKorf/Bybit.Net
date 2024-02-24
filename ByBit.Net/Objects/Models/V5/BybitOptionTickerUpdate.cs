using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Option ticker update
    /// </summary>
    public class BybitOptionTickerUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("bidPrice")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonProperty("bidSize")]
        public decimal BestBidQuantity { get; set; }
        /// <summary>
        /// Bid IV
        /// </summary>
        public decimal BidIv { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("askPrice")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Best ask quantity
        /// </summary>
        [JsonProperty("askSize")]
        public decimal BestAskQuantity { get; set; }
        /// <summary>
        /// Ask IV
        /// </summary>
        public decimal AskIv { get; set; }
        /// <summary>
        /// Last price
        /// </summary>
        public decimal LastPrice { get; set; }
        /// <summary>
        /// 24h high price
        /// </summary>
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// 24h low price
        /// </summary>
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
        /// Mark price iv
        /// </summary>
        public decimal MarkPriceIv { get; set; }
        /// <summary>
        /// Underlying price
        /// </summary>
        public decimal UnderlyingPrice { get; set; }
        /// <summary>
        /// Open interest
        /// </summary>
        public decimal OpenInterest { get; set; }
        /// <summary>
        /// Turnover 24h
        /// </summary>
        public decimal Turnover24h { get; set; }
        /// <summary>
        /// Volume 24h
        /// </summary>
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
        /// 24h change
        /// </summary>
        public decimal Change24h { get; set; }
    }
}
