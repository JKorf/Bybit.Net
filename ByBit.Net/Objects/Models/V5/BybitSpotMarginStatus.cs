using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Marging status
    /// </summary>
    public record BybitSpotMarginStatus
    {
        /// <summary>
        /// Is spot margin mode activated
        /// </summary>
        [JsonPropertyName("spotMarginMode"), JsonConverter(typeof(BoolConverter))]
        public bool SpotMarginMode { get; set; }
    }
}
