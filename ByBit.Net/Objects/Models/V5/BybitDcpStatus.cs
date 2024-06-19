using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.V5
{
    internal record BybitDcpStatusWrapper
    {
        [JsonProperty("dcpInfos")]
        public IEnumerable<BybitDcpStatus> Infos { get; set; } = Array.Empty<BybitDcpStatus>();
    }

    /// <summary>
    /// Dcp status
    /// </summary>
    public record BybitDcpStatus
    {
        /// <summary>
        /// Product types
        /// </summary>
        [JsonProperty("product")]
        public ProductType Product { get; set; }
        /// <summary>
        /// Is activated
        /// </summary>
        [JsonProperty("dcpStatus"), JsonConverter(typeof(BoolConverter))]
        public bool Activated { get; set; }
        /// <summary>
        /// Timewindow in seconds
        /// </summary>
        [JsonProperty("timeWindow")]
        public int? TimeWindow { get; set; }
    }
}
