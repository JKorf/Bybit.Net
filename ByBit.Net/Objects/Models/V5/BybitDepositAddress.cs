using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Deposit address info
    /// </summary>
    [SerializationModel]
    public record BybitDepositAddress
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Networks
        /// </summary>
        [JsonPropertyName("chains")]
        public BybitDepositChainAddress[] Networks { get; set; } = Array.Empty<BybitDepositChainAddress>();
    }

    /// <summary>
    /// Deposit address
    /// </summary>
    [SerializationModel]
    public record BybitDepositChainAddress
    {
        /// <summary>
        /// Network type
        /// </summary>
        [JsonPropertyName("chainType")]
        public string NetworkType { get; set; } = string.Empty;
        /// <summary>
        /// Deposit address
        /// </summary>
        [JsonPropertyName("addressDeposit")]
        public string DepositAddress { get; set; } = string.Empty;
        /// <summary>
        /// Deposit tag
        /// </summary>
        [JsonPropertyName("tagDeposit")]
        public string DepositTag { get; set; } = string.Empty;
        /// <summary>
        /// Network
        /// </summary>
        [JsonPropertyName("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// Deposit limit. -1 if there is no limit.
        /// </summary>
        [JsonPropertyName("batchReleaseLimit")]
        public decimal DepositLimit { get; set; }
        /// <summary>
        /// Network contract asset, only last 6 characters
        /// </summary>
        [JsonPropertyName("contractAddress")]
        public string ContractAddress { get; set; } = string.Empty;
    }
}
