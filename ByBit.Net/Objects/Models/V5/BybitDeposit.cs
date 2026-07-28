using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Deposits info
    /// </summary>
    [SerializationModel]
    public record BybitDeposits : BybitBaseResponse
    {
        /// <summary>
        /// ["<c>rows</c>"] Deposit list
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
        /// ["<c>id</c>"] Deposit id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>chain</c>"] Chain
        /// </summary>
        [JsonPropertyName("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>amount</c>"] Quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>txID</c>"] Transaction id
        /// </summary>
        [JsonPropertyName("txID")]
        public string TransactionId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>status</c>"] Status
        /// </summary>

        [JsonPropertyName("status")]
        public DepositStatus Status { get; set; }
        /// <summary>
        /// ["<c>tag</c>"] Tag
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>depositFee</c>"] Deposit fee
        /// </summary>
        [JsonPropertyName("depositFee")]
        public decimal? DepositFee { get; set; }
        /// <summary>
        /// ["<c>toAddress</c>"] To address
        /// </summary>
        [JsonPropertyName("toAddress")]
        public string ToAddress { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>successAt</c>"] Time of success
        /// </summary>
        [JsonPropertyName("successAt")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? SuccessTime { get; set; }
        /// <summary>
        /// ["<c>confirmations</c>"] Number of confirmations
        /// </summary>
        [JsonPropertyName("confirmations")]
        public int Confirmations { get; set; }
        /// <summary>
        /// ["<c>txIndex</c>"] Transaction index
        /// </summary>
        [JsonPropertyName("txIndex")]
        public string TransactionIndex { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>blockHash</c>"] Block hash
        /// </summary>
        [JsonPropertyName("blockHash")]
        public string BlockHash { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>batchReleaseLimit</c>"] Deposit limit. -1 if there is no limit.
        /// </summary>
        [JsonPropertyName("batchReleaseLimit")]
        public decimal DepositLimit { get; set; }
        /// <summary>
        /// ["<c>depositType</c>"] The deposit type. 0: normal deposit, 10: the deposit reaches daily deposit limit, 20: abnormal deposit, 50: The deposit has been blocked due to an account or compliance restriction, pls go to web to withdraw the funds
        /// </summary>
        [JsonPropertyName("depositType")]
        public int DepositType { get; set; }
        /// <summary>
        /// ["<c>fromAddress</c>"] Source address
        /// </summary>
        [JsonPropertyName("fromAddress")]
        public string FromAddress { get; set; } = string.Empty;
    }
}
