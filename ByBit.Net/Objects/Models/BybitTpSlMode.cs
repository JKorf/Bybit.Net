using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Mode info
    /// </summary>
    public class BybitTpSlMode
    {
        /// <summary>
        /// New mode
        /// </summary>
        [JsonProperty("tp_sl_mode"), JsonConverter(typeof(StopLossTakeProfitModeConverter))]
        public StopLossTakeProfitMode Mode { get; set; }
    }
}
