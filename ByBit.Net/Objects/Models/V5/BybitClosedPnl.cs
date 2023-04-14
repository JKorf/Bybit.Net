using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Closed profit and loss info
    /// </summary>
    public class BybitClosedPnl
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonProperty("execType")]
        [JsonConverter(typeof(EnumConverter))]
        public TradeType TradeType { get; set; }
        /// <summary>
        /// Closed size
        /// </summary>
        public decimal ClosedSize { get; set; }
        /// <summary>
        /// Cumulated entry position value
        /// </summary>
        [JsonProperty("cumEntryValue")]
        public decimal EntryValue { get; set; }
        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonProperty("avgEntryPrice")]
        public decimal AverageEntryPrice { get; set; }
        /// <summary>
        /// Cumulated exit position value
        /// </summary>
        [JsonProperty("cumExitValue")]
        public decimal ExitValue { get; set; }
        /// <summary>
        /// Average exit price
        /// </summary>
        [JsonProperty("avgExitPrice")]
        public decimal AverageExitPrice { get; set; }
        /// <summary>
        /// Close PnL
        /// </summary>
        public decimal ClosedPnl { get; set; }
        /// <summary>
        /// Number of fills
        /// </summary>
        public int FillCount { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        public decimal Leverage { get; set; }
        /// <summary>
        /// Created time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("createdTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Updated time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("updatedTime")]
        public DateTime UpdateTime { get; set; }
    }
}
