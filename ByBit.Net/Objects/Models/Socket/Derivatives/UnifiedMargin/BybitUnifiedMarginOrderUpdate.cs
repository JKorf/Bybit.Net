using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Derivatives.UnifiedMargin;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Order info
    /// </summary>
    public class BybitUnifiedMarginOrderUpdate : BybitUnifiedMarginOrder
    {
        /// <summary>
        /// Type of trigger price, latest market price by default.
        /// </summary>
        [JsonProperty("triggerBy"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType? TriggerType { get; set; }
    }
}
