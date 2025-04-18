using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Ticker update
    /// </summary>
    [SerializationModel]
    public record BybitLinearTickerUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Tick direction
        /// </summary>

        [JsonPropertyName("tickDirection")]
        public TickDirection? TickDirection { get; set; }
        /// <summary>
        /// Price change percentage since 24h ago
        /// </summary>
        [JsonPropertyName("price24hPcnt")]
        public decimal? PricePercentage24h { get; set; }
        /// <summary>
        /// Last price
        /// </summary>
        [JsonPropertyName("lastPrice")]
        public decimal? LastPrice { get; set; }
        /// <summary>
        /// High price in last 24h
        /// </summary>
        [JsonPropertyName("highPrice24h")]
        public decimal? HighPrice24h { get; set; }
        /// <summary>
        /// Low price in last 24h
        /// </summary>
        [JsonPropertyName("lowPrice24h")]
        public decimal? LowPrice24h { get; set; }
        /// <summary>
        /// Previous price in last 24h
        /// </summary>
        [JsonPropertyName("prevPrice24h")]
        public decimal? PreviousPrice24h { get; set; }
        /// <summary>
        /// Previous price in last hour
        /// </summary>
        [JsonPropertyName("prevPrice1h")]
        public decimal? PreviousPrice1h { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// Index price
        /// </summary>
        [JsonPropertyName("indexPrice")]
        public decimal? IndexPrice { get; set; }
        /// <summary>
        /// Open interest
        /// </summary>
        [JsonPropertyName("openInterest")]
        public decimal? OpenInterest { get; set; }
        /// <summary>
        /// Open interest value
        /// </summary>
        [JsonPropertyName("openInterestValue")]
        public decimal? OpenInterestValue { get; set; }
        /// <summary>
        /// 24 hour turnover
        /// </summary>
        [JsonPropertyName("turnover24h")]
        public decimal? Turnover24h { get; set; }
        /// <summary>
        /// 24 hour volume
        /// </summary>
        [JsonPropertyName("volume24h")]
        public decimal? Volume24h { get; set; }
        /// <summary>
        /// Next funding time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("nextFundingTime")]
        public DateTime? NextFundingTime { get; set; }
        /// <summary>
        /// Funding rate
        /// </summary>
        [JsonPropertyName("fundingRate")]
        public decimal? FundingRate { get; set; }
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
        /// [InverseFutures] Delivery time in UTC
        /// </summary>
        [JsonPropertyName("deliveryTime")]
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// [InverseFutures] Basis rate
        /// </summary>
        [JsonPropertyName("basisRate")]
        public decimal? BasisRate { get; set; }
        /// <summary>
        /// [InverseFutures] Delivery fee rate
        /// </summary>
        [JsonPropertyName("deliveryFeeRate")]
        public decimal? DeliveryFeeRate { get; set; }
        /// <summary>
        /// [InverseFutures] Predicted delivery price
        /// </summary>
        [JsonPropertyName("predictedDeliveryPrice")]
        public decimal? PredictedDeliveryPrice { get; set; }
        /// <summary>
        /// Estimated pre-market contract open price
        /// </summary>
        [JsonPropertyName("preOpenPrice")]
        public decimal? PreOpenPrice { get; set; }
        /// <summary>
        /// Estimated pre-market contract open qty
        /// </summary>
        [JsonPropertyName("preQty")]
        public decimal? PreOpenQuantity { get; set; }
        /// <summary>
        /// The current pre-market contract phase
        /// </summary>
        [JsonPropertyName("curPreListingPhase")]
        public AuctionPhase? PreListingPhase { get; set; }
    }
}
