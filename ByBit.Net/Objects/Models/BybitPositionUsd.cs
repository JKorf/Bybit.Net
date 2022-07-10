using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Position info
    /// </summary>
    public class BybitPositionUsd: BybitPositionBase
    {
        /// <summary>
        /// Whether the current data is valid. Only use data when IsValid is true
        /// </summary>
        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }
        /// <summary>
        /// Is isolated margin mode
        /// </summary>
        [JsonProperty("is_isolated")]
        public bool IsIsolated { get; set; }
        /// <summary>
        /// Quantity which can be closed
        /// </summary>
        [JsonProperty("free_qty")]
        public decimal FreeQuantity { get; set; }
        /// <summary>
        /// Stop loss and take profit mode
        /// </summary>
        [JsonProperty("tp_sl_mode"), JsonConverter(typeof(StopLossTakeProfitModeConverter))]
        public StopLossTakeProfitMode StopLossTakeProfitMode { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        [JsonProperty("unrealised_pnl")]
        public decimal UnrealizedPnl { get; set; }

        /// <summary>
        /// Deleverage indicator level (1,2,3,4,5)
        /// </summary>
        [JsonProperty("deleverage_indicator")]
        public int DeleverageIndicator { get; set; }
        /// <summary>
        /// Pre-occupancy closing fee
        /// </summary>
        [JsonProperty("occ_closing_fee")]
        public decimal ClosingFee { get; set; }
    }
}
