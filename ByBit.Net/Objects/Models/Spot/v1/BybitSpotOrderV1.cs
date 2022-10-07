using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot.v1
{
    /// <summary>
    /// Spot order info
    /// </summary>
    public class BybitSpotOrderV1 : BybitSpotOrderBase
    {
        /// <summary>
        /// Exchange id
        /// </summary>
        public long ExchangeId { get; set; }
        /// <summary>
        /// Quantity executed
        /// </summary>
        [JsonProperty("executedQty")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Quote quantity
        /// </summary>
        [JsonProperty("cummulativeQuoteQty")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// Average execution price
        /// </summary>
        [JsonProperty("avgPrice")]
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// Stop price
        /// </summary>
        public decimal? StopPrice { get; set; }
        /// <summary>
        /// Ice berg quantity
        /// </summary>
        [JsonProperty("icebergQty")]
        public decimal? IcebergQuantity { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("time")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("updateTime")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Is working
        /// </summary>
        public bool IsWorking { get; set; }
    }
}
