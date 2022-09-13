using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Book price info
    /// </summary>
    public class BybitSpotBookPrice
    {
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonProperty("s")]
        public string SymbolV3
        {
            set { Symbol = value; }
        }

        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("bidPrice")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Best bid price (v3)
        /// </summary>
        [JsonProperty("bp")]
        private decimal BestBidPriceV3
        {
            set { BestBidPrice = value; }
        }

        /// <summary>
        /// Quantity of the best bid price
        /// </summary>
        [JsonProperty("bidQty")]
        public decimal BestBidQuantity { get; set; }
        /// <summary>
        /// Quantity of the best bid price (v3)
        /// </summary>
        [JsonProperty("bq")]
        private decimal BestBidQuantityV3
        {
            set { BestBidQuantity = value; }
        }

        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("askPrice")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Best ask price (v3)
        /// </summary>
        [JsonProperty("ap")]
        private decimal BestAskPriceV3
        {
            set { BestAskPrice = value; }
        }

        /// <summary>
        /// Quantity of the best ask price
        /// </summary>
        [JsonProperty("askQty")]
        public decimal BestAskQuantity { get; set; }
        /// <summary>
        /// Quantity of the best ask price (v3)
        /// </summary>
        [JsonProperty("aq")]
        private decimal BestAskQuantityV3
        {
            set { BestAskQuantity = value; }
        }

        /// <summary>
        /// Timestamp of the data
        /// </summary>
        [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Timestamp of the data (v3)
        /// </summary>
        [JsonProperty("t"), JsonConverter(typeof(DateTimeConverter))]
        private DateTime TimestampV3
        {
            set { Timestamp = value; }
        }
    }
}
