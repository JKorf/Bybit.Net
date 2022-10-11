using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Wrapper for balances deserialization
    /// </summary>
    internal class BybitSpotBalanceWrapper
    {
        /// <summary>
        /// List of spot balances
        /// </summary>
        public IEnumerable<BybitSpotBalance> Balances { get; set; } = Array.Empty<BybitSpotBalance>();
    }

    /// <summary>
    /// Balance info
    /// </summary>
    public class BybitSpotBalance
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Asset id
        /// </summary>
        [JsonProperty("coinId")]
        public string AssetId { get; set; } = string.Empty;
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("coinName")]
        public string AssetName { get; set; } = string.Empty;
        /// <summary>
        /// Locked in active orders
        /// </summary>
        public decimal Locked { get; set; }
        /// <summary>
        /// Available
        /// </summary>
        [JsonProperty("free")]
        public decimal Available { get; set; }
        /// <summary>
        /// Total
        /// </summary>
        [JsonProperty("total")]
        public decimal Total { get; set; }
    }
}
