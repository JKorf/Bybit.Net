using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Asset info
    /// </summary>
    [SerializationModel]
    public record BybitUserAssetInfos : BybitBaseResponse
    {
        /// <summary>
        /// ["<c>rows</c>"] Assets
        /// </summary>
        [JsonPropertyName("rows")]
        public BybitUserAssetInfo[] Assets { get; set; } = Array.Empty<BybitUserAssetInfo>();
    }

    /// <summary>
    /// Asset info for user
    /// </summary>
    [SerializationModel]
    public record BybitUserAssetInfo
    {
        /// <summary>
        /// ["<c>name</c>"] Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>coin</c>"] asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>remainAmount</c>"] Quantity remaining
        /// </summary>
        [JsonPropertyName("remainAmount")]
        public decimal? QuantityRemaining { get; set; }
        /// <summary>
        /// ["<c>chains</c>"] Networks
        /// </summary>
        [JsonPropertyName("chains")]
        public BybitAssetNetworkInfo[] Networks { get; set; } = [];
    }

    /// <summary>
    /// Asset network info
    /// </summary>
    [SerializationModel]
    public record BybitAssetNetworkInfo
    {
        /// <summary>
        /// ["<c>chainType</c>"] Network type
        /// </summary>
        [JsonPropertyName("chainType")]
        public string NetworkType { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>confirmation</c>"] Confirmations
        /// </summary>
        [JsonPropertyName("confirmation")]
        public int? Confirmation { get; set; }
        /// <summary>
        /// ["<c>withdrawFee</c>"] Withdrawal fee
        /// </summary>
        [JsonPropertyName("withdrawFee")]
        public decimal? WithdrawFee { get; set; }
        /// <summary>
        /// ["<c>depositMin</c>"] Min deposit quantity
        /// </summary>
        [JsonPropertyName("depositMin")]
        public decimal? MinDeposit { get; set; }
        /// <summary>
        /// ["<c>withdrawMin</c>"] Min withdrawal quantity
        /// </summary>
        [JsonPropertyName("withdrawMin")]
        public decimal? MinWithdraw { get; set; }
        /// <summary>
        /// ["<c>chain</c>"] Chain
        /// </summary>
        [JsonPropertyName("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>chainDeposit</c>"] Chain deposit enabled
        /// </summary>
        [JsonPropertyName("chainDeposit")]
        [JsonConverter(typeof(BoolConverter))]
        public bool? NetworkDeposit { get; set; }
        /// <summary>
        /// ["<c>chainWithdraw</c>"] Chain withdraw enabled
        /// </summary>
        [JsonPropertyName("chainWithdraw")]
        [JsonConverter(typeof(BoolConverter))]
        public bool? NetworkWithdraw { get; set; }
        /// <summary>
        /// ["<c>minAccuracy</c>"] Minimal accuracy
        /// </summary>
        [JsonPropertyName("minAccuracy")]
        public int MinAccuracy { get; set; }
        /// <summary>
        /// ["<c>withdrawPercentageFee</c>"] Withdrawal percentage fee
        /// </summary>
        [JsonPropertyName("withdrawPercentageFee")]
        public decimal? WithdrawPercentageFee { get; set; }
        /// <summary>
        /// ["<c>withdrawMax</c>"] Withdrawal max amount
        /// </summary>
        [JsonPropertyName("withdrawMax")]
        public decimal? WithdrawMax { get; set; }
        /// <summary>
        /// ["<c>contractAddress</c>"] Contract address
        /// </summary>
        [JsonPropertyName("contractAddress")]
        public string ContractAddress { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>safeConfirmNumber</c>"] Confirmations required for unlocking
        /// </summary>
        [JsonPropertyName("safeConfirmNumber")]
        public int? RequiredConfirmations { get; set; }
    }
}
