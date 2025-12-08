using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Result
    /// </summary>
    [SerializationModel]
    public record BybitOperationResult
    {
        /// <summary>
        /// Success
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Success { get; set; }
    }
}
