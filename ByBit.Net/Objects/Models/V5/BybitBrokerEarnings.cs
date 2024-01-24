using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Broker earnings info
    /// </summary>
    public class BybitBrokerEarnings
    {
        /// <summary>
        /// Total earnings info
        /// </summary>
        [JsonProperty("totalEarningCat")]
        public BybitTotalEarnings TotalEarnings { get; set; } = null!;
        /// <summary>
        /// Earning details
        /// </summary>
        [JsonProperty("details")]
        public IEnumerable<BybitEarningDetails> Details { get; set; } = Array.Empty<BybitEarningDetails>();
        /// <summary>
        /// Cursor which can be used for paginiation
        /// </summary>
        [JsonProperty("nextPageCursor")]
        public string NextPageCursor { get; set; } = string.Empty;
    }

    /// <summary>
    /// Total earnings info
    /// </summary>
    public class BybitTotalEarnings
    {
        /// <summary>
        /// Spot earnings
        /// </summary>
        [JsonProperty("spot")]
        public IEnumerable<BybitBrokerEarning> Spot { get; set; } = Array.Empty<BybitBrokerEarning>();
        /// <summary>
        /// Derivatives earnings
        /// </summary>
        [JsonProperty("derivatives")]
        public IEnumerable<BybitBrokerEarning> Derivatives { get; set; } = Array.Empty<BybitBrokerEarning>();
        /// <summary>
        /// Options earnings
        /// </summary>
        [JsonProperty("options")]
        public IEnumerable<BybitBrokerEarning> Options { get; set; } = Array.Empty<BybitBrokerEarning>();
        /// <summary>
        /// Total earnings
        /// </summary>
        [JsonProperty("total")]
        public IEnumerable<BybitBrokerEarning> Total { get; set; } = Array.Empty<BybitBrokerEarning>();
    }

    /// <summary>
    /// Asset earning info
    /// </summary>
    public class BybitBrokerEarning
    {
        /// <summary>
        /// The earned asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Earned quantity
        /// </summary>
        [JsonProperty("earning")]
        public decimal Earning { get; set; }
    }

    /// <summary>
    /// Earning details
    /// </summary>
    public class BybitEarningDetails
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// BizType
        /// </summary>
        [JsonProperty("bizType")]
        public string BizTyp { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Earned quantity
        /// </summary>
        [JsonProperty("earning")]
        public decimal Earning { get; set; }
        /// <summary>
        /// Markup earnings
        /// </summary>
        [JsonProperty("markupEarning")]
        public decimal MarkupEarning { get; set; }
        /// <summary>
        /// Base fee earnings
        /// </summary>
        [JsonProperty("baseFeeEarning")]
        public decimal BaseFeeEarning { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("execTime")]
        public DateTime Timestamp { get; set; }
    }
}
