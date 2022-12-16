using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using Bybit.Net.Converters;
using Bybit.Net.Enums;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Spot order info
    /// </summary>
    public class BybitSpotOrderV3 : BybitSpotOrderBase
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty("accountId")]
        public new string AccountId { get; set; } = string.Empty;

        /// <summary>
        /// Order price
        /// </summary>
        [JsonProperty("orderPrice")]
        private decimal OrderPrice
        {
            get { return Price; }
            set { Price = value; }
        }

        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonProperty("triggerPrice")]
        public decimal TriggerPrice { get; set; }

        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("orderQty")]
        private decimal OrderQuantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        /// <summary>
        /// Type
        /// </summary>
        [JsonConverter(typeof(OrderTypeSpotConverter))]
        [JsonProperty("orderType")]
        private OrderType OrderType
        {
            get { return Type; }
            set { Type = value; }
        }

        /// <summary>
        /// Average execution price
        /// </summary>
        [JsonProperty("avgPrice")]
        public decimal AveragePrice { get; set; }
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
        /// Stop price
        /// </summary>
        public decimal? StopPrice { get; set; }
        /// <summary>
        /// Quantity executed
        /// </summary>
        [JsonProperty("execQty")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Quote quantity
        /// </summary>
        [JsonProperty("cummulativeQuoteQty")]
        public decimal QuoteQuantity { get; set; }

        /// <summary>
        /// Is working
        /// </summary>
        /// <remarks> 0：valid, 1：invalid </remarks>
        [JsonProperty("isWorking")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsWorking { get; set; }
    }
}
