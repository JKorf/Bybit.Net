using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Book price info
    /// </summary>
    /// <remarks> In some methods of v3 they changed naming, in some they changed type. Not very logic, but.. </remarks>
    public class BybitSpotBookPriceV3
    {
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// The symbol
        /// </summary>
        /// <remarks> DO not remove, using in JSON deserialization </remarks>
        [JsonProperty("s")]
        private string SymbolV3
        {
            get => Symbol;
            set => Symbol = value;
        }

        /// <summary>
        /// Best bid price
        /// </summary>
        /// <remarks> In some methods of v3 they changed naming, in some they changed type. Not very logic, but.. </remarks>
        [JsonProperty("bidPrice")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Best bid price (v3)
        /// </summary>
        [JsonProperty("bp")]
        private decimal BestBidPriceV3
        {
            get => BestBidPrice;
            set => BestBidPrice = value;
        }

        /// <summary>
        /// Quantity of the best bid price
        /// </summary>
        [JsonProperty("bidQty")]
        public decimal BestBidQuantity { get; set; }
        /// <summary>
        /// Quantity of the best bid price (v3)
        /// </summary>
        /// <remarks> DO not remove, using in JSON deserialization </remarks>
        [JsonProperty("bq")]
        private decimal BestBidQuantityV3
        {
            get => BestBidQuantity;
            set => BestBidQuantity = value;
        }

        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("askPrice")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Best ask price (v3)
        /// </summary>
        /// <remarks> DO not remove, using in JSON deserialization </remarks>
        [JsonProperty("ap")]
        private decimal BestAskPriceV3
        {
            get => BestAskPrice;
            set => BestAskPrice = value;
        }

        /// <summary>
        /// Quantity of the best ask price
        /// </summary>
        [JsonProperty("askQty")]
        public decimal BestAskQuantity { get; set; }
        /// <summary>
        /// Quantity of the best ask price (v3)
        /// </summary>
        /// <remarks> DO not remove, using in JSON deserialization </remarks>
        [JsonProperty("aq")]
        private decimal BestAskQuantityV3
        {
            get => BestAskQuantity;
            set => BestAskQuantity = value;
        }

        /// <summary>
        /// Timestamp of the data
        /// </summary>
        [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Timestamp of the data (v3)
        /// </summary>
        /// <remarks> DO not remove, using in JSON deserialization </remarks>
        [JsonProperty("t"), JsonConverter(typeof(DateTimeConverter))]
        private DateTime TimestampV3
        {
            get => Timestamp;
            set => Timestamp = value;
        }
    }
}
