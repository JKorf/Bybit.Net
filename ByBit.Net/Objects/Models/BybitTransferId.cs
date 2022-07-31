using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Transfer id
    /// </summary>
    public class BybitTransferId
    {
        /// <summary>
        /// Transfer id
        /// </summary>
        [JsonProperty("transfer_id")]
        public string TransferId { get; set; } = string.Empty;
    }
}
