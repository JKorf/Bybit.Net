using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Position info
    /// </summary>
    public abstract class BybitDerivativesPosition
    {
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonProperty("positionIdx"), JsonConverter(typeof(PositionModeConverter))]
        public PositionMode PositionMode { get; set; }

        /// <summary>
        /// Risk id
        /// </summary>
        public long RiskId { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(PositionSideConverter))]
        public PositionSide Side { get; set; }

        /// <summary>
        /// Position status
        /// </summary>
        [JsonConverter(typeof(PositionStatusConverter))]
        public PositionStatus PositionStatus { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Average entry price
        /// </summary>
        public decimal EntryPrice { get; set; }

        /// <summary>
        /// Mark price
        /// </summary>
        public decimal? MarkPrice { get; set; }

        /// <summary>
        /// Under the isolated margin mode, the value should be the leverage set by the user. Under the cross margin mode, the value should be the maximum leverage under the current risk limit. For contracts only, and not for options.
        /// </summary>
        public decimal? Leverage { get; set; }

        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonProperty("takeProfit")]
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonProperty("stopLoss")]
        public decimal? StopLoss { get; set; }

        /// <summary>
        /// Trailing stop
        /// </summary>
        [JsonProperty("trailingStop")]
        public decimal? TrailingStop { get; set; }

        /// <summary>
        /// Settlement price, for USDC only
        /// </summary>
        [JsonProperty("sessionAvgPrice")]
        public decimal? SettlementPrice { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public decimal PositionValue { get; set; }

        /// <summary>
        /// Unrealized pnl
        /// </summary>
        public decimal? UnrealisedPnl { get; set; }

        /// <summary>
        /// The account creation time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Update time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdatedTime { get; set; }

        /// <summary>
        /// Accumulated realized pnl (all-time total)
        /// </summary>
        [JsonProperty("cumRealisedPnl")]
        public decimal? TotalRealizedPnl { get; set; }

        /// <summary>
        /// Position Initial margin
        /// </summary>
        [JsonProperty("positionIM")]
        public decimal? InitialMargin { get; set; }

        /// <summary>
        /// Position Maintenance margin
        /// </summary>
        [JsonProperty("positionMM")]
        public decimal? MaintenanceMargin { get; set; }
    }
}
