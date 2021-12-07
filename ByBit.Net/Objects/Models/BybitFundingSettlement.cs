using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Funding settlement info
    /// </summary>
    public class BybitFundingSettlement
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Position side at the time of settlement
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Position size at the time of settlement
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Funding rate for settlement
        /// </summary>
        [JsonProperty("funding_rate")]
        public decimal FundingRate { get; set; }
        /// <summary>
        /// Funding fee
        /// </summary>
        [JsonProperty("exec_fee")]
        public decimal FundingFee { get; set; }
        /// <summary>
        /// Funding settlement time
        /// </summary>
        [JsonProperty("exec_timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Timestamp { get; set; }
        [JsonProperty("exec_time")]
        internal DateTime? _time { set => Timestamp = value; get => Timestamp; }
    }
}
