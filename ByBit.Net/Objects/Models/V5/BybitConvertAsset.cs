using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    internal record BybitConvertAssetWrapper
    {
        /// <summary>
        /// Coins
        /// </summary>
        [JsonProperty("coins")]
        public IEnumerable<BybitConvertAsset> Assets { get; set; } = Array.Empty<BybitConvertAsset>();
    }

    /// <summary>
    /// Convert asset info
    /// </summary>
    public record BybitConvertAsset
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Full name
        /// </summary>
        [JsonProperty("fullName")]
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// Icon
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; } = string.Empty;
        /// <summary>
        /// Icon night
        /// </summary>
        [JsonProperty("iconNight")]
        public string IconNight { get; set; } = string.Empty;
        /// <summary>
        /// The max amount of decimal places to use
        /// </summary>
        [JsonProperty("accuracyLength")]
        public int Precision { get; set; }
        /// <summary>
        /// Asset type
        /// </summary>
        [JsonProperty("coinType")]
        public string AssetType { get; set; } = string.Empty;
        /// <summary>
        /// Balance
        /// </summary>
        [JsonProperty("balance")]
        public decimal? Balance { get; set; }
        /// <summary>
        /// Balance USDT value
        /// </summary>
        [JsonProperty("uBalance")]
        public decimal? BalanceValue { get; set; }
        /// <summary>
        /// The minimum quantity of fromAsset per transaction
        /// </summary>
        [JsonProperty("singleFromMinLimit")]
        public decimal FromAssetMinQuantity { get; set; }
        /// <summary>
        /// The maximum quantity of fromAsset per transaction
        /// </summary>
        [JsonProperty("singleFromMaxLimit")]
        public decimal FromAssetMaxQuantity { get; set; }
        /// <summary>
        /// true: the asset is disabled to be fromAsset, false: the asset is allowed to be fromAsset
        /// </summary>
        [JsonProperty("disableFrom")]
        public bool DisableFrom { get; set; }
        /// <summary>
        /// true: the asset is disabled to be toAsset, false: the asset is allowed to be toAsset
        /// </summary>
        [JsonProperty("disableTo")]
        public bool DisableTo { get; set; }
    }
}
