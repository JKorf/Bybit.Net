using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket.Derivatives.Contract
{
    /// <summary>
    /// Position update
    /// </summary>
    public class BybitContractPositionUpdate : BybitDerivativesPositionUpdate
    {
        /// <summary>
        /// Position balance
        /// </summary>
        public decimal PositionBalance { get; set; }

        /// <summary>
        /// Position upper limit corresponding to the current risk limit ID
        /// </summary>
        public decimal? RiskLimitValue { get; set; }

        /// <summary>
        /// Liquidation price
        /// </summary>
        [JsonProperty("liqPrice")]
        public decimal? LiquidationPrice { get; set; }

        /// <summary>
        /// Bankruptcy price
        /// </summary>
        [JsonProperty("bustPrice")]
        public decimal? BankruptcyPrice { get; set; }

        /// <summary>
        /// Trailing stop trigger price. Trailing stop will only be triggered when this price is touched (trailing stop will be immediately triggered by default).
        /// </summary>
        public decimal? ActivePrice { get; set; }

        /// <summary>
        /// Position closing fee occupied (your opening fee + expected maximum closing fee)
        /// </summary>
        [JsonProperty("occClosingFee")]
        public decimal? ClosingFee { get; set; }

        /// <summary>
        /// Whether to add margin automatically
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool AutoAddMargin { get; set; }

        /// <summary>
        /// Trade mode
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public TradeMode TradeMode { get; set; }

        /// <summary>
        /// Stop loss and take profit mode
        /// </summary>
        [JsonProperty("tpSlMode"), JsonConverter(typeof(StopLossTakeProfitModeConverter))]
        public StopLossTakeProfitMode StopMode { get; set; }
    }
}
