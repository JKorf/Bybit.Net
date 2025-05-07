using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Allowed deposit response
    /// </summary>
    [SerializationModel]
    public record BybitAllowedDepositInfoResponse : BybitBaseResponse
    {
        /// <summary>
        /// Asset list
        /// </summary>
        [JsonPropertyName("configList")]
        public BybitAllowedDepositInfo[] Assets { get; set; } = Array.Empty<BybitAllowedDepositInfo>();
    }

    /// <summary>
    /// Deposit info
    /// </summary>
    [SerializationModel]
    public record BybitAllowedDepositInfo
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Network
        /// </summary>
        [JsonPropertyName("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// Display name
        /// </summary>
        [JsonPropertyName("coinShowName")]
        public string AssetShowName { get; set; } = string.Empty;
        /// <summary>
        /// Network type
        /// </summary>
        [JsonPropertyName("chainType")]
        public string NetworkType { get; set; } = string.Empty;
        /// <summary>
        /// Deposit confirmation number
        /// </summary>
        [JsonPropertyName("blockConfirmNumber")]
        public int BlockConfirmNumber { get; set; }
        /// <summary>
        /// Min deposit amount
        /// </summary>
        [JsonPropertyName("minDepositAmount")]
        public decimal MinDepositAmount { get; set; }
    }
}
