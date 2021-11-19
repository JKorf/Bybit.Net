using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Predicted funding rate and fee
    /// </summary>
    public class BybitPredictedFunding
    {
        /// <summary>
        /// Predicted funding rate
        /// </summary>
        [JsonProperty("predicted_funding_rate")]
        public decimal PredictedFundingRate { get; set; }
        /// <summary>
        /// Predicted funding fee
        /// </summary>
        [JsonProperty("predicted_funding_fee")]
        public decimal PredictedFundingFee { get; set; }
    }
}
