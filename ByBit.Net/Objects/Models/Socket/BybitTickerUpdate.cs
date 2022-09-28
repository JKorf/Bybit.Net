using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// Ticker update
    /// </summary>
    public class BybitTickerUpdate
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Direction of price change
        /// </summary>
        [JsonConverter(typeof(TickDirectionConverter))]
        [JsonProperty("last_tick_direction")]
        public TickDirection? LastTickDirection { get; set; }
        /// <summary>
        /// 24 hour price change percentage
        /// </summary>
        [JsonConverter(typeof(ExponentDivConverter), 6)]
        [JsonProperty("price_24h_pcnt_e6")]
        public decimal? PriceChangePercentage24H { get; set; }
        /// <summary>
        /// 1 hour price change percentage
        /// </summary>
        [JsonConverter(typeof(ExponentDivConverter), 6)]
        [JsonProperty("price_1h_pcnt_e6")]
        public decimal? PriceChangePercentage1H { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonProperty("last_price")]
        public decimal? LastPrice { get; set; }
        /// <summary>
        /// Price 24 hours ago
        /// </summary>
        [JsonProperty("prev_price_24h")]
        public decimal? Price24H { get; set; }
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
        /// Price 1 hour ago
        /// </summary>
        [JsonProperty("prev_price_1h")]
        public decimal? Price1H { get; set; }
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
        [JsonConverter(typeof(ExponentDivConverter), 7)]
        [JsonProperty("open_interest_e8")]
        private decimal? OpenInterestE8 { get => OpenInterest; set => OpenInterest = value; }
        /// <summary>
        /// Open value
        /// </summary>
        [JsonConverter(typeof(ExponentDivConverter), 8)]
        [JsonProperty("open_value_e8")]
        public decimal? OpenValue { get; set; }
        /// <summary>
        /// Total turnover
        /// </summary>
        [JsonConverter(typeof(ExponentDivConverter), 8)]
        [JsonProperty("total_turnover_e8")]
        public decimal? TotalTurnover { get; set; }
        /// <summary>
        /// 24 hour turnover
        /// </summary>
        [JsonConverter(typeof(ExponentDivConverter), 8)]
        [JsonProperty("turnover_24h_e8")]
        public decimal? Turnover24H { get; set; }
        /// <summary>
        /// Total volume
        /// </summary>
        [JsonProperty("total_volume")]
        public decimal? TotalVolume { get; set; }
        [JsonConverter(typeof(ExponentDivConverter), 8)]
        [JsonProperty("total_volume_e8")]
        private decimal? TotalVolumeE8 { get => TotalVolume; set => TotalVolume = value; }
        /// <summary>
        /// 24 hour volume
        /// </summary>
        [JsonProperty("volume_24h")]
        public decimal? Volume24H { get; set; }
        [JsonConverter(typeof(ExponentDivConverter), 8)]
        [JsonProperty("volume_24h_e8")]
        private decimal? Volume24HE8 { get => Volume24H; set => Volume24H = value; }
        /// <summary>
        /// Predicted funding rate
        /// </summary>
        [JsonConverter(typeof(ExponentDivConverter), 6)]
        [JsonProperty("predicted_funding_rate_e6")]
        public decimal? PredictedFundingRate { get; set; }
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonProperty("cross_seq")]
        public long? CrossSequence { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Next funding time
        /// </summary>
        [JsonProperty("next_funding_time")]
        public DateTime? NextFundingTime { get; set; }
        /// <summary>
        /// Countdown hour
        /// </summary>
        [JsonProperty("countdown_hour")]
        public int? CountdownHour { get; set; }
        [JsonProperty("count_down_hour")]
        private int? CountdownHourInternal { get => CountdownHour; set => CountdownHour = value; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("ask1_price")]
        public decimal? BestAskPrice { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("bid1_price")]
        public decimal? BestBidPrice { get; set; }

        /// <summary>
        /// Funding rate
        /// </summary>
        [JsonConverter(typeof(ExponentDivConverter), 6)]
        [JsonProperty("funding_rate_e6")]
        public decimal? FundingRate { get; set; }
        /// <summary>
        /// Funding rate interval in hours
        /// </summary>
        [JsonProperty("funding_rate_interval")]
        public int? FundingRateInterval { get; set; }
    }
}
