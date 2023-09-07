using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Asset balances
    /// </summary>
    public class BybitAllAssetBalances
    {
        /// <summary>
        /// Account type
        /// </summary>
        public AccountType AccountType { get; set; }
        /// <summary>
        /// Member id
        /// </summary>
        public string? MemberId { get; set; }
        /// <summary>
        /// Balances
        /// </summary>
        [JsonProperty("balance")]
        public IEnumerable<BybitAssetAccountBalance> Balances { get; set; } = Array.Empty<BybitAssetAccountBalance>();
    }

    /// <summary>
    /// Asset balances
    /// </summary>
    public class BybitSingleAssetBalance
    {
        /// <summary>
        /// Account type
        /// </summary>
        public AccountType AccountType { get; set; }
        /// <summary>
        /// Member id
        /// </summary>
        public string? MemberId { get; set; }
        /// <summary>
        /// Balances
        /// </summary>
        [JsonProperty("balance")]
        public BybitAssetAccountBalance Balances { get; set; } = null!;
    }

    /// <summary>
    /// Account asset balance
    /// </summary>
    public class BybitAssetAccountBalance
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Wallet balance
        /// </summary>
        public decimal? WalletBalance { get; set; }
        /// <summary>
        /// Transfer balance
        /// </summary>
        public decimal TransferBalance { get; set; }
        /// <summary>
        /// Bonus
        /// </summary>
        public decimal? Bonus { get; set; }
    }
}
