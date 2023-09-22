using Bybit.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Marging status
    /// </summary>
    public class BybitSpotMarginStatus
    {
        /// <summary>
        /// Is spot margin mode activated
        /// </summary>
        [JsonProperty("spotMarginMode"), JsonConverter(typeof(BoolConverter))]
        public bool SpotMarginMode { get; set; }
    }
}
