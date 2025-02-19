using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Asset collateral ratio
    /// </summary>
    public record BybitSpotMarginCollateralRatio
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Collateral ratios
        /// </summary>
        [JsonPropertyName("collateralRatioList")]
        public IEnumerable<BybitSpotMarginCollateralRatioTier> CollateralRatios { get; set; } = [];
    }

    /// <summary>
    /// Collateral ratio info
    /// </summary>
    public record BybitSpotMarginCollateralRatioTier
    {
        /// <summary>
        /// Lower limit of the tiered range
        /// </summary>
        [JsonPropertyName("minQty")]
        public decimal MinQuantity { get; set; }
        /// <summary>
        /// Upper limit of the tiered range, null means positive infinity
        /// </summary>
        [JsonPropertyName("maxQty")]
        public decimal? MaxQuantity { get; set; }
        /// <summary>
        /// Collateral ratio
        /// </summary>
        [JsonPropertyName("collateralRatio")]
        public decimal CollateralRatio { get; set; }
    }
}
