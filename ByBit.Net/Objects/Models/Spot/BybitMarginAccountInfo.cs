using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Margin account info
    /// </summary>
    public class BybitMarginAccountInfo
    {
        /// <summary>
        /// Account status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public MarginAccountStatus Status { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public RiskRate RiskRate { get; set; }
        /// <summary>
        /// Total Equity (BTC)
        /// </summary>
        [JsonProperty("acctBalanceSum")]
        public decimal AccountBalanceTotal { get; set; }
        /// <summary>
        /// Total Liability (BTC)
        /// </summary>
        [JsonProperty("debtBalanceSum")]
        public decimal DebtBalanceTotal { get; set; }
        /// <summary>
        /// Loan accounts
        /// </summary>
        [JsonProperty("loanAccountList")]
        public IEnumerable<BybitLoanAccount> LoanAccounts { get; set; } = Array.Empty<BybitLoanAccount>();
    }

    /// <summary>
    /// Loan account info
    /// </summary>
    public class BybitLoanAccount
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("tokenId")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Total
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// Free
        /// </summary>
        public decimal Free { get; set; }
        /// <summary>
        /// Locked
        /// </summary>
        public decimal Locked { get; set; }
        /// <summary>
        /// Total liability
        /// </summary>
        public decimal Loan { get; set; }
        /// <summary>
        /// Interest left
        /// </summary>
        public decimal Interest { get; set; }
    }
}
