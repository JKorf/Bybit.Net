using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// Position update
    /// </summary>
    public class BybitPositionUpdate: BybitPositionBase
    {
        /// <summary>
        /// Take profit trigger
        /// </summary>
        [JsonProperty("tp_trigger_by"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType TakeProfitTriggerBy { get; set; }
        /// <summary>
        /// Stop loss trigger
        /// </summary>
        [JsonProperty("sl_trigger_by"), JsonConverter(typeof(TriggerTypeConverter))]
        public TriggerType StopLossTriggeredBy { get; set; }
        /// <summary>
        /// Trailing stop trigger
        /// </summary>
        [JsonProperty("trailing_active")]
        public decimal? TrailingActive { get; set; }
        /// <summary>
        /// Position status
        /// </summary>
        [JsonProperty("position_status"), JsonConverter(typeof(PositionStatusConverter))]
        public PositionStatus PositionStatus { get; set; }
        /// <summary>
        /// Position closing fee occupied (your opening fee + expected maximum closing fee)
        /// </summary>
        [JsonProperty("occ_closing_fee")]
        public decimal ClosingFee { get; set; }
        /// <summary>
        /// Pre-occupied order margin
        /// </summary>
        [JsonProperty("order_margin")]
        public decimal OrderMargin { get; set; }
        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("wallet_balance")]
        public decimal WalletBalance { get; set; }
        /// <summary>
        /// Position sequence
        /// </summary>
        [JsonProperty("position_seq")]
        public long PositionSequence { get; set; }
    }
}
