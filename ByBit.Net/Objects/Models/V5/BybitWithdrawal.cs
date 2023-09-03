using Bybit.Net.Enums;
using Bybit.Net.Enums.V5;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Withdrawal info
    /// </summary>
    public class BybitWithdrawal
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
        /// Transaction id
        /// </summary>
        [JsonProperty("txID")]
        public string TransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public WithdrawalStatus Status { get; set; }
        /// <summary>
        /// To address
        /// </summary>
        public string ToAddress { get; set; } = string.Empty;
        /// <summary>
        /// Tag
        /// </summary>
        public string Tag { get; set; } = string.Empty;
        /// <summary>
        /// Withdrawal fee
        /// </summary>
        public decimal? WithdrawFee { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("createTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updateTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("withdrawId")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Type
        /// </summary>
        [JsonProperty("withdrawType")]
        [JsonConverter(typeof(EnumConverter))]
        public WithdrawalType Type { get; set; }
    }
}
