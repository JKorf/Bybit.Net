using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Withdraw info
    /// </summary>
    public class BybitWithdraw
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
        /// Quantity
        /// </summary>
        [JsonProperty("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trasaction id
        /// </summary>
        [JsonProperty("tx_id")]
        public string TransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// To address
        /// </summary>
        [JsonProperty("to_address")]
        public string ToAddress { get; set; } = string.Empty;
        /// <summary>
        /// Tag
        /// </summary>
        public string Tag { get; set; } = string.Empty;
        /// <summary>
        /// Withdrawal fee
        /// </summary>
        [JsonProperty("withdraw_fee")]
        public decimal? WithdrawFee { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("create_time")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonProperty("update_time")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Withdrawal id
        /// </summary>
        [JsonProperty("withdraw_id")]
        public string WithdrawId { get; set; } = string.Empty;
    }
}
