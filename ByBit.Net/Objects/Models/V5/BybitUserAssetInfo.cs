using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Asset info
    /// </summary>
    [SerializationModel]
    public record BybitUserAssetInfos : BybitBaseResponse
    {
        /// <summary>
        /// Assets
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
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity remaining
        /// </summary>
        [JsonPropertyName("remainAmount")]
        public decimal? QuantityRemaining { get; set; }
        /// <summary>
        /// Networks
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
        /// Network type
        /// </summary>
        [JsonPropertyName("chainType")]
        public string NetworkType { get; set; } = string.Empty;
        /// <summary>
        /// Confirmations
        /// </summary>
        [JsonPropertyName("confirmation")]
        public int? Confirmation { get; set; }
        /// <summary>
        /// Withdrawal fee
        /// </summary>
        [JsonPropertyName("withdrawFee")]
        public decimal? WithdrawFee { get; set; }
        /// <summary>
        /// Min deposit quantity
        /// </summary>
        [JsonPropertyName("depositMin")]
        public decimal? MinDeposit { get; set; }
        /// <summary>
        /// Min withdrawal quantity
        /// </summary>
        [JsonPropertyName("withdrawMin")]
        public decimal? MinWithdraw { get; set; }
        /// <summary>
        /// Chain
        /// </summary>
        [JsonPropertyName("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// Chain deposit enabled
        /// </summary>
        [JsonPropertyName("chainDeposit")]
        [JsonConverter(typeof(BoolConverter))]
        public bool? NetworkDeposit { get; set; }
        /// <summary>
        /// Chain withdraw enabled
        /// </summary>
        [JsonPropertyName("chainWithdraw")]
        [JsonConverter(typeof(BoolConverter))]
        public bool? NetworkWithdraw { get; set; }
        /// <summary>
        /// Minimal accuracy
        /// </summary>
        [JsonPropertyName("minAccuracy")]
        public int MinAccuracy { get; set; }
        /// <summary>
        /// Withdrawal percentage fee
        /// </summary>
        [JsonPropertyName("withdrawPercentageFee")]
        public decimal? WithdrawPercentageFee { get; set; }
        /// <summary>
        /// Contract address
        /// </summary>
        [JsonPropertyName("contractAddress")]
        public string ContractAddress { get; set; } = string.Empty;
        /// <summary>
        /// Confirmations required for unlocking
        /// </summary>
        [JsonPropertyName("safeConfirmNumber")]
        public int? RequiredConfirmations { get; set; }
    }
}
