using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Deposit address info
    /// </summary>
    public class BybitDepositAddress
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Networks
        /// </summary>
        [JsonProperty("chains")]
        public IEnumerable<BybitDepositChainAddress> Networks { get; set; } = Array.Empty<BybitDepositChainAddress>();
    }

    /// <summary>
    /// Deposit address
    /// </summary>
    public class BybitDepositChainAddress
    {
        /// <summary>
        /// Network type
        /// </summary>
        [JsonProperty("chainType")]
        public string NetworkType { get; set; } = string.Empty;
        /// <summary>
        /// Deposit address
        /// </summary>
        [JsonProperty("addressDeposit")]
        public string DepositAddress { get; set; } = string.Empty;
        /// <summary>
        /// Deposit tag
        /// </summary>
        [JsonProperty("tagDeposit")]
        public string DepositTag { get; set; } = string.Empty;
        /// <summary>
        /// Network
        /// </summary>
        [JsonProperty("chain")]
        public string Network { get; set; } = string.Empty;
    }
}
