using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Request info
    /// </summary>
    [SerializationModel]
    public record BybitSetCollateralAssetRequest
    {
        /// <summary>
        /// The asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;

        [JsonPropertyName("collateralSwitch")]
        private string _useForCollateral => UseForCollateral ? "ON" : "OFF";

        /// <summary>
        /// Use this asset for collateral
        /// </summary>
        [JsonIgnore]
        public bool UseForCollateral { get; set; }
    }
}
