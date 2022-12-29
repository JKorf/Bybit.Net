using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Repay order responce
    /// </summary>
    public class BybitRepayOrderV3
    {
        /// <summary>
        /// Repay id
        /// </summary>
        [JsonProperty("repayId")]
        public long RepayId { get; set; }
    }
}
