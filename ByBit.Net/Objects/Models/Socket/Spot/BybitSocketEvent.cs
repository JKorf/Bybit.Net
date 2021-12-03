using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    /// <summary>
    /// Socket update
    /// </summary>
    public abstract class BybitSocketEvent
    {
        /// <summary>
        /// Event type
        /// </summary>
        [JsonProperty("e")]
        public string Event { get; set; } = string.Empty;
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("E"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
