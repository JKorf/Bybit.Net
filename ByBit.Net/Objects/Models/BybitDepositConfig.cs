
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models
{
    internal class BybitDepositConfigWrapper
    {
        [JsonProperty("config_list")]
        public IEnumerable<BybitDepositConfig> ConfigList { get; set; } = Array.Empty<BybitDepositConfig>();
    }

    /// <summary>
    /// Deposit config
    /// </summary>
    public class BybitDepositConfig
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Chain
        /// </summary>
        [JsonProperty("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("coin_show_name")]
        public string AssetName { get; set; } = string.Empty;
        /// <summary>
        /// Chain type
        /// </summary>
        [JsonProperty("chain_type")]
        public string NetworkType { get; set; } = string.Empty;
        /// <summary>
        /// Number of confirmations needed
        /// </summary>
        [JsonProperty("block_confirm_number")]
        public int ConfirmationsNeeded { get; set; }
        /// <summary>
        /// Min deposit quantity
        /// </summary>
        [JsonProperty("min_deposit_amount")]
        public decimal MinDepositQuantity { get; set; }
    }
}
