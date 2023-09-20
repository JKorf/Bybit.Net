using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Margin data
    /// </summary>
    internal class BybitSpotMarginVipMarginData
    {
        [JsonProperty("vipCoinList")]
        public IEnumerable<BybitSpotMarginVipMarginList> VipCoinList { get; set; } = null!;
    }

    /// <summary>
    /// Margin data
    /// </summary>
    public class BybitSpotMarginVipMarginList
    {
        /// <summary>
        /// VIP level
        /// </summary>
        [JsonProperty("vipLevel")]
        public string VipLevel { get; set; } = string.Empty;
        /// <summary>
        /// Assets
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitSpotMarginVipMarginItem> Assets { get; set; } = Array.Empty<BybitSpotMarginVipMarginItem>();
    }

    /// <summary>
    /// Margin item
    /// </summary>
    public class BybitSpotMarginVipMarginItem
    {
        /// <summary>
        /// Whether the asset is allowed to be borrowed
        /// </summary>
        [JsonProperty("borrowable")]
        public bool Borrowable { get; set; }
        /// <summary>
        /// Collateral ratio
        /// </summary>
        [JsonProperty("collateralRatio")]
        public decimal Collateralratio { get; set; }
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Borrow interest rate per hour
        /// </summary>
        [JsonProperty("hourlyBorrowRate")]
        public decimal? HourlyBorrowRate { get; set; }
        /// <summary>
        /// Liquidation order
        /// </summary>
        [JsonProperty("liquidationOrder")]
        public decimal LiquidationOrder { get; set; }
        /// <summary>
        /// Whether it can be used as a margin collateral asset
        /// </summary>
        [JsonProperty("marginCollateral")]
        public bool MarginCollateral { get; set; }
        /// <summary>
        /// Max borrow amount
        /// </summary>
        [JsonProperty("maxBorrowingAmount")]
        public decimal? MaxBorrowingQuantity { get; set; }
    }
}
