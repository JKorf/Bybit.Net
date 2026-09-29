using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Fee info
    /// </summary>
    [SerializationModel]
    public record BybitFeeRate
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>baseCoin</c>"] Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string? BaseAsset { get; set; }
        /// <summary>
        /// ["<c>takerFeeRate</c>"] Taker fee rate
        /// </summary>
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>makerFeeRate</c>"] Maker fee rate
        /// </summary>
        [JsonPropertyName("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>rpiMakerRebate</c>"] RPI maker rebate
        /// </summary>
        [JsonPropertyName("rpiMakerRebate")]
        public decimal? RpiMakerRebate { get; set; }
    }
}
