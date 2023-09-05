using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Order ids
    /// </summary>
    public class BybitBatchOrderId
    {
        /// <summary>
        /// Category
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public Category Category { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// The order id
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("createAt")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
    }
}
