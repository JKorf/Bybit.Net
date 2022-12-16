using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Ticker
    /// </summary>
    public class BybitDerivativesTicker
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Delivery time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DeliveryTime { get; set; }

        /// <summary>
        /// Price change percentage since 24 hours ago
        /// </summary>
        [JsonProperty("price24hPcnt")]
        public decimal? PriceChangePercentage24H { get; set; }

        /// <summary>
        /// Next settlement time of capital cost
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? NextFundingTime { get; set; }

        /// <summary>
        /// Predicted delivery price. Applicable to inverse future and option. There will be value 30 mins before delivery
        /// </summary>
        public decimal? PredictedDeliveryPrice { get; set; }

        /// <summary>
        /// Index price
        /// </summary>
        public decimal? IndexPrice { get; set; }

        /// <summary>
        /// Price 24 hours ago
        /// </summary>
        [JsonProperty("prevPrice24h")]
        public decimal? Price24H { get; set; }

        /// <summary>
        /// Open interest
        /// </summary>
        public decimal? OpenInterest { get; set; }

        /// <summary>
        /// Underlying price
        /// </summary>
        public decimal? UnderlyingPrice { get; set; }

        /// <summary>
        /// Volume in the last 24 hours
        /// </summary>
        public decimal? Volume24H { get; set; }

        /// <summary>
        /// VEGA value
        /// </summary>
        public decimal? Vega { get; set; }

        /// <summary>
        /// Price change direction
        /// </summary>
        [JsonConverter(typeof(TickDirectionConverter))]
        public TickDirection LastTickDirection { get; set; }

        /// <summary>
        /// Last trade price
        /// </summary>
        public decimal LastPrice { get; set; }

        /// <summary>
        /// Total volume
        /// </summary>
        public decimal? TotalVolume { get; set; }

        /// <summary>
        /// Best bid price available
        /// </summary>
        [JsonProperty("bidPrice")]
        public decimal BestBidPrice { get; set; }

        /// <summary>
        /// Best ask price available
        /// </summary>
        [JsonProperty("askPrice")]
        public decimal BestAskPrice { get; set; }

        /// <summary>
        /// Total turnover
        /// </summary>
        public decimal? TotalTurnover { get; set; }

        /// <summary>
        /// Turnover in the last 24 hours
        /// </summary>
        public decimal? Turnover24H { get; set; }

        /// <summary>
        /// Funding rate
        /// </summary>
        public decimal? FundingRate { get; set; }

        /// <summary>
        /// Bid quantity
        /// </summary>
        public decimal BidSize { get; set; }

        /// <summary>
        /// Ask quantity
        /// </summary>
        public decimal AskSize { get; set; }

        /// <summary>
        /// Implied volatility for best bid
        /// </summary>
        [JsonProperty("bidIv")]
        public decimal? BestBidVolatility { get; set; }

        /// <summary>
        /// Implied volatility for best ask
        /// </summary>
        [JsonProperty("askIv")]
        public decimal? BestAskVolatility { get; set; }

        /// <summary>
        /// High price in the last 24 hours
        /// </summary>
        public decimal? HighPrice24H { get; set; }

        /// <summary>
        /// Low price in the last 24 hours
        /// </summary>
        public decimal? LowPrice24H { get; set; }

        /// <summary>
        /// Delta value
        /// </summary>
        public decimal? Delta { get; set; }

        /// <summary>
        /// Theta value
        /// </summary>
        public decimal? Theta { get; set; }

        /// <summary>
        /// Gamma value
        /// </summary>
        public decimal? Gamma { get; set; }

        /// <summary>
        /// Pirce 1 hour ago
        /// </summary>
        [JsonProperty("prevPrice1h")]
        public decimal? Price1H { get; set; }

        /// <summary>
        /// Mark price
        /// </summary>
        public decimal? MarkPrice { get; set; }

        /// <summary>
        /// Implied volatility for mark price
        /// </summary>
        [JsonProperty("markPriceIv")]
        public decimal? MarkPriceVolatility { get; set; }

        /// <summary>
        /// Delivery fee rate of futures contract
        /// </summary>
        public decimal? DeliveryFeeRate { get; set; }

        /// <summary>
        /// Basis rate for futures
        /// </summary>
        public decimal? BasisRate { get; set; }
    }
}
