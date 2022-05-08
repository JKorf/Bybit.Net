using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Position info
    /// </summary>
    public class BybitPosition: BybitPositionBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; } = string.Empty;     
        /// <summary>
        /// Whether the current data is valid. Only use data when IsValid is true
        /// </summary>
        public bool IsValid { get; set; }        
        /// <summary>
        /// Isolated margin mode
        /// </summary>
        [JsonProperty("is_isolated")]
        public bool IsIsolated { get; set; }   
        /// <summary>
        /// Effective leverage
        /// </summary>
        [JsonProperty("effective_leverage")]
        public decimal EffectiveLeverage { get; set; }         
        /// <summary>
        /// Deleverage indicator level (1,2,3,4,5)
        /// </summary>
        [JsonProperty("deleverage_indicator")]
        public int DeleverageIndicator { get; set; }
        /// <summary>
        /// Position status
        /// </summary>
        [JsonProperty("position_status"), JsonConverter(typeof(PositionStatusConverter))]
        public PositionStatus PositionStatus { get; set; }
        /// <summary>
        /// Unrealized pnl
        /// </summary>
        [JsonProperty("unrealised_pnl")]
        public decimal UnrealizedPnl { get; set; }        
        /// <summary>
        /// Cross sequence
        /// </summary>
        [JsonProperty("cross_seq")]
        public long CrossSequence { get; set; }        
        /// <summary>
        /// The account creation time
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Stop loss and take profit mode
        /// </summary>
        [JsonProperty("tp_sl_mode"), JsonConverter(typeof(StopLossTakeProfitModeConverter))]
        public StopLossTakeProfitMode StopMode { get; set; }
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
        /// <summary>
        /// Accumelated fee
        /// </summary>
        [JsonProperty("cum_commission")]
        public decimal? AccumulatedFee { get; set; }
}
}
