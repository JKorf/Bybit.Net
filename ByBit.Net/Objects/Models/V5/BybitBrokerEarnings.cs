using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Broker earnings info
    /// </summary>
    [SerializationModel]
    public record BybitBrokerEarnings
    {
        /// <summary>
        /// Total earnings info
        /// </summary>
        [JsonPropertyName("totalEarningCat")]
        public BybitTotalEarnings TotalEarnings { get; set; } = null!;
        /// <summary>
        /// Earning details
        /// </summary>
        [JsonPropertyName("details")]
        public BybitEarningDetails[] Details { get; set; } = Array.Empty<BybitEarningDetails>();
        /// <summary>
        /// Cursor which can be used for paginiation
        /// </summary>
        [JsonPropertyName("nextPageCursor")]
        public string NextPageCursor { get; set; } = string.Empty;
    }

    /// <summary>
    /// Total earnings info
    /// </summary>
    [SerializationModel]
    public record BybitTotalEarnings
    {
        /// <summary>
        /// Spot earnings
        /// </summary>
        [JsonPropertyName("spot")]
        public BybitBrokerEarning[] Spot { get; set; } = Array.Empty<BybitBrokerEarning>();
        /// <summary>
        /// Convert earnings
        /// </summary>
        [JsonPropertyName("convert")]
        public BybitBrokerEarning[] Convert { get; set; } = Array.Empty<BybitBrokerEarning>();
        /// <summary>
        /// Derivatives earnings
        /// </summary>
        [JsonPropertyName("derivatives")]
        public BybitBrokerEarning[] Derivatives { get; set; } = Array.Empty<BybitBrokerEarning>();
        /// <summary>
        /// Options earnings
        /// </summary>
        [JsonPropertyName("options")]
        public BybitBrokerEarning[] Options { get; set; } = Array.Empty<BybitBrokerEarning>();
        /// <summary>
        /// Total earnings
        /// </summary>
        [JsonPropertyName("total")]
        public BybitBrokerEarning[] Total { get; set; } = Array.Empty<BybitBrokerEarning>();
    }

    /// <summary>
    /// Asset earning info
    /// </summary>
    [SerializationModel]
    public record BybitBrokerEarning
    {
        /// <summary>
        /// The earned asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Earned quantity
        /// </summary>
        [JsonPropertyName("earning")]
        public decimal Earning { get; set; }
    }

    /// <summary>
    /// Earning details
    /// </summary>
    [SerializationModel]
    public record BybitEarningDetails
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// BizType
        /// </summary>
        [JsonPropertyName("bizType")]
        public string BizTyp { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Earned quantity
        /// </summary>
        [JsonPropertyName("earning")]
        public decimal Earning { get; set; }
        /// <summary>
        /// Markup earnings
        /// </summary>
        [JsonPropertyName("markupEarning")]
        public decimal MarkupEarning { get; set; }
        /// <summary>
        /// Base fee earnings
        /// </summary>
        [JsonPropertyName("baseFeeEarning")]
        public decimal BaseFeeEarning { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonPropertyName("execId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("execTime")]
        public DateTime Timestamp { get; set; }
    }
}
