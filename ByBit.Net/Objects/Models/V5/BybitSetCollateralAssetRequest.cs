using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Request info
    /// </summary>
    public class BybitSetCollateralAssetRequest
    {
        /// <summary>
        /// The asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;

        [JsonProperty("collateralSwitch")]
        private string _useForCollateral => UseForCollateral ? "ON" : "OFF";

        /// <summary>
        /// Use this asset for collateral
        /// </summary>
        [JsonIgnore]
        public bool UseForCollateral { get; set; }
    }
}
