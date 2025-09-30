using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Balance info
    /// </summary>
    [SerializationModel]
    public record BybitBalance
    {
        /// <summary>
        /// Account type
        /// </summary>

        [JsonPropertyName("accountType")]
        public AccountType AccountType { get; set; }
        /// <summary>
        /// Account LTV
        /// </summary>
        [JsonPropertyName("accountLTV")]
        public decimal? AccountLtv { get; set; }
        /// <summary>
        /// Account initial margin rate
        /// </summary>
        [JsonPropertyName("accountIMRate")]
        public decimal? AccountInitialMarginRate { get; set; }
        /// <summary>
        /// Account initial margin rate by mark price
        /// </summary>
        [JsonPropertyName("accountIMRateByMp")]
        public decimal? AccountInitialMarginRateByMarkPrice { get; set; }
        /// <summary>
        /// Account maintenance margin rate
        /// </summary>
        [JsonPropertyName("accountMMRate")]
        public decimal? AccountMaintenanceMarginRate { get; set; }
        /// <summary>
        /// Account maintenance margin rate by mark price
        /// </summary>
        [JsonPropertyName("accountMMRateByMp")]
        public decimal? AccountMaintenanceMarginRateByMarkPrice { get; set; }
        /// <summary>
        /// Account equity in USD
        /// </summary>
        [JsonPropertyName("totalEquity")]
        public decimal? TotalEquity { get; set; }
        /// <summary>
        /// Total wallet balance in USD
        /// </summary>
        [JsonPropertyName("totalWalletBalance")]
        public decimal? TotalWalletBalance { get; set; }
        /// <summary>
        /// Total margin balance in USD
        /// </summary>
        [JsonPropertyName("totalMarginBalance")]
        public decimal? TotalMarginBalance { get; set; }
        /// <summary>
        /// Total available balance in USD
        /// </summary>
        [JsonPropertyName("totalAvailableBalance")]
        public decimal? TotalAvailableBalance { get; set; }
        /// <summary>
        /// Unrealized profit and loss in USD
        /// </summary>
        [JsonPropertyName("totalPerpUPL")]
        public decimal? TotalPerpUnrealizedPnl { get; set; }
        /// <summary>
        /// Initial margin in USD
        /// </summary>
        [JsonPropertyName("totalInitialMargin")]
        public decimal? TotalInitialMargin { get; set; }
        /// <summary>
        /// Initial margin in USD by mark price
        /// </summary>
        [JsonPropertyName("totalInitialMarginByMp")]
        public decimal? TotalInitialMarginByMarkPrice { get; set; }
        /// <summary>
        /// Maintenance margin in USD
        /// </summary>
        [JsonPropertyName("totalMaintenanceMargin")]
        public decimal? TotalMaintenanceMargin { get; set; }
        /// <summary>
        /// Maintenance margin in USD by mark price
        /// </summary>
        [JsonPropertyName("totalMaintenanceMarginByMp")]
        public decimal? TotalMaintenanceMarginByMarkPrice { get; set; }
        /// <summary>
        /// Asset info
        /// </summary>
        [JsonPropertyName("coin")]
        public BybitAssetBalance[] Assets { get; set; } = Array.Empty<BybitAssetBalance>();
    }

    /// <summary>
    /// Asset balance info
    /// </summary>
    [SerializationModel]
    public record BybitAssetBalance
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Asset equity
        /// </summary>
        [JsonPropertyName("equity")]
        public decimal? Equity { get; set; }
        /// <summary>
        /// Asset usd value
        /// </summary>
        [JsonPropertyName("usdValue")]
        public decimal? UsdValue { get; set; }
        /// <summary>
        /// Asset balance
        /// </summary>
        [JsonPropertyName("walletBalance")]
        public decimal? WalletBalance { get; set; }
        /// <summary>
        /// [Spot] Available balance
        /// </summary>
        [JsonPropertyName("free")]
        public decimal? Free { get; set; }
        /// <summary>
        /// [Spot] Locked balance
        /// </summary>
        [JsonPropertyName("locked")]
        public decimal? Locked { get; set; }
        /// <summary>
        /// Borrow amount
        /// </summary>
        [JsonPropertyName("borrowAmount")]
        public decimal? BorrowAmount { get; set; }
        /// <summary>
        /// Available borrow amount
        /// </summary>
        [JsonPropertyName("availableToBorrow")]
        public decimal? AvailableToBorrow { get; set; }
        /// <summary>
        /// Available withdrawal amount, not available for Unified account
        /// </summary>
        [JsonPropertyName("availableToWithdraw")]
        public decimal? AvailableToWithdraw { get; set; }
        /// <summary>
        /// Accrued interest
        /// </summary>
        [JsonPropertyName("accruedInterest")]
        public decimal? AccruedInterest { get; set; }
        /// <summary>
        /// Total order initial margin
        /// </summary>
        [JsonPropertyName("totalOrderIM")]
        public decimal? TotalOrderInitialMargin { get; set; }
        /// <summary>
        /// Total position maintenance margin
        /// </summary>
        [JsonPropertyName("totalPositionIM")]
        public decimal? TotalPositionInitialMargin { get; set; }
        /// <summary>
        /// Total position maintenance margin
        /// </summary>
        [JsonPropertyName("totalPositionMM")]
        public decimal? TotalPositionMaintenanceMargin { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        [JsonPropertyName("unrealisedPnl")]
        public decimal? UnrealizedPnl { get; set; }
        /// <summary>
        /// Realized profit and loss
        /// </summary>
        [JsonPropertyName("cumRealisedPnl")]
        public decimal? RealizedPnl { get; set; }
        /// <summary>
        /// [Unified] Bonus
        /// </summary>
        [JsonPropertyName("bonus")]
        public decimal? Bonus { get; set; }
        /// <summary>
        /// [Unified] The spot asset quantity that is used to hedge in the portfolio margin, truncate to 8 decimals and "0" by default
        /// </summary>
        [JsonPropertyName("spotHedgingQty")]
        public decimal? SpotHedgingQuantity { get; set; }
        /// <summary>
        /// Whether it can be used as a margin collateral currency
        /// </summary>
        [JsonPropertyName("collateralSwitch")]
        public bool CollateralSwitch { get; set; }
        /// <summary>
        /// Whether the collateral is turned on by user (user)
        /// </summary>
        [JsonPropertyName("marginCollateral")]
        public bool MarginCollateral { get; set; }
        /// <summary>
        /// Borrow amount by spot margin trade
        /// </summary>
        [JsonPropertyName("spotBorrow")]
        public decimal SpotBorrow { get; set; }
    }
}
