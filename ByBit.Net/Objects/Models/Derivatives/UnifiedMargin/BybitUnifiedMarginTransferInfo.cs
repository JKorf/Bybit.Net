using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Transfer between two accounts info
    /// </summary>
    public class BybitUnifiedMarginTransferInfo
    {
        /// <summary>
        /// UUID, globally unique
        /// </summary>
        [JsonProperty("transfer_id")]
        public string ID { get; set; } = string.Empty;
    }
}
