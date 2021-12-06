using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Transfer id
    /// </summary>
    public class BybitTransfer
    {
        /// <summary>
        /// Transfer id
        /// </summary>
        [JsonProperty("transfer_id")]
        public string TransferId { get; set; } = string.Empty;
    }
}
