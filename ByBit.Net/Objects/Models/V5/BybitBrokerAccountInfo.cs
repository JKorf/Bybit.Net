using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Broker account info
    /// </summary>
    public class BybitBrokerAccountInfo
    {
        /// <summary>
        /// Current sub account quantity
        /// </summary>
        [JsonProperty("subAcctQty")]
        public int SubAccountCount { get; set; }
        /// <summary>
        /// Max sub account quantity
        /// </summary>
        [JsonProperty("maxSubAcctQty")]
        public int MaxSubAccountCount { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Base fee rebate rates
        /// </summary>
        [JsonProperty("baseFeeRebateRate")]
        public BybitBrokerRebateRate BaseFeeRebateRates { get; set; } = null!;
        /// <summary>
        /// Markup fee rebate rates
        /// </summary>
        [JsonProperty("markupFeeRebateRate")]
        public BybitBrokerRebateRate MarkupFeeRebateRates { get; set; } = null!;
    }

    /// <summary>
    /// Rebate rate info
    /// </summary>
    public class BybitBrokerRebateRate
    {
        /// <summary>
        /// Spot rebate rate
        /// </summary>
        [JsonProperty("spot")]
        public string Spot { get; set; } = string.Empty;
        /// <summary>
        /// Derivatives rebate rate
        /// </summary>
        [JsonProperty("derivatives")]
        public string Derivatives { get; set; } = string.Empty;
    }
}
