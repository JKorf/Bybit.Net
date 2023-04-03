using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Insurance pool info
    /// </summary>
    public class BybitInsurance
    {
        /// <summary>
        /// The asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Balance
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public decimal Value { get; set; }
    }
}
