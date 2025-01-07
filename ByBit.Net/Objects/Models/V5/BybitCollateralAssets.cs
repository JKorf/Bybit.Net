using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Collateral asset info
    /// </summary>
    internal record BybitCollateralAssets
    {
        [JsonPropertyName("vipCoinList")]
        public IEnumerable<BybitCollateralAsset> Assets { get; set; } = [];
    }

    /// <summary>
    /// Collateral asset info
    /// </summary>
    public record BybitCollateralAsset
    {
        /// <summary>
        /// Account level
        /// </summary>
        [JsonPropertyName("vipLevel")]
        public AccountLevel AccountLevel { get; set; }
        /// <summary>
        /// Assets list
        /// </summary>
        [JsonPropertyName("list")]
        public IEnumerable<BybitCollateralAssetInfo> Assets { get; set; } = [];
    }

    /// <summary>
    /// Collateral asset info
    /// </summary>
    public record BybitCollateralAssetInfo
    {
        /// <summary>
        /// Precision for collateral
        /// </summary>
        [JsonPropertyName("collateralAccuracy")]
        public int CollateralAccuracy { get; set; }
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Initial LTV
        /// </summary>
        [JsonPropertyName("initialLTV")]
        public decimal InitialLtv { get; set; }
        /// <summary>
        /// Liquidation LTV
        /// </summary>
        [JsonPropertyName("liquidationLTV")]
        public decimal LiquidationLtv { get; set; }
        /// <summary>
        /// Margin call LTV
        /// </summary>
        [JsonPropertyName("marginCallLTV")]
        public decimal MarginCallLtv { get; set; }
        /// <summary>
        /// Max Limit
        /// </summary>
        [JsonPropertyName("maxLimit")]
        public decimal MaxLimit { get; set; }
    }
}
