using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    internal record BybitConvertTransactionWrapper
    {
        /// <summary>
        /// Result
        /// </summary>
        [JsonPropertyName("result")]
        public BybitConvertTransaction Result { get; set; } = null!;
    }

    internal record BybitConvertTransactionListWrapper
    {
        /// <summary>
        /// List
        /// </summary>
        [JsonPropertyName("list")]
        public IEnumerable<BybitConvertTransaction> List { get; set; } = Array.Empty<BybitConvertTransaction>();
    }

    /// <summary>
    /// Convert transaction info
    /// </summary>
    public record BybitConvertTransaction
    {
        /// <summary>
        /// Account type
        /// </summary>
        [JsonPropertyName("accountType"), JsonConverter(typeof(EnumConverter))]
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
        [JsonPropertyName("exchangeStatus"), JsonConverter(typeof(EnumConverter))]
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
