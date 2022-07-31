using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Asset information
    /// </summary>
    public class BybitAssetInfo
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Withdrawable quantity remaining
        /// </summary>
        [JsonProperty("remain_amount")]
        public decimal? RemainingWithdrawableQuantity { get; set; }
        /// <summary>
        /// Networks info
        /// </summary>
        [JsonProperty("chains")]
        public IEnumerable<BybitAssetNetwork> Networks { get; set; } = Array.Empty<BybitAssetNetwork>();
    }

    /// <summary>
    /// Network info
    /// </summary>
    public class BybitAssetNetwork
    {
        /// <summary>
        /// Network type
        /// </summary>
        [JsonProperty("chain_type")]
        public string NetworkType { get; set; } = string.Empty;
        /// <summary>
        /// Number of confirmations needed for deposit
        /// </summary>
        [JsonProperty("confirmation")]
        public int ConfirmationsNeeded { get; set; }
        /// <summary>
        /// Withdrawal fee
        /// </summary>
        [JsonProperty("withdraw_fee")]
        public decimal? WithdrawFee { get; set; }
        /// <summary>
        /// Deposit fee
        /// </summary>
        [JsonProperty("deposit_min")]
        public decimal? MinimalDeposit { get; set; }
        /// <summary>
        /// Minimal withdrawal amount
        /// </summary>
        [JsonProperty("withdraw_min")]
        public decimal? MinimalWithdrawal { get; set; }
        /// <summary>
        /// Network name
        /// </summary>
        [JsonProperty("chain")]
        public string Network { get; set; } = string.Empty;
    }
}
