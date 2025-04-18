using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    [SerializationModel]
    internal record BybitAssetExchageWrapper : BybitBaseResponse
    {
        [JsonPropertyName("orderBody")]
        public BybitAssetExchange[] OrderBody { get; set; } = Array.Empty<BybitAssetExchange>();
    }

    /// <summary>
    /// Asset exchange info
    /// </summary>
    [SerializationModel]
    public record BybitAssetExchange
    {
        /// <summary>
        /// From asset
        /// </summary>
        [JsonPropertyName("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;
        /// <summary>
        /// To asset
        /// </summary>
        [JsonPropertyName("toCoin")]
        public string ToAsset { get; set; } = string.Empty;
        /// <summary>
        /// From quantity
        /// </summary>
        [JsonPropertyName("fromAmount")]
        public decimal FromQuantity { get; set; }
        /// <summary>
        /// To quantity
        /// </summary>
        [JsonPropertyName("toAmount")]
        public decimal ToQuantity { get; set; }
        /// <summary>
        /// Exchange rate
        /// </summary>
        [JsonPropertyName("exchangeRate")]
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        [JsonPropertyName("exchangeTxId")]
        public string ExchangeTransactionId { get; set; } = string.Empty;
    }
}
