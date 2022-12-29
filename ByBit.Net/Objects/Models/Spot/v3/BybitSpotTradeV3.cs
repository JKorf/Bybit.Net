using Newtonsoft.Json;
using System;

using DateTimeConverter = CryptoExchange.Net.Converters.DateTimeConverter;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Spot trade info
    /// </summary>
    public class BybitSpotTradeV3
    {
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonProperty("price")]
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
        public int IsBuyerMaker { get; set; }
    }
}
