using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Deposits info
    /// </summary>
    public class BybitDeposits : BybitBaseResponse
    {
        /// <summary>
        /// Deposit list
        /// </summary>
        [JsonProperty("rows")]
        public IEnumerable<BybitDeposit> Deposits { get; set; } = Array.Empty<BybitDeposit>();
    }

    /// <summary>
    /// Deposit info
    /// </summary>
    public class BybitDeposit
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Chain
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
        public DepositStatus Status { get; set; }
        /// <summary>
        /// Tag
        /// </summary>
        public string Tag { get; set; } = string.Empty;
        /// <summary>
        /// Deposit fee
        /// </summary>
        public decimal? DepositFee { get; set; }
        /// <summary>
        /// To address
        /// </summary>
        public string ToAddress { get; set; } = string.Empty;
        /// <summary>
        /// Time of success
        /// </summary>
        [JsonProperty("successAt")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? SuccessTime { get; set; }
        /// <summary>
        /// Number of confirmations
        /// </summary>
        public int Confirmations { get; set; }
        /// <summary>
        /// Transaction index
        /// </summary>
        [JsonProperty("txIndex")]
        public string TransactionIndex { get; set; } = string.Empty;
        /// <summary>
        /// Block hash
        /// </summary>
        public string BlockHash { get; set; } = string.Empty;
    }
}
