using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot.v1
{
    /// <summary>
    /// Spot trade info
    /// </summary>
    public class BybitSpotTradeV1
    {
        /// <summary>
        /// Trade price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Timestamp of the trade
        /// </summary>
        [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime TradeTime { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Is the buyer the maker
        /// </summary>
        public bool IsBuyerMaker { get; set; }
    }
}
