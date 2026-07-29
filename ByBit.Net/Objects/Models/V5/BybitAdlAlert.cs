using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// ADL alert
    /// </summary>
    public record BybitAdlAlert
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset of the insurance pool
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        [JsonInclude, JsonPropertyName("c")]
        internal string WSAsset { set => Asset = value; }

        /// <summary>
        /// ["<c>symbol</c>"] Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        [JsonInclude, JsonPropertyName("s")]
        internal string WSSymbol { set => Symbol = value; }

        /// <summary>
        /// ["<c>balance</c>"] Insurance fund balance
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        [JsonInclude, JsonPropertyName("b")]
        internal decimal WSBalance { set => Balance = value; }

        /// <summary>
        /// ["<c>insurancePnlRatio</c>"] PnL ratio threshold for triggering contract PnL drawdown ADL
        /// </summary>
        [JsonPropertyName("insurancePnlRatio")]
        public decimal InsuranceThresholdPnlRatio { get; set; }
        [JsonInclude, JsonPropertyName("i_pr")]
        internal decimal WSInsuranceThresholdPnlRatio { set => InsuranceThresholdPnlRatio = value; }

        /// <summary>
        /// ["<c>pnlRatio</c>"] Symbol's PnL drawdown ratio in the last 8 hours. Used to determine whether ADL is triggered or stopped
        /// </summary>
        [JsonPropertyName("pnlRatio")]
        public decimal PnlRatio { get; set; }
        [JsonInclude, JsonPropertyName("pr")]
        internal decimal WSPnlRatio { set => PnlRatio = value; }

        /// <summary>
        /// ["<c>adlTriggerThreshold</c>"] Trigger threshold for contract PnL drawdown ADL
        /// </summary>
        [JsonPropertyName("adlTriggerThreshold")]
        public decimal AdlTriggerThreshold { get; set; }
        [JsonInclude, JsonPropertyName("adl_tt")]
        internal decimal WSAdlTriggerThreshold { set => AdlTriggerThreshold = value; }

        /// <summary>
        /// ["<c>adlStopRatio</c>"] Stop ratio threshold for contract PnL drawdown ADL
        /// </summary>
        [JsonPropertyName("adlStopRatio")]
        public decimal AdlStopThreshold { get; set; }
        [JsonInclude, JsonPropertyName("adl_sr")]
        internal decimal WSAdlStopThreshold { set => AdlStopThreshold = value; }
        /// <summary>
        /// ["<c>maxBalance</c>"] Maximum balance
        /// </summary>
        [JsonPropertyName("maxBalance")]
        public decimal? MaxBalance { get; set; }
    }
}
