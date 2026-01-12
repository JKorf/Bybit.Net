using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    internal record BybitSpotMarginAutoRepayModeWrapper
    {
        [JsonPropertyName("data")]
        public BybitSpotMarginAutoRepayMode[] Data { get; set; } = null!;
    }

    /// <summary>
    /// Spot margin auto repay mode
    /// </summary>
    public record BybitSpotMarginAutoRepayMode
    {
        /// <summary>
        /// The asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Auto repay mode enabled
        /// </summary>
        [JsonPropertyName("autoRepayMode")]
        public bool AutoRepayModeEnabled { get; set; }
    }
}
