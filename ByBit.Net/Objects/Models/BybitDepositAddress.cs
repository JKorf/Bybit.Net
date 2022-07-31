using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Deposit address info
    /// </summary>
    public class BybitDepositAddress
    {
        /// <summary>
        /// The asset 
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Available network adresses
        /// </summary>
        [JsonProperty("chains")]
        public IEnumerable<BybitNetworkDepositAddress> Networks { get; set; } = Array.Empty<BybitNetworkDepositAddress>();
    }

    /// <summary>
    /// Deposit address on a network
    /// </summary>
    public class BybitNetworkDepositAddress
    {
        /// <summary>
        /// Network type
        /// </summary>
        [JsonProperty("chain_type")]
        public string NetworkType { get; set; } = string.Empty;
        /// <summary>
        /// Deposit address
        /// </summary>
        [JsonProperty("address_deposit")]
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// Tag to use for deposit
        /// </summary>
        [JsonProperty("tag_deposit")]
        public string DepositTag { get; set; } = string.Empty;
        /// <summary>
        /// Network
        /// </summary>
        [JsonProperty("chain")]
        public string Network { get; set; } = string.Empty;
    }
}
