using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    [SerializationModel]
    internal record BybitAssetInfoWrapper
    {
        [JsonPropertyName("spot")]
        public BybitAccountAssetInfo Spot { get; set; } = null!;
    }

    /// <summary>
    /// Account asset info
    /// </summary>
    [SerializationModel]
    public record BybitAccountAssetInfo
    {
        /// <summary>
        /// Account status
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// Assdet info
        /// </summary>
        [JsonPropertyName("assets")]
        public BybitAssetInfo[] Assets { get; set; } = Array.Empty<BybitAssetInfo>();
    }

    /// <summary>
    /// Asset info
    /// </summary>
    [SerializationModel]
    public record BybitAssetInfo
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Frozen amount
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal Frozen { get; set; }
        /// <summary>
        /// Free amount
        /// </summary>
        [JsonPropertyName("free")]
        public decimal Free { get; set; }
        /// <summary>
        /// Amount in withdrawing
        /// </summary>
        [JsonPropertyName("withdraw")]
        public decimal? Withdrawing { get; set; }
    }
}
