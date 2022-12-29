using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Transaction log info
    /// </summary>
    public class BybitUnifiedMarginTransactionLog
    {
        /// <summary>
        /// Trade ID
        /// </summary>
        public string TradeID { get; set; } = string.Empty;

        /// <summary>
        /// Order ID
        /// </summary>
        public string OrderID { get; set; } = string.Empty;

        /// <summary>
        /// Institutional customized order ID
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string ClientOrderId { get; set; } = string.Empty;

        /// <summary>
        /// Type of derivatives product: linear or option
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [JsonConverter(typeof(TradeTypeConverter))]
        public TradeType Type { get; set; }

        /// <summary>
        /// USDC, USDT, BTC, and ETH
        /// </summary>
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// Name of Contract
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Create time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime TransactionTime { get; set; }

        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Position size
        /// </summary>
        public decimal Size { get; set; }

        /// <summary>
        /// Trading price
        /// </summary>
        public decimal? TradePrice { get; set; }

        /// <summary>
        /// Funding
        /// </summary>
        public decimal? Funding { get; set; }

        /// <summary>
        /// Trading fee
        /// </summary>
        /// <remarks> The fee to collect the asset.A positive number means that the user pays a trading fee of xx, while a negative number denotes that the user earns the fee. </remarks>
        public decimal? Fee { get; set; }

        /// <summary>
        /// Cash Flow
        /// </summary>
        public decimal? CashFlow { get; set; }

        /// <summary>
        /// Change
        /// </summary>
        public decimal? Change { get; set; }

        /// <summary>
        /// Balance (current asset)
        /// </summary>
        public decimal? CashBalance { get; set; }

        /// <summary>
        /// Fee rate
        /// </summary>
        public decimal? FeeRate { get; set; }
    }
}
