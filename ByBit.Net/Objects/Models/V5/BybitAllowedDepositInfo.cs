using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Allowed deposit response
    /// </summary>
    public class BybitAllowedDepositInfoResponse : BybitBaseResponse
    {
        /// <summary>
        /// Asset list
        /// </summary>
        [JsonProperty("configList")]
        public IEnumerable<BybitAllowedDepositInfo> Assets { get; set; } = Array.Empty<BybitAllowedDepositInfo>();
    }

    /// <summary>
    /// Deposit info
    /// </summary>
    public class BybitAllowedDepositInfo
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Network
        /// </summary>
        [JsonProperty("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// Display name
        /// </summary>
        [JsonProperty("coinShowName")]
        public string AssetShowName { get; set; } = string.Empty;
        /// <summary>
        /// Network type
        /// </summary>
        [JsonProperty("chainType")]
        public string NetworkType { get; set; } = string.Empty;
        /// <summary>
        /// Deposit confirmation number
        /// </summary>
        public int BlockConfirmNumber { get; set; }
        /// <summary>
        /// Min deposit amount
        /// </summary>
        public decimal MinDepositAmount { get; set; }
    }
}
