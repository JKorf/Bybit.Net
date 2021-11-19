using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Withdrawal info
    /// </summary>
    public class BybitWithdrawal
    {
        /// <summary>
        /// Withdrawal id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// The asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>
        [JsonConverter(typeof(WithdrawStatusConverter))]
        public WithdrawStatus Status { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Fee paid
        /// </summary>
        public decimal Fee { get; set; }
        /// <summary>
        /// Withdrawal address
        /// </summary>
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// Transaction id
        /// </summary>
        [JsonProperty("tx_id")]
        public string? TransactionId { get; set; }
        /// <summary>
        /// Time submitted
        /// </summary>
        [JsonProperty("submited_at")]
        public DateTime SubmitTime { get; set; }
        /// <summary>
        /// Time last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdateTime { get; set; }
    }
}
