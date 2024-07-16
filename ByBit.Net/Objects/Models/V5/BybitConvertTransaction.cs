using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.V5
{
    internal record BybitConvertTransactionWrapper
    {
        /// <summary>
        /// Result
        /// </summary>
        [JsonProperty("result")]
        public BybitConvertTransaction Result { get; set; } = null!;
    }

    internal record BybitConvertTransactionListWrapper
    {
        /// <summary>
        /// List
        /// </summary>
        [JsonProperty("list")]
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
        [JsonProperty("accountType"), JsonConverter(typeof(EnumConverter))]
        public ConvertAccountType AccountType { get; set; }
        /// <summary>
        /// Exchange transaction id
        /// </summary>
        [JsonProperty("exchangeTxId")]
        public string ExchangeTransactionId { get; set; } = string.Empty;
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// From asset
        /// </summary>
        [JsonProperty("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;
        /// <summary>
        /// From asset type
        /// </summary>
        [JsonProperty("fromCoinType")]
        public string FromAssetType { get; set; } = string.Empty;
        /// <summary>
        /// From quantity
        /// </summary>
        [JsonProperty("fromAmount")]
        public decimal FromQuantity { get; set; }
        /// <summary>
        /// To asset
        /// </summary>
        [JsonProperty("toCoin")]
        public string ToAsset { get; set; } = string.Empty;
        /// <summary>
        /// To asset type
        /// </summary>
        [JsonProperty("toCoinType")]
        public string ToAssetType { get; set; } = string.Empty;
        /// <summary>
        /// To quantity
        /// </summary>
        [JsonProperty("toAmount")]
        public decimal ToQuantity { get; set; }
        /// <summary>
        /// Exchange status
        /// </summary>
        [JsonProperty("exchangeStatus"), JsonConverter(typeof(EnumConverter))]
        public ConvertTransactionStatus? ExchangeStatus { get; set; }
        /// <summary>
        /// Convert rate
        /// </summary>
        [JsonProperty("convertRate")]
        public decimal ConvertRate { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("createdAt"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
    }
}
