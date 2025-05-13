using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Marging status
    /// </summary>
    [SerializationModel]
    public record BybitSpotMarginStatus
    {
        /// <summary>
        /// Is spot margin mode activated
        /// </summary>
        [JsonPropertyName("spotMarginMode"), JsonConverter(typeof(BoolConverter))]
        public bool SpotMarginMode { get; set; }
    }
}
