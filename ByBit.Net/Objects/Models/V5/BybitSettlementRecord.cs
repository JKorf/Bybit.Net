using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Settlement record
    /// </summary>
    public class BybitSettlementRecord
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Settlement price
        /// </summary>
        [JsonProperty("sessionAvgPrice")]
        public decimal SettlementPrice { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        public decimal MarkPrice { get; set; }
        /// <summary>
        /// Realized profit and loss
        /// </summary>
        [JsonProperty("realisedPnl")]
        public decimal RealizedPnl { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("createdTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
    }
}
