using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Announcmeent
    /// </summary>
    public class BybitAnnouncement
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = string.Empty;
        /// <summary>
        /// Announcement time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("dateTimestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Start time of the announcement
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("startDateTimestamp")]
        public DateTime? StartTimestamp { get; set; }
        /// <summary>
        /// End time of the announcement
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("endDateTimestamp")]
        public DateTime? EndTimestamp { get; set; }
        /// <summary>
        /// Tags
        /// </summary>
        public IEnumerable<string> Tags { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Type
        /// </summary>
        public Dictionary<string, string> Type { get; set; } = new Dictionary<string, string>();
    }
}
