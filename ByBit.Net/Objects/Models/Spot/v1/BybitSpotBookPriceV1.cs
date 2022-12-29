using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot.v1
{
    /// <summary>
    /// Book price info
    /// </summary>
    public class BybitSpotBookPriceV1
    {
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Best bid price
        /// </summary>
        /// <remarks> In some methods they changed naming, in some they changed type. Not very logic, but.. </remarks>
        [JsonProperty("bidPrice")]
        public decimal BestBidPrice { get; set; }

        /// <summary>
        /// Quantity of the best bid price
        /// </summary>
        [JsonProperty("bidQty")]
        public decimal BestBidQuantity { get; set; }

        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("askPrice")]
        public decimal BestAskPrice { get; set; }

        /// <summary>
        /// Quantity of the best ask price
        /// </summary>
        [JsonProperty("askQty")]
        public decimal BestAskQuantity { get; set; }

        /// <summary>
        /// Timestamp of the data
        /// </summary>
        [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
