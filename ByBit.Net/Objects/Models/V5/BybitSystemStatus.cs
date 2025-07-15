using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// System status info
    /// </summary>
    public record BybitSystemStatus
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("state")]
        public SystemStatus Status { get; set; }
        /// <summary>
        /// Begin time
        /// </summary>
        [JsonPropertyName("begin")]
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// End time
        /// </summary>
        [JsonPropertyName("end")]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// Link
        /// </summary>
        [JsonPropertyName("href")]
        public string? Link { get; set; }
        /// <summary>
        /// Service types
        /// </summary>
        [JsonPropertyName("serviceTypes")]
        public ServiceType[] ServiceTypes { get; set; } = [];
        /// <summary>
        /// Product
        /// </summary>
        [JsonPropertyName("product")]
        public ProductType[] Product { get; set; } = [];
        /// <summary>
        /// Uid suffix
        /// </summary>
        [JsonPropertyName("uidSuffix")]
        public string[] UidSuffix { get; set; } = [];
        /// <summary>
        /// Maintenance type
        /// </summary>
        [JsonPropertyName("maintainType")]
        public MaintenanceType MaintenanceType { get; set; }
        /// <summary>
        /// Environment
        /// </summary>
        [JsonPropertyName("env")]
        public SystemEnvironment Environment { get; set; }
    }


}
