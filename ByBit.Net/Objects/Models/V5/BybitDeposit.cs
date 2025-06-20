using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Deposits info
    /// </summary>
    [SerializationModel]
    public record BybitDeposits : BybitBaseResponse
    {
        /// <summary>
        /// Deposit list
        /// </summary>
        [JsonPropertyName("rows")]
        public BybitDeposit[] Deposits { get; set; } = Array.Empty<BybitDeposit>();
    }

    /// <summary>
    /// Deposit info
    /// </summary>
    [SerializationModel]
    public record BybitDeposit
    {
        /// <summary>
        /// Deposit id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Chain
        /// </summary>
        [JsonPropertyName("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Transaction id
        /// </summary>
        [JsonPropertyName("txID")]
        public string TransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>

        [JsonPropertyName("status")]
        public DepositStatus Status { get; set; }
        /// <summary>
        /// Tag
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; } = string.Empty;
        /// <summary>
        /// Deposit fee
        /// </summary>
        [JsonPropertyName("depositFee")]
        public decimal? DepositFee { get; set; }
        /// <summary>
        /// To address
        /// </summary>
        [JsonPropertyName("toAddress")]
        public string ToAddress { get; set; } = string.Empty;
        /// <summary>
        /// Time of success
        /// </summary>
        [JsonPropertyName("successAt")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? SuccessTime { get; set; }
        /// <summary>
        /// Number of confirmations
        /// </summary>
        [JsonPropertyName("confirmations")]
        public int Confirmations { get; set; }
        /// <summary>
        /// Transaction index
        /// </summary>
        [JsonPropertyName("txIndex")]
        public string TransactionIndex { get; set; } = string.Empty;
        /// <summary>
        /// Block hash
        /// </summary>
        [JsonPropertyName("blockHash")]
        public string BlockHash { get; set; } = string.Empty;
        /// <summary>
        /// Deposit limit. -1 if there is no limit.
        /// </summary>
        [JsonPropertyName("batchReleaseLimit")]
        public decimal DepositLimit { get; set; }
        /// <summary>
        /// The deposit type. 0: normal deposit, 10: the deposit reaches daily deposit limit, 20: abnormal deposit
        /// </summary>
        [JsonPropertyName("depositType")]
        public int DepositType { get; set; }
        /// <summary>
        /// Source address
        /// </summary>
        [JsonPropertyName("fromAddress")]
        public string FromAddress { get; set; } = string.Empty;
    }
}
