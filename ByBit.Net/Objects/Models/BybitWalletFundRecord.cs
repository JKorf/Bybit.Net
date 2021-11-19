using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Wallet fund record
    /// </summary>
    public class BybitWalletFundRecord
    {
        /// <summary>
        /// Record id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Wallet id
        /// </summary>
        [JsonProperty("wallet_id")]
        public long WalletId { get; set; }
        /// <summary>
        /// Transfer type
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Transaction id
        /// </summary>
        [JsonProperty("tx_id")]
        public string? TransactionId { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("wallet_balance")]
        public decimal WalletBalance { get; set; }
        /// <summary>
        /// Execution time
        /// </summary>
        [JsonProperty("exec_time")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonProperty("cross_seq")]
        public decimal CrossSequence { get; set; }
    }
}
