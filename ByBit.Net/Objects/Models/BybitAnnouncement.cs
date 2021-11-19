using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Announcement
    /// </summary>
    public class BybitAnnouncement
    {
        /// <summary>
        /// Announcement id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Link
        /// </summary>
        public string Link { get; set; } = string.Empty;
        /// <summary>
        /// Summary
        /// </summary>
        public string Summary { get; set; } = string.Empty;
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreateTime { get; set; }
    }
}
