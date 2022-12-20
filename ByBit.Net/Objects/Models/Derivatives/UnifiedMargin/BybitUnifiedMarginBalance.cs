using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Wallet info
    /// </summary>
    public class BybitUnifiedMarginBalance
    {
        /// <summary>
        /// Initial margin rate: Account Total Initial Margin Base Coin / Account Margin Balance Base Coin
        /// </summary>
        [JsonProperty("accountIMRate")]
        public decimal InitialMarginRate { get; set; }

        /// <summary>
        /// Maintenance margin rate: Account Total Maintenance Margin Base Coin / Account Margin Balance Base Coin
        /// </summary>
        [JsonProperty("accountMMRate")]
        public decimal MaintenanceMarginRate { get; set; }

        /// <summary>
        /// Equity of the account converted into USD: Account Margin Balance Base Coin + Account Option Value Base Coin
        /// </summary>
        [JsonProperty("totalEquity")]
        public decimal Equity { get; set; }

        /// <summary>
        /// Wallet balance of the account converted into USD: ∑ Asset Wallet Balance Base Coin
        /// </summary>
        [JsonProperty("totalWalletBalance")]
        public decimal WalletBalance { get; set; }

        /// <summary>
        /// Margin balance of the account converted into USD: Account Wallet Balance Base Coin + Account Perp UPL Base Coin
        /// </summary>
        [JsonProperty("totalMarginBalance")]
        public decimal MarginBalance { get; set; }

        /// <summary>
        /// Available balance of the account converted into USD: RM: Account Margin Balance Base Coin - Account Initial Margin Base Coin
        /// </summary>
        [JsonProperty("totalAvailableBalance")]
        public decimal AvailableBalance { get; set; }

        /// <summary>
        /// Perpetual floating PnL of the account converted into USD: ∑ Asset Perp UPL Base Coin
        /// </summary>
        [JsonProperty("totalPerpUPL")]
        public decimal PerpetualFloatingPnL { get; set; }

        /// <summary>
        /// Total initial margin of the account converted into USD: ∑ Asset Total Initial Margin Base Coin
        /// </summary>
        public decimal TotalInitialMargin { get; set; }

        /// <summary>
        /// Total maintenance margin of the account converted into USD: ∑ Asset Total Maintenance Margin Base Coin
        /// </summary>
        public decimal TotalMaintenanceMargin { get; set; }

        /// <summary>
        /// Wallet info about assets
        /// </summary>
        [JsonProperty("coin")]
        public IEnumerable<BybitUnifiedMarginAsset> Assets { get; set; } = new List<BybitUnifiedMarginAsset>();
    }

    /// <summary>
    /// Unified margin asset info
    /// </summary>
    public class BybitUnifiedMarginAsset
    {
        /// <summary>
        /// Name of coin in wallet, such as BTC, ETH, USDT, and USDC.
        /// </summary>
        [JsonProperty("currencyCoin")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// User assets
        /// </summary>
        public decimal Equity { get; set; }

        /// <summary>
        /// Value converted into USD
        /// </summary>
        public decimal USDValue { get; set; }

        /// <summary>
        /// Wallet balance
        /// </summary>
        public decimal WalletBalance { get; set; }

        /// <summary>
        /// MB from other assets + the actual MB balance from the current assets
        /// </summary>
        [JsonProperty("marginBalance")]
        public decimal MarginBalanceForAssets { get; set; }

        /// <summary>
        /// AB from other assets + the actual AB balance from the current assets (cannot be negative)
        /// </summary>
        public decimal AvailableBalance { get; set; }

        /// <summary>
        /// Margin balance
        /// </summary>
        [JsonProperty("marginBalanceWithoutConvert")]
        public decimal MarginBalance { get; set; }

        /// <summary>
        /// Available balance, Margin Balance - Total Initial Margin
        /// </summary>
        public decimal AvailableBalanceWithoutConvert { get; set; }

        /// <summary>
        /// Lending amount used.For USDC and USDT only. For BTC and ETH, return 0.
        /// </summary>
        [JsonProperty("borrowSize")]
        public decimal LendingAmount { get; set; }

        /// <summary>
        /// Lending amount available. For USDC and USDT only.For BTC and ETH, return 0.
        /// </summary>
        [JsonProperty("availableToBorrow")]
        public decimal AvailableLendingAmount { get; set; }

        /// <summary>
        /// Accrued interest of an asset
        /// </summary>
        public decimal AccruedInterest { get; set; }

        /// <summary>
        /// Order margin pre-occupied
        /// </summary>
        [JsonProperty("totalOrderIM")]
        public decimal? PreoccupiedOrderMargin { get; set; }

        /// <summary>
        /// ∑ Initial margin of all positions + pre-occupied trading fee for closing positions
        /// </summary>
        [JsonProperty("totalPositionIM")]
        public decimal? InitialMargin { get; set; }

        /// <summary>
        /// Maintenance margin of all positions
        /// </summary>
        [JsonProperty("totalPositionMM")]
        public decimal MaintenanceMargin { get; set; }

        /// <summary>
        /// Unrealized PnL
        /// </summary>
        public decimal UnrealisedPnL { get; set; }

        /// <summary>
        /// Accumulatively realized PnL
        /// </summary>
        [JsonProperty("cumRealisedPnl")]
        public decimal AccumulativelyRealizedPnL { get; set; }
    }
}
