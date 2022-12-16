using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket.Derivatives
{
    /// <summary>
    /// Derivatives ticker update
    /// </summary>
    public class BybitDerivativesTickerUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Price change direction
        /// </summary>
        [JsonConverter(typeof(TickDirectionConverter))]
        public TickDirection TickDirection { get; set; }

        /// <summary>
        /// Price change percentage since 24 hours ago
        /// </summary>
        [JsonProperty("price24hPcnt")]
        public decimal? PriceChangePercentage24H { get; set; }

        /// <summary>
        /// Last trade price
        /// </summary>
        public decimal LastPrice { get; set; }

        /// <summary>
        /// Turnover in the last 24 hours
        /// </summary>
        public decimal? Turnover24H { get; set; }

        /// <summary>
        /// Volume in the last 24 hours
        /// </summary>
        public decimal? Volume24H { get; set; }

        /// <summary>
        /// Funding rate
        /// </summary>
        public decimal? FundingRate { get; set; }

        /// <summary>
        /// Next settlement time of capital cost
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? NextFundingTime { get; set; }

        /// <summary>
        /// Bid 1 price
        /// </summary>
        public decimal? Bid1Price { get; set; }

        /// <summary>
        /// Bid 1 size
        /// </summary>
        public decimal? Bid1Size { get; set; }

        /// <summary>
        /// Ask 1 price
        /// </summary>
        public decimal? Ask1Price { get; set; }

        /// <summary>
        /// Ask 1 size
        /// </summary>
        public decimal? Ask1Size { get; set; }
    }
}
