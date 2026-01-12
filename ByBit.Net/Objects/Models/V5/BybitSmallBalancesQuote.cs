using Bybit.Net.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Small balances quote
    /// </summary>
    public record BybitSmallBalancesQuote
    {
        /// <summary>
        /// Quote id
        /// </summary>
        [JsonPropertyName("quoteId")]
        public string QuoteId { get; set; } = string.Empty;
        /// <summary>
        /// Quote info
        /// </summary>
        [JsonPropertyName("result")]
        public BybitSmallBalancesQuoteInfo Result { get; set; } = null!;
    }

    /// <summary>
    /// Quote info
    /// </summary>
    public record BybitSmallBalancesQuoteInfo
    {
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("quoteCreateTime")]
        public DateTime QuoteCreateTime { get; set; }
        /// <summary>
        /// Expire time
        /// </summary>
        [JsonPropertyName("quoteExpireTime")]
        public DateTime QuoteExpireTime { get; set; }
        /// <summary>
        /// Exchange assets
        /// </summary>
        [JsonPropertyName("exchangeCoins")]
        public BybitSmallBalancesQuoteAsset[] ExchangeAssets { get; set; } = [];
        /// <summary>
        /// Fee info
        /// </summary>
        [JsonPropertyName("totalFeeInfo")]
        public BybitSmallBalancesQuoteFee TotalFee { get; set; } = null!;
        /// <summary>
        /// Tax fee info
        /// </summary>
        [JsonPropertyName("totalTaxFeeInfo")]
        public BybitSmallBalancesQuoteTaxFee TotalTaxFee { get; set; } = null!;
    }

    /// <summary>
    /// Fee info
    /// </summary>
    public record BybitSmallBalancesQuoteFee
    {
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonPropertyName("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Fee rate
        /// </summary>
        [JsonPropertyName("feeRate")]
        public decimal FeeRate { get; set; }
    }

    /// <summary>
    /// Tax fee info
    /// </summary>
    public record BybitSmallBalancesQuoteTaxFee
    {
        /// <summary>
        /// Total quantity
        /// </summary>
        [JsonPropertyName("totalAmount")]
        public decimal TotalQuantity { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonPropertyName("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
    }

    /// <summary>
    /// Asset info
    /// </summary>
    public record BybitSmallBalancesQuoteAsset
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
        /// Available balance
        /// </summary>
        [JsonPropertyName("availableBalance")]
        public decimal AvailableBalance { get; set; }
        /// <summary>
        /// USDT value
        /// </summary>
        [JsonPropertyName("baseValue")]
        public decimal BaseValue { get; set; }
        /// <summary>
        /// Conversion is supported
        /// </summary>
        [JsonConverter(typeof(Bool12Converter))]
        [JsonPropertyName("supportConvert")]
        public bool Supported { get; set; }
        /// <summary>
        /// Output quantity
        /// </summary>
        [JsonPropertyName("toAmount")]
        public decimal ToQuantity { get; set; }
        /// <summary>
        /// Exchange rate
        /// </summary>
        [JsonPropertyName("exchangeRate")]
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// Fee info
        /// </summary>
        [JsonPropertyName("feeInfo")]
        public BybitSmallBalancesQuoteFee Fee { get; set; } = null!;
        /// <summary>
        /// Tax fee info
        /// </summary>
        [JsonPropertyName("taxFeeInfo")]
        public BybitSmallBalancesQuoteTaxFee TaxFee { get; set; } = null!;
    }
}
