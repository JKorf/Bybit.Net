using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    [SerializationModel]
    internal record BybitConvertTransactionWrapper
    {
        /// <summary>
        /// Result
        /// </summary>
        [JsonPropertyName("result")]
        public BybitConvertTransaction Result { get; set; } = null!;
    }

    [SerializationModel]
    internal record BybitConvertTransactionListWrapper
    {
        /// <summary>
        /// List
        /// </summary>
        [JsonPropertyName("list")]
        public BybitConvertTransaction[] List { get; set; } = Array.Empty<BybitConvertTransaction>();
    }

    /// <summary>
    /// Convert transaction info
    /// </summary>
    [SerializationModel]
    public record BybitConvertTransaction
    {
        /// <summary>
        /// Account type
        /// </summary>
        [JsonPropertyName("accountType")]
        public ConvertAccountType AccountType { get; set; }
        /// <summary>
        /// Exchange transaction id
        /// </summary>
        [JsonPropertyName("exchangeTxId")]
        public string ExchangeTransactionId { get; set; } = string.Empty;
        /// <summary>
        /// User id
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// From asset
        /// </summary>
        [JsonPropertyName("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;
        /// <summary>
        /// From asset type
        /// </summary>
        [JsonPropertyName("fromCoinType")]
        public string FromAssetType { get; set; } = string.Empty;
        /// <summary>
        /// From quantity
        /// </summary>
        [JsonPropertyName("fromAmount")]
        public decimal FromQuantity { get; set; }
        /// <summary>
        /// To asset
        /// </summary>
        [JsonPropertyName("toCoin")]
        public string ToAsset { get; set; } = string.Empty;
        /// <summary>
        /// To asset type
        /// </summary>
        [JsonPropertyName("toCoinType")]
        public string ToAssetType { get; set; } = string.Empty;
        /// <summary>
        /// To quantity
        /// </summary>
        [JsonPropertyName("toAmount")]
        public decimal ToQuantity { get; set; }
        /// <summary>
        /// Exchange status
        /// </summary>
        [JsonPropertyName("exchangeStatus")]
        public ConvertTransactionStatus? ExchangeStatus { get; set; }
        /// <summary>
        /// Convert rate
        /// </summary>
        [JsonPropertyName("convertRate")]
        public decimal ConvertRate { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonPropertyName("createdAt"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
    }
}
