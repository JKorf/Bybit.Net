using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// UTA loan position tiers of an asset
    /// </summary>
    [SerializationModel]
    public record BybitSpotMarginPositionTiers
    {
        /// <summary>
        /// ["<c>currency</c>"] Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>positionTiersRatioList</c>"] Position tiers, from small to large
        /// </summary>
        [JsonPropertyName("positionTiersRatioList")]
        public BybitSpotMarginPositionTier[] Tiers { get; set; } = [];
    }

    /// <summary>
    /// Position tier info
    /// </summary>
    [SerializationModel]
    public record BybitSpotMarginPositionTier
    {
        /// <summary>
        /// ["<c>tier</c>"] Tier number
        /// </summary>
        [JsonPropertyName("tier")]
        public int Tier { get; set; }
        /// <summary>
        /// ["<c>borrowLimit</c>"] Accumulated borrow limit of the tier
        /// </summary>
        [JsonPropertyName("borrowLimit")]
        public decimal BorrowLimit { get; set; }
        /// <summary>
        /// ["<c>positionMMR</c>"] Loan maintenance margin rate
        /// </summary>
        [JsonPropertyName("positionMMR")]
        public decimal MaintenanceMarginRate { get; set; }
        /// <summary>
        /// ["<c>positionIMR</c>"] Loan initial margin rate
        /// </summary>
        [JsonPropertyName("positionIMR")]
        public decimal InitialMarginRate { get; set; }
        /// <summary>
        /// ["<c>maxLeverage</c>"] Max loan leverage
        /// </summary>
        [JsonPropertyName("maxLeverage")]
        public decimal MaxLeverage { get; set; }
    }
}
