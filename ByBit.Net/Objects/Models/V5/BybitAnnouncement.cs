using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Announcmeent
    /// </summary>
    [SerializationModel]
    public record BybitAnnouncement
    {
        /// <summary>
        /// Title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
        /// <summary>
        /// Announcement time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("dateTimestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Publish time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("publishTime")]
        public DateTime? PublishTime { get; set; }
        /// <summary>
        /// Start time of the announcement
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("startDateTimestamp")]
        public DateTime? StartTimestamp { get; set; }
        /// <summary>
        /// End time of the announcement
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("endDateTimestamp")]
        public DateTime? EndTimestamp { get; set; }
        /// <summary>
        /// Tags
        /// </summary>
        [JsonPropertyName("tags")]
        public string[] Tags { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Type
        /// </summary>
        [JsonPropertyName("type")]
        public Dictionary<string, string> Type { get; set; } = new Dictionary<string, string>();
    }
}
