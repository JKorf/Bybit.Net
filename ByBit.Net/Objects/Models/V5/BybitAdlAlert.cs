using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// ADL alert
    /// </summary>
    public record BybitAdlAlert
    {
        /// <summary>
        /// Asset of the insurance pool
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        [JsonInclude, JsonPropertyName("c")]
        internal string WSAsset { set => Asset = value; }

        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        [JsonInclude, JsonPropertyName("s")]
        internal string WSSymbol { set => Symbol = value; }

        /// <summary>
        /// Insurance fund balance
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        [JsonInclude, JsonPropertyName("b")]
        internal decimal WSBalance { set => Balance = value; }

        /// <summary>
        /// Maximum balance of the insurance pool in the last 8 hours
        /// </summary>
        [JsonPropertyName("maxBalance")]
        public decimal MaxBalance { get; set; }
        [JsonInclude, JsonPropertyName("mb")]
        internal decimal WSMaxBalance { set => MaxBalance = value; }

        /// <summary>
        /// PnL ratio threshold for triggering contract PnL drawdown ADL
        /// </summary>
        [JsonPropertyName("insurancePnlRatio")]
        public decimal InsuranceThresholdPnlRatio { get; set; }
        [JsonInclude, JsonPropertyName("i_pr")]
        internal decimal WSInsuranceThresholdPnlRatio { set => InsuranceThresholdPnlRatio = value; }

        /// <summary>
        /// Symbol's PnL drawdown ratio in the last 8 hours. Used to determine whether ADL is triggered or stopped
        /// </summary>
        [JsonPropertyName("pnlRatio")]
        public decimal PnlRatio { get; set; }
        [JsonInclude, JsonPropertyName("pr")]
        internal decimal WSPnlRatio { set => PnlRatio = value; }

        /// <summary>
        /// Trigger threshold for contract PnL drawdown ADL
        /// </summary>
        [JsonPropertyName("adlTriggerThreshold")]
        public decimal AdlTriggerThreshold { get; set; }
        [JsonInclude, JsonPropertyName("adl_tt")]
        internal decimal WSAdlTriggerThreshold { set => AdlTriggerThreshold = value; }

        /// <summary>
        /// Stop ratio threshold for contract PnL drawdown ADL
        /// </summary>
        [JsonPropertyName("adlStopRatio")]
        public decimal AdlStopThreshold { get; set; }
        [JsonInclude, JsonPropertyName("adl_sr")]
        internal decimal WSAdlStopThreshold { set => AdlStopThreshold = value; }
    }
}
