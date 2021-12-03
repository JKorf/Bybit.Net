using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    /// <summary>
    /// Account update
    /// </summary>
    public class BybitSpotAccountUpdate: BybitSocketEvent
    {
        /// <summary>
        /// Allow trading
        /// </summary>
        [JsonProperty("T")]
        public bool AllowTrade { get; set; }
        /// <summary>
        /// Allow withdrawing
        /// </summary>
        [JsonProperty("W")]
        public bool AllowWithdraw { get; set; }
        /// <summary>
        /// Allow deposits
        /// </summary>
        [JsonProperty("D")]
        public bool AllowDeposit { get; set; }
        /// <summary>
        /// Balances
        /// </summary>
        [JsonProperty("B")]
        public IEnumerable<BybitSpotAccountBalance> Balances { get; set; } = Array.Empty<BybitSpotAccountBalance>();
    }

    /// <summary>
    /// Account balance
    /// </summary>
    public class BybitSpotAccountBalance
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("a")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Available amount
        /// </summary>
        [JsonProperty("f")]
        public decimal Available { get; set; }
        /// <summary>
        /// Locked in orders
        /// </summary>
        [JsonProperty("l")]
        public decimal Locked { get; set; }
    }
}
