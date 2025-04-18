using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    [SerializationModel]
    internal record BybitDcpStatusWrapper
    {
        [JsonPropertyName("dcpInfos")]
        public BybitDcpStatus[] Infos { get; set; } = Array.Empty<BybitDcpStatus>();
    }

    /// <summary>
    /// Dcp status
    /// </summary>
    [SerializationModel]
    public record BybitDcpStatus
    {
        /// <summary>
        /// Product types
        /// </summary>
        [JsonPropertyName("product")]
        public ProductType Product { get; set; }
        /// <summary>
        /// Is activated
        /// </summary>
        [JsonPropertyName("dcpStatus"), JsonConverter(typeof(BoolConverter))]
        public bool Activated { get; set; }
        /// <summary>
        /// Timewindow in seconds
        /// </summary>
        [JsonPropertyName("timeWindow")]
        public int? TimeWindow { get; set; }
    }
}
