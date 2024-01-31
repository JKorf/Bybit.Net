using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Result
    /// </summary>
    public class BybitOperationResult
    {
        /// <summary>
        /// Success
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Success { get; set; }
    }
}
