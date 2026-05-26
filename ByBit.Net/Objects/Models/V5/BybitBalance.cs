using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Balance info
    /// </summary>
    [SerializationModel]
    public record BybitBalance
    {
        /// <summary>
        /// ["<c>accountType</c>"] Account type
        /// </summary>

        [JsonPropertyName("accountType")]
        public AccountType AccountType { get; set; }
        /// <summary>
        /// ["<c>accountLTV</c>"] Account LTV
        /// </summary>
        [JsonPropertyName("accountLTV")]
        public decimal? AccountLtv { get; set; }
        /// <summary>
        /// ["<c>accountIMRate</c>"] Account initial margin rate
        /// </summary>
        [JsonPropertyName("accountIMRate")]
        public decimal? AccountInitialMarginRate { get; set; }
        /// <summary>
        /// ["<c>accountIMRateByMp</c>"] Account initial margin rate by mark price
        /// </summary>
        [JsonPropertyName("accountIMRateByMp")]
        public decimal? AccountInitialMarginRateByMarkPrice { get; set; }
        /// <summary>
        /// ["<c>accountMMRate</c>"] Account maintenance margin rate
        /// </summary>
        [JsonPropertyName("accountMMRate")]
        public decimal? AccountMaintenanceMarginRate { get; set; }
        /// <summary>
        /// ["<c>accountMMRateByMp</c>"] Account maintenance margin rate by mark price
        /// </summary>
        [JsonPropertyName("accountMMRateByMp")]
        public decimal? AccountMaintenanceMarginRateByMarkPrice { get; set; }
        /// <summary>
        /// ["<c>totalEquity</c>"] Account equity in USD
        /// </summary>
        [JsonPropertyName("totalEquity")]
        public decimal? TotalEquity { get; set; }
        /// <summary>
        /// ["<c>totalWalletBalance</c>"] Total wallet balance in USD
        /// </summary>
        [JsonPropertyName("totalWalletBalance")]
        public decimal? TotalWalletBalance { get; set; }
        /// <summary>
        /// ["<c>totalMarginBalance</c>"] Total margin balance in USD
        /// </summary>
        [JsonPropertyName("totalMarginBalance")]
        public decimal? TotalMarginBalance { get; set; }
        /// <summary>
        /// ["<c>totalAvailableBalance</c>"] Total available balance in USD
        /// </summary>
        [JsonPropertyName("totalAvailableBalance")]
        public decimal? TotalAvailableBalance { get; set; }
        /// <summary>
        /// ["<c>totalPerpUPL</c>"] Unrealized profit and loss in USD
        /// </summary>
        [JsonPropertyName("totalPerpUPL")]
        public decimal? TotalPerpUnrealizedPnl { get; set; }
        /// <summary>
        /// ["<c>totalInitialMargin</c>"] Initial margin in USD
        /// </summary>
        [JsonPropertyName("totalInitialMargin")]
        public decimal? TotalInitialMargin { get; set; }
        /// <summary>
        /// ["<c>totalInitialMarginByMp</c>"] Initial margin in USD by mark price
        /// </summary>
        [JsonPropertyName("totalInitialMarginByMp")]
        public decimal? TotalInitialMarginByMarkPrice { get; set; }
        /// <summary>
        /// ["<c>totalMaintenanceMargin</c>"] Maintenance margin in USD
        /// </summary>
        [JsonPropertyName("totalMaintenanceMargin")]
        public decimal? TotalMaintenanceMargin { get; set; }
        /// <summary>
        /// ["<c>totalMaintenanceMarginByMp</c>"] Maintenance margin in USD by mark price
        /// </summary>
        [JsonPropertyName("totalMaintenanceMarginByMp")]
        public decimal? TotalMaintenanceMarginByMarkPrice { get; set; }
        /// <summary>
        /// ["<c>coin</c>"] Asset info
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
        /// ["<c>coin</c>"] Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>equity</c>"] Asset equity
        /// </summary>
        [JsonPropertyName("equity")]
        public decimal? Equity { get; set; }
        /// <summary>
        /// ["<c>usdValue</c>"] Asset usd value
        /// </summary>
        [JsonPropertyName("usdValue")]
        public decimal? UsdValue { get; set; }
        /// <summary>
        /// ["<c>walletBalance</c>"] Asset balance
        /// </summary>
        [JsonPropertyName("walletBalance")]
        public decimal? WalletBalance { get; set; }
        /// <summary>
        /// ["<c>free</c>"] [Spot] Available balance
        /// </summary>
        [JsonPropertyName("free")]
        public decimal? Free { get; set; }
        /// <summary>
        /// ["<c>locked</c>"] [Spot] Locked balance
        /// </summary>
        [JsonPropertyName("locked")]
        public decimal? Locked { get; set; }
        /// <summary>
        /// ["<c>borrowAmount</c>"] Borrow amount
        /// </summary>
        [JsonPropertyName("borrowAmount")]
        public decimal? BorrowAmount { get; set; }
        /// <summary>
        /// ["<c>availableToBorrow</c>"] Available borrow amount
        /// </summary>
        [JsonPropertyName("availableToBorrow")]
        public decimal? AvailableToBorrow { get; set; }
        /// <summary>
        /// ["<c>availableToWithdraw</c>"] Available withdrawal amount, not available for Unified account
        /// </summary>
        [JsonPropertyName("availableToWithdraw")]
        public decimal? AvailableToWithdraw { get; set; }
        /// <summary>
        /// ["<c>accruedInterest</c>"] Accrued interest
        /// </summary>
        [JsonPropertyName("accruedInterest")]
        public decimal? AccruedInterest { get; set; }
        /// <summary>
        /// ["<c>totalOrderIM</c>"] Total order initial margin
        /// </summary>
        [JsonPropertyName("totalOrderIM")]
        public decimal? TotalOrderInitialMargin { get; set; }
        /// <summary>
        /// ["<c>totalPositionIM</c>"] Total position maintenance margin
        /// </summary>
        [JsonPropertyName("totalPositionIM")]
        public decimal? TotalPositionInitialMargin { get; set; }
        /// <summary>
        /// ["<c>totalPositionMM</c>"] Total position maintenance margin
        /// </summary>
        [JsonPropertyName("totalPositionMM")]
        public decimal? TotalPositionMaintenanceMargin { get; set; }
        /// <summary>
        /// ["<c>unrealisedPnl</c>"] Unrealized profit and loss
        /// </summary>
        [JsonPropertyName("unrealisedPnl")]
        public decimal? UnrealizedPnl { get; set; }
        /// <summary>
        /// ["<c>cumRealisedPnl</c>"] Realized profit and loss
        /// </summary>
        [JsonPropertyName("cumRealisedPnl")]
        public decimal? RealizedPnl { get; set; }
        /// <summary>
        /// ["<c>bonus</c>"] [Unified] Bonus
        /// </summary>
        [JsonPropertyName("bonus")]
        public decimal? Bonus { get; set; }
        /// <summary>
        /// ["<c>spotHedgingQty</c>"] [Unified] The spot asset quantity that is used to hedge in the portfolio margin, truncate to 8 decimals and "0" by default
        /// </summary>
        [JsonPropertyName("spotHedgingQty")]
        public decimal? SpotHedgingQuantity { get; set; }
        /// <summary>
        /// ["<c>collateralSwitch</c>"] Whether it can be used as a margin collateral currency
        /// </summary>
        [JsonPropertyName("collateralSwitch")]
        public bool CollateralSwitch { get; set; }
        /// <summary>
        /// ["<c>colRes</c>"] Collateral restriction status
        /// </summary>
        [JsonPropertyName("colRes")]
        public string CollateralRestriction { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>marginCollateral</c>"] Whether the collateral is turned on by user (user)
        /// </summary>
        [JsonPropertyName("marginCollateral")]
        public bool MarginCollateral { get; set; }
        /// <summary>
        /// ["<c>spotBorrow</c>"] Borrow amount by spot margin trade
        /// </summary>
        [JsonPropertyName("spotBorrow")]
        public decimal SpotBorrow { get; set; }
    }
}
