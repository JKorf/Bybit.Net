using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Borrow record
    /// </summary>
    public class BybitUnifiedMarginBorrowRecord
    {
        /// <summary>
        /// USDC, USDT, BTC, and ETH
        /// </summary>+
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("createdTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Hourly interest rate
        /// </summary>
        public decimal HourlyBorrowRate { get; set; }

        /// <summary>
        /// Interest rate
        /// </summary>
        public decimal BorrowCost { get; set; }

        /// <summary>
        /// Interest bearing loan size
        /// </summary>
        public decimal InterestBearingBorrowSize { get; set; }

        /// <summary>
        /// Waiver of interest-bearing costs
        /// </summary>
        public decimal CostExemption { get; set; }
    }
}
