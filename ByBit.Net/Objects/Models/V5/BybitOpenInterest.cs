using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Open interest at a time
    /// </summary>
    [SerializationModel]
    public record BybitOpenInterest
    {
        /// <summary>
        /// ["<c>openInterest</c>"] Open interest
        /// </summary>
        [JsonPropertyName("openInterest")]
        public decimal OpenInterest { get; set; }
        /// <summary>
        /// ["<c>timestamp</c>"] Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// ["<c>singleOpenInterest</c>"] Single open interest
        /// </summary>
        [JsonPropertyName("singleOpenInterest")]
        public decimal? SingleOpenInterest { get; set; }
    }
}
