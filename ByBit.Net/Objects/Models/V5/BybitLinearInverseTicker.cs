using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Linear/Inverse ticker
    /// </summary>
    [SerializationModel]
    public record BybitLinearInverseTicker
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
        /// Last trade price
        /// </summary>
        [JsonPropertyName("lastPrice")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Price 24h ago
        /// </summary>
        [JsonPropertyName("prevPrice24h")]
        public decimal PreviousPrice24h { get; set; }
        /// <summary>
        /// Price 1h ago
        /// </summary>
        [JsonPropertyName("prevPrice1h")]
        public decimal PreviousPrice1h { get; set; }
        /// <summary>
        /// Price change percentage since 24h ago
        /// </summary>
        [JsonPropertyName("price24hPcnt")]
        public decimal PriceChangePercentage24h { get; set; }
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
        /// Delivery fee rate
        /// </summary>
        [JsonPropertyName("deliveryFeeRate")]
        public decimal? DeliveryFeeRate { get; set; }
        /// <summary>
        /// Delivery time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("deliveryTime")]
        public DateTime? DeliveryTime { get; set; }
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
        /// Funding rate
        /// </summary>
        [JsonPropertyName("fundingRate")]
        public decimal? FundingRate { get; set; }
        /// <summary>
        /// Next funding time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("nextFundingTime")]
        public DateTime? NextFundingTime { get; set; }
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
        /// Basis rate
        /// </summary>
        [JsonPropertyName("basisRate")]
        public decimal? BasisRate { get; set; }
        /// <summary>
        /// Basis
        /// </summary>
        [JsonPropertyName("basis")]
        public decimal? Basis { get; set; }
        /// <summary>
        /// Predicted delivery price
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
        /// <summary>
        /// Funding interval in hours
        /// </summary>
        [JsonPropertyName("fundingIntervalHour")]
        public int? FundingInterval { get; set; }
        /// <summary>
        /// Funding rate upper and lower limits
        /// </summary>
        [JsonPropertyName("fundingCap")]
        public decimal? FundingCap { get; set; }
        /// <summary>
        /// Annual basis rate
        /// </summary>
        [JsonPropertyName("basisRateYear")]
        public decimal? BasisRateYear { get; set; }
    }
}
