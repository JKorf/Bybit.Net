using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Ticker
    /// </summary>
    public class BybitTicker
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Best bid price available
        /// </summary>
        [JsonProperty("bid_price")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Best ask price available
        /// </summary>
        [JsonProperty("ask_price")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonProperty("last_price")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Price change direction
        /// </summary>
        [JsonProperty("last_tick_direction"), JsonConverter(typeof(TickDirectionConverter))]
        public TickDirection LastTickDirection { get; set; }
        /// <summary>
        /// Price 24 hours ago
        /// </summary>
        [JsonProperty("prev_price_24h")]
        public decimal? Price24H { get; set; }
        /// <summary>
        /// Price change percentage since 24 hours ago
        /// </summary>
        [JsonProperty("price_24h_pcnt")]
        public decimal? PriceChangePercentage24H { get; set; }
        /// <summary>
        /// High price in the last 24 hours
        /// </summary>
        [JsonProperty("high_price_24h")]
        public decimal? HighPrice24H { get; set; }
        /// <summary>
        /// Low price in the last 24 hours
        /// </summary>
        [JsonProperty("low_price_24h")]
        public decimal? LowPrice24H { get; set; }
        /// <summary>
        /// Pirce 1 hour ago
        /// </summary>
        [JsonProperty("prev_price_1h")]
        public decimal? Price1H { get; set; }
        /// <summary>
        /// Price change percentage since 1 hour ago
        /// </summary>
        [JsonProperty("price_1h_pcnt")]
        public decimal? PriceChangePercentage1H { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        [JsonProperty("mark_price")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// Index price
        /// </summary>
        [JsonProperty("index_price")]
        public decimal? IndexPrice { get; set; }
        /// <summary>
        /// Open interest
        /// </summary>
        [JsonProperty("open_interest")]
        public decimal? OpenInterest { get; set; }
        /// <summary>
        /// Open position value
        /// </summary>
        [JsonProperty("open_value")]
        public decimal? OpenValue { get; set; }
        /// <summary>
        /// Total turnover
        /// </summary>
        [JsonProperty("total_turnover")]
        public decimal? TotalTurnover { get; set; }
        /// <summary>
        /// Turnover in the last 24 hours
        /// </summary>
        [JsonProperty("turnover_24h")]
        public decimal? Turnover24H { get; set; }
        /// <summary>
        /// Total volume
        /// </summary>
        [JsonProperty("total_volume")]
        public decimal? TotalVolume { get; set; }
        /// <summary>
        /// Volume in the last 24 hours
        /// </summary>
        [JsonProperty("volume_24h")]
        public decimal? Volume24H { get; set; }
        /// <summary>
        /// Funding rate
        /// </summary>
        [JsonProperty("funding_rate")]
        public decimal? FundingRate { get; set; }
        /// <summary>
        /// Predicted funding rate
        /// </summary>
        [JsonProperty("predicted_funding_rate")]
        public decimal? PredictedFundingRate { get; set; }
        /// <summary>
        /// Next settlement time of capital cost
        /// </summary>
        [JsonProperty("next_funding_time")]
        public DateTime? NextFundingTime { get; set; }
        /// <summary>
        /// Countdown of settlemnt capital cost
        /// </summary>
        [JsonProperty("countdown_hour")]
        public int CountdownHour { get; set; }
        /// <summary>
        /// Delivery fee rate of futures contract
        /// </summary>
        [JsonProperty("delivery_fee_rate")]
        public decimal? DeliveryFeeRate { get; set; }
        /// <summary>
        /// Predicted delivery price of futures contract
        /// </summary>
        [JsonProperty("predicted_delivery_price")]
        public decimal? PredictedDeliveryPrice { get; set; }
        /// <summary>
        /// Delivery time of futures contract
        /// </summary>
        [JsonProperty("delivery_time")]
        public DateTime? DeliveryTime { get; set; }
    }
}
