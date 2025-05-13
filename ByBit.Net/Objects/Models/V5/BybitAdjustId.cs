using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Adjust id
    /// </summary>
    [SerializationModel]
    public record BybitAdjustId
    {
        /// <summary>
        /// Adjust id
        /// </summary>
        [JsonPropertyName("adjustId")]
        public string AdjustId { get; set; } = string.Empty;
    }


}
