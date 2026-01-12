using Bybit.Net.Converters;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Small balance assets
    /// </summary>
    public record BybitSmallBalanceAssets
    {
        /// <summary>
        /// Small balances
        /// </summary>
        [JsonPropertyName("smallAssetCoins")]
        public BybitSmallBalanceAsset[] SmallBalanceAssets { get; set; } = [];
        /// <summary>
        /// Supported to assets
        /// </summary>
        [JsonPropertyName("supportToCoins")]
        public string[] SupportToAssets { get; set; } = [];
    }

    /// <summary>
    /// Asset info
    /// </summary>
    public record BybitSmallBalanceAsset
    {
        /// <summary>
        /// From asset
        /// </summary>
        [JsonPropertyName("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;
        /// <summary>
        /// Available balance
        /// </summary>
        [JsonPropertyName("availableBalance")]
        public decimal AvailableBalance { get; set; }
        /// <summary>
        /// USDT value
        /// </summary>
        [JsonPropertyName("baseValue")]
        public decimal BaseValue { get; set; }
        /// <summary>
        /// Conversion is supported
        /// </summary>
        [JsonConverter(typeof(Bool12Converter))]
        [JsonPropertyName("supportConvert")]
        public bool Supported { get; set; }
    }
}
