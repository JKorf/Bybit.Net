using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Margin data
    /// </summary>
    [SerializationModel]
    internal record BybitSpotMarginVipMarginData
    {
        [JsonPropertyName("vipCoinList")]
        public BybitSpotMarginVipMarginList[] VipCoinList { get; set; } = null!;
    }

    /// <summary>
    /// Margin data
    /// </summary>
    [SerializationModel]
    public record BybitSpotMarginVipMarginList
    {
        /// <summary>
        /// VIP level
        /// </summary>
        [JsonPropertyName("vipLevel")]
        public string VipLevel { get; set; } = string.Empty;
        /// <summary>
        /// Assets
        /// </summary>
        [JsonPropertyName("list")]
        public BybitSpotMarginVipMarginItem[] Assets { get; set; } = Array.Empty<BybitSpotMarginVipMarginItem>();
    }

    /// <summary>
    /// Margin item
    /// </summary>
    [SerializationModel]
    public record BybitSpotMarginVipMarginItem
    {
        /// <summary>
        /// Whether the asset is allowed to be borrowed
        /// </summary>
        [JsonPropertyName("borrowable")]
        public bool Borrowable { get; set; }
        /// <summary>
        /// Collateral ratio
        /// </summary>
        [JsonPropertyName("collateralRatio")]
        public decimal Collateralratio { get; set; }
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Borrow interest rate per hour
        /// </summary>
        [JsonPropertyName("hourlyBorrowRate")]
        public decimal? HourlyBorrowRate { get; set; }
        /// <summary>
        /// Liquidation order
        /// </summary>
        [JsonPropertyName("liquidationOrder")]
        public decimal LiquidationOrder { get; set; }
        /// <summary>
        /// Whether it can be used as a margin collateral asset
        /// </summary>
        [JsonPropertyName("marginCollateral")]
        public bool MarginCollateral { get; set; }
        /// <summary>
        /// Max borrow amount
        /// </summary>
        [JsonPropertyName("maxBorrowingAmount")]
        public decimal? MaxBorrowingQuantity { get; set; }
    }
}
