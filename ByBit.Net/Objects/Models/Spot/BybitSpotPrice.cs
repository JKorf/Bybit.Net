using System;
using System.Collections.Generic;
using Bybit.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Wrapper for price deserialization
    /// </summary>
    public class BybitSpotPriceWrapper
    {
        /// <summary>
        /// List of spot prices
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitSpotPrice> Prices { get; set; } = Array.Empty<BybitSpotPrice>();
    }

    /// <summary>
    /// Price info
    /// </summary>
    public class BybitSpotPrice
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Price
        /// </summary>
        /// <remarks> Useful for V3 as they send it in string format </remarks>
        public decimal Price { get; set; }
    }
}
