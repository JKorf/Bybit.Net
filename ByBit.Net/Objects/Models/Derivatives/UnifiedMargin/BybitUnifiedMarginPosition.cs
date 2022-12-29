using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Derivatives;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Position info
    /// </summary>
    public class BybitUnifiedMarginPosition : BybitDerivativesPosition
    {
        /// <summary>
        /// Type of derivatives product: linear or option.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Stop loss and take profit mode
        /// </summary>
        [JsonProperty("tpslMode"), JsonConverter(typeof(StopLossTakeProfitModeConverter))]
        public StopLossTakeProfitMode StopMode { get; set; }
    }
}
