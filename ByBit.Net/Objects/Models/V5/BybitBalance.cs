using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Balance info
    /// </summary>
    public class BybitBalance
    {
        /// <summary>
        /// Account type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public AccountType AccountType { get; set; }
        /// <summary>
        /// Account LTV
        /// </summary>
        public decimal? AccountLtv { get; set; }
        /// <summary>
        /// Account initial margin rate
        /// </summary>
        [JsonProperty("accountIMRate")]
        public decimal? AccountInitialMarginRate { get; set; }
        /// <summary>
        /// Account maintenance margin rate
        /// </summary>
        [JsonProperty("accountMMRate")]
        public decimal? AccountMaintenanceMarginRate { get; set; }
        /// <summary>
        /// Account equity in USD
        /// </summary>
        [JsonProperty("totalEquity")]
        public decimal? TotalEquity { get; set; }
        /// <summary>
        /// Total wallet balance in USD
        /// </summary>
        [JsonProperty("totalWalletBalance")]
        public decimal? TotalWalletBalance { get; set; }
        /// <summary>
        /// Total margin balance in USD
        /// </summary>
        [JsonProperty("totalMarginBalance")]
        public decimal? TotalMarginBalance { get; set; }
        /// <summary>
        /// Total available balance in USD
        /// </summary>
        [JsonProperty("totalAvailableBalance")]
        public decimal? TotalAvailableBalance { get; set; }
        /// <summary>
        /// Unrealized profit and loss in USD
        /// </summary>
        [JsonProperty("totalPerpUPL")]
        public decimal? TotalPerpUnrealizedPnl { get; set; }
        /// <summary>
        /// Iniital margin in USD
        /// </summary>
        [JsonProperty("totalInitialMargin")]
        public decimal? TotalInitialMargin { get; set; }
        /// <summary>
        /// Maintenance margin in USD
        /// </summary>
        [JsonProperty("totalMaintenanceMargin")]
        public decimal? TotalMaintenanceMargin { get; set; }
        /// <summary>
        /// Asset info
        /// </summary>
        [JsonProperty("coin")]
        public IEnumerable<BybitAssetBalance> Assets { get; set; } = Array.Empty<BybitAssetBalance>();
    }

    /// <summary>
    /// Asset balance info
    /// </summary>
    public class BybitAssetBalance
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Asset equity
        /// </summary>
        [JsonProperty("equity")]
        public decimal? Equity { get; set; }
        /// <summary>
        /// Asset usd value
        /// </summary>
        [JsonProperty("usdValue")]
        public decimal? UsdValue { get; set; }
        /// <summary>
        /// Asset balance
        /// </summary>
        [JsonProperty("walletBalance")]
        public decimal WalletBalance { get; set; }
        /// <summary>
        /// [Spot] Available balance
        /// </summary>
        [JsonProperty("free")]
        public decimal? Free { get; set; }
        /// <summary>
        /// [Spot] Locked balance
        /// </summary>
        [JsonProperty("locked")]
        public decimal? Locked { get; set; }
        /// <summary>
        /// Borrow amount
        /// </summary>
        [JsonProperty("borrowAmount")]
        public decimal? BorrowAmount { get; set; }
        /// <summary>
        /// Available borrow amount
        /// </summary>
        [JsonProperty("availableToBorrow")]
        public decimal? AvailableToBorrow { get; set; }
        /// <summary>
        /// Available withdrawal amount
        /// </summary>
        [JsonProperty("availableToWithdraw")]
        public decimal? AvailableToWithdraw { get; set; }
        /// <summary>
        /// Accrued interest
        /// </summary>
        [JsonProperty("accruedInterest")]
        public decimal? AccruedInterest { get; set; }
        /// <summary>
        /// Total order initial margin
        /// </summary>
        [JsonProperty("totalOrderIM")]
        public decimal? TotalOrderInitialMargin { get; set; }
        /// <summary>
        /// Total position maintenance marging
        /// </summary>
        [JsonProperty("totalPositionIM")]
        public decimal? TotalPositionInitialMargin { get; set; }
        /// <summary>
        /// Total position maintenance margin
        /// </summary>
        [JsonProperty("totalPositionMM")]
        public decimal? TotalPositionMaintenanceMargin { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        [JsonProperty("unrealisedPnl")]
        public decimal? UnrealizedPnl { get; set; }
        /// <summary>
        /// Realized profit and loss
        /// </summary>
        [JsonProperty("cumRealisedPnl")]
        public decimal? RealizedPnl { get; set; }
        /// <summary>
        /// [Unified] Bonus
        /// </summary>
        public decimal? Bonus { get; set; }
    }
}
