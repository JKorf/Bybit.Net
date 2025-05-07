using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Broker account info
    /// </summary>
    [SerializationModel]
    public record BybitBrokerAccountInfo
    {
        /// <summary>
        /// Current sub account quantity
        /// </summary>
        [JsonPropertyName("subAcctQty")]
        public int SubAccountCount { get; set; }
        /// <summary>
        /// Max sub account quantity
        /// </summary>
        [JsonPropertyName("maxSubAcctQty")]
        public int MaxSubAccountCount { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Base fee rebate rates
        /// </summary>
        [JsonPropertyName("baseFeeRebateRate")]
        public BybitBrokerRebateRate BaseFeeRebateRates { get; set; } = null!;
        /// <summary>
        /// Markup fee rebate rates
        /// </summary>
        [JsonPropertyName("markupFeeRebateRate")]
        public BybitBrokerRebateRate MarkupFeeRebateRates { get; set; } = null!;
    }

    /// <summary>
    /// Rebate rate info
    /// </summary>
    [SerializationModel]
    public record BybitBrokerRebateRate
    {
        /// <summary>
        /// Spot rebate rate
        /// </summary>
        [JsonPropertyName("spot")]
        public string Spot { get; set; } = string.Empty;
        /// <summary>
        /// Derivatives rebate rate
        /// </summary>
        [JsonPropertyName("derivatives")]
        public string Derivatives { get; set; } = string.Empty;
        /// <summary>
        /// Convert rebate rate
        /// </summary>
        [JsonPropertyName("convert")]
        public string? Convert { get; set; }
    }
}
