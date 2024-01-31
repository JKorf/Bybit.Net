using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Linear/Inverse ticker
    /// </summary>
    public class BybitLinearInverseTicker
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
        /// Price 1h ago
        /// </summary>
        [JsonProperty("prevPrice1h")]
        public decimal PreviousPrice1h { get; set; }
        /// <summary>
        /// Price change percentage since 24h ago
        /// </summary>
        [JsonProperty("price24hPcnt")]
        public decimal PriceChangePercentage24h { get; set; }
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
        /// Delivery fee rate
        /// </summary>
        public decimal? DeliveryFeeRate { get; set; }
        /// <summary>
        /// Delivery time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// Open interest
        /// </summary>
        public decimal? OpenInterest { get; set; }
        /// <summary>
        /// Open interest value
        /// </summary>
        public decimal? OpenInterestValue { get; set; }
        /// <summary>
        /// Funding rate
        /// </summary>
        public decimal? FundingRate { get; set; }
        /// <summary>
        /// Next funding time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? NextFundingTime { get; set; }
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
        /// Basis rate
        /// </summary>
        public decimal? BasisRate { get; set; }
        /// <summary>
        /// Basis
        /// </summary>
        public decimal? Basis { get; set; }
        /// <summary>
        /// Predicted delivery price
        /// </summary>
        public decimal? PredictedDeliveryPrice { get; set; }
    }
}
