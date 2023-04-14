using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Ticker update
    /// </summary>
    public class BybitLinearTickerUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Tick direction
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public TickDirection? TickDirection { get; set; }
        /// <summary>
        /// Price change percentage since 24h ago
        /// </summary>
        [JsonProperty("price24hPcnt")]
        public decimal? PricePercentage24h { get; set; }
        /// <summary>
        /// Last price
        /// </summary>
        public decimal? LastPrice { get; set; }
        /// <summary>
        /// High price in last 24h
        /// </summary>
        public decimal? HighPrice24h { get; set; }
        /// <summary>
        /// Low price in last 24h
        /// </summary>
        public decimal? LowPrice24h { get; set; }
        /// <summary>
        /// Previous price in last 24h
        /// </summary>
        [JsonProperty("prevPrice24h")]
        public decimal? PreviousPrice24h { get; set; }
        /// <summary>
        /// Previous price in last hour
        /// </summary>
        [JsonProperty("prevPrice1h")]
        public decimal? PreviousPrice1h { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// Index price
        /// </summary>
        public decimal? IndexPrice { get; set; }
        /// <summary>
        /// Open interest
        /// </summary>
        public decimal? OpenInterest { get; set; }
        /// <summary>
        /// Open interest value
        /// </summary>
        public decimal? OpenInterestValue { get; set; }
        /// <summary>
        /// 24 hour turnover
        /// </summary>
        public decimal? Turnover24h { get; set; }
        /// <summary>
        /// 24 hour volume
        /// </summary>
        public decimal? Volume24h { get; set; }
        /// <summary>
        /// Next funding time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? NextFundingTime { get; set; }
        /// <summary>
        /// Funding rate
        /// </summary>
        public decimal? FundingRate { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("bid1Price")]
        public decimal? BestBidPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonProperty("bid1Size")]
        public decimal? BestBidQuantity { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("ask1Price")]
        public decimal? BestAskPrice { get; set; }
        /// <summary>
        /// Best ask quantity
        /// </summary>
        [JsonProperty("ask1Size")]
        public decimal? BestAskQuantity { get; set; }
        /// <summary>
        /// [InverseFutures] Delivery time in UTC
        /// </summary>
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// [InverseFutures] Basis rate
        /// </summary>
        public decimal? BasisRate { get; set; }
        /// <summary>
        /// [InverseFutures] Delivery fee rate
        /// </summary>
        public decimal? DeliveryFeeRate { get; set; }
        /// <summary>
        /// [InverseFutures] Predicted delivery price
        /// </summary>
        public decimal? PredictedDeliveryPrice { get; set; }
    }
}
