using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Asset balances
    /// </summary>
    [SerializationModel]
    public record BybitAllAssetBalances
    {
        /// <summary>
        /// Account type
        /// </summary>
        [JsonPropertyName("accountType")]
        public AccountType AccountType { get; set; }
        /// <summary>
        /// Member id
        /// </summary>
        [JsonPropertyName("memberId")]
        public string? MemberId { get; set; }
        /// <summary>
        /// Balances
        /// </summary>
        [JsonPropertyName("balance")]
        public BybitAssetAccountBalance[] Balances { get; set; } = Array.Empty<BybitAssetAccountBalance>();
    }

    /// <summary>
    /// Asset balances
    /// </summary>
    [SerializationModel]
    public record BybitSingleAssetBalance
    {
        /// <summary>
        /// Account type
        /// </summary>
        [JsonPropertyName("accountType")]
        public AccountType AccountType { get; set; }
        /// <summary>
        /// Member id
        /// </summary>
        [JsonPropertyName("memberId")]
        public string? MemberId { get; set; }
        /// <summary>
        /// Balances
        /// </summary>
        [JsonPropertyName("balance")]
        public BybitAssetAccountBalance Balances { get; set; } = null!;
    }

    /// <summary>
    /// Account asset balance
    /// </summary>
    [SerializationModel]
    public record BybitAssetAccountBalance
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonPropertyName("walletBalance")]
        public decimal? WalletBalance { get; set; }
        /// <summary>
        /// Transfer balance
        /// </summary>
        [JsonPropertyName("transferBalance")]
        public decimal TransferBalance { get; set; }
        /// <summary>
        /// Bonus
        /// </summary>
        [JsonPropertyName("bonus")]
        public decimal? Bonus { get; set; }
    }
}
