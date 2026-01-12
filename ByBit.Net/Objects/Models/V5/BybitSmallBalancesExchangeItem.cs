using Bybit.Net.Enums;
using System;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Small balances exchange item
    /// </summary>
    public record BybitSmallBalancesExchangeItem
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
        /// Output asset
        /// </summary>
        [JsonPropertyName("toCoin")]
        public string ToAsset { get; set; } = string.Empty;
        /// <summary>
        /// Output quantity
        /// </summary>
        [JsonPropertyName("toAmount")]
        public decimal ToQuantity { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public SmallBalanceConvertStatus Status { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Source
        /// </summary>
        [JsonPropertyName("exchangeSource")]
        public string ExchangeSource { get; set; } = string.Empty;
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonPropertyName("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Total fee quantity
        /// </summary>
        [JsonPropertyName("totalFeeAmount")]
        public decimal TotalFeeQuantity { get; set; }
        /// <summary>
        /// Total tax fee
        /// </summary>
        [JsonPropertyName("totalTaxFeeInfo")]
        public BybitSmallBalancesQuoteTaxFee TotalTaxFee { get; set; } = null!;
        /// <summary>
        /// Sub records
        /// </summary>
        [JsonPropertyName("subRecords")]
        public BybitSmallBalancesExchangeSubRecord[] Records { get; set; } = [];
    }

    /// <summary>
    /// Exchange sub record
    /// </summary>
    public record BybitSmallBalancesExchangeSubRecord
    {
        /// <summary>
        /// From asset
        /// </summary>
        [JsonPropertyName("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;
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
        /// To quantity
        /// </summary>
        [JsonPropertyName("toAmount")]
        public decimal ToQuantity { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonPropertyName("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Fee quantity
        /// </summary>
        [JsonPropertyName("feeAmount")]
        public decimal FeeQuantity { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public SmallBalanceConvertStatus Status { get; set; }
        /// <summary>
        /// Tax fee info
        /// </summary>
        [JsonPropertyName("taxFeeInfo")]
        public BybitSmallBalancesQuoteTaxFee TaxFee { get; set; } = null!;
    }
}
