using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Risk id
    /// </summary>
    public class BybitRiskId
    {
        /// <summary>
        /// Risk id
        /// </summary>
        [JsonProperty("risk_id")]
        public long RiskId { get; set; }
    }
}
