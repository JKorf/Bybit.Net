using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Transfer id
    /// </summary>
    public record BybitTransferId
    {
        /// <summary>
        /// Transfer id
        /// </summary>
        [JsonProperty("transferId")]
        public string TransferId { get; set; } = string.Empty;

        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("status")]
        public TransferStatus Status { get; set; }
    }
}
