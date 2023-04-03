using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Funding history
    /// </summary>
    public class BybitFundingHistory
    {
        /// <summary>
        /// The symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Funding rate
        /// </summary>
        public decimal FundingRate { get; set; }
        /// <summary>
        /// Funding timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("fundingRateTimestamp")]
        public DateTime Timestamp { get; set; }
    }
}
