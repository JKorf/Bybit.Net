using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    [SerializationModel]
    internal record BybitConvertAssetWrapper
    {
        /// <summary>
        /// Coins
        /// </summary>
        [JsonPropertyName("coins")]
        public BybitConvertAsset[] Assets { get; set; } = Array.Empty<BybitConvertAsset>();
    }

    /// <summary>
    /// Convert asset info
    /// </summary>
    [SerializationModel]
    public record BybitConvertAsset
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Full name
        /// </summary>
        [JsonPropertyName("fullName")]
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// Icon
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
        /// <summary>
        /// Icon night
        /// </summary>
        [JsonPropertyName("iconNight")]
        public string IconNight { get; set; } = string.Empty;
        /// <summary>
        /// The max amount of decimal places to use
        /// </summary>
        [JsonPropertyName("accuracyLength")]
        public int Precision { get; set; }
        /// <summary>
        /// Asset type
        /// </summary>
        [JsonPropertyName("coinType")]
        public string AssetType { get; set; } = string.Empty;
        /// <summary>
        /// Balance
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal? Balance { get; set; }
        /// <summary>
        /// Balance USDT value
        /// </summary>
        [JsonPropertyName("uBalance")]
        public decimal? BalanceValue { get; set; }
        /// <summary>
        /// The minimum quantity of fromAsset per transaction
        /// </summary>
        [JsonPropertyName("singleFromMinLimit")]
        public decimal FromAssetMinQuantity { get; set; }
        /// <summary>
        /// The maximum quantity of fromAsset per transaction
        /// </summary>
        [JsonPropertyName("singleFromMaxLimit")]
        public decimal FromAssetMaxQuantity { get; set; }
        /// <summary>
        /// true: the asset is disabled to be fromAsset, false: the asset is allowed to be fromAsset
        /// </summary>
        [JsonPropertyName("disableFrom")]
        public bool DisableFrom { get; set; }
        /// <summary>
        /// true: the asset is disabled to be toAsset, false: the asset is allowed to be toAsset
        /// </summary>
        [JsonPropertyName("disableTo")]
        public bool DisableTo { get; set; }
    }
}
