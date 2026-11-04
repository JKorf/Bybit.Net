using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Trade behaviour configuration of the account
    /// </summary>
    [SerializationModel]
    public record BybitTradeBehaviourConfig
    {
        /// <summary>
        /// ["<c>lpaSpot</c>"] Spot price limit behaviour: true adjusts an order price beyond the limit to the nearest allowed price, false rejects the request
        /// </summary>
        [JsonPropertyName("lpaSpot")]
        public bool SpotAdjustPriceBeyondLimit { get; set; }
        /// <summary>
        /// ["<c>lpaPerp</c>"] Futures price limit behaviour: true rejects an order price beyond the limit, false adjusts it to the nearest allowed price
        /// </summary>
        [JsonPropertyName("lpaPerp")]
        public bool PerpetualRejectPriceBeyondLimit { get; set; }
        /// <summary>
        /// ["<c>deltaEnable</c>"] Delta neutral mode enabled
        /// </summary>
        [JsonPropertyName("deltaEnable")]
        public bool? DeltaNeutralModeEnabled { get; set; }
        /// <summary>
        /// ["<c>smsef</c>"] Spot MNT fee deduction enabled
        /// </summary>
        [JsonPropertyName("smsef")]
        public bool SpotMntFeeDeductionEnabled { get; set; }
        /// <summary>
        /// ["<c>fmsef</c>"] Futures MNT fee deduction enabled
        /// </summary>
        [JsonPropertyName("fmsef")]
        public bool FuturesMntFeeDeductionEnabled { get; set; }
        /// <summary>
        /// ["<c>smpType</c>"] Self match prevention type: 0 none, 1 cancel the taker order, 2 cancel the maker order, 3 cancel both
        /// </summary>
        [JsonPropertyName("smpType")]
        public int SelfMatchPreventionType { get; set; }
    }
}
