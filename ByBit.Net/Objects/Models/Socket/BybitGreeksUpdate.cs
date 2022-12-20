using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// Greeks update
    /// </summary>
    public class BybitGreeksUpdate
    {
        /// <summary>
        /// Base currency
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// Close price
        /// </summary>
        [JsonProperty("totalDelta")]
        public decimal Delta { get; set; }

        /// <summary>
        /// Close price
        /// </summary>
        [JsonProperty("totalGamma")]
        public decimal Gamma { get; set; }

        /// <summary>
        /// Close price
        /// </summary>
        [JsonProperty("totalVega")]
        public decimal Vega { get; set; }

        /// <summary>
        /// Close price
        /// </summary>
        [JsonProperty("totalTheta")]
        public decimal Theta { get; set; }
    }
}
