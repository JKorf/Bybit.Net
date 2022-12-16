using Bybit.Net.Converters;
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
        public decimal RiskLimitValue { get; set; }

        /// <summary>
        /// Liquidation price
        /// </summary>
        [JsonProperty("liqPrice")]
        public decimal LiquidationPrice { get; set; }

        /// <summary>
        /// Bankruptcy price
        /// </summary>
        [JsonProperty("bustPrice")]
        public decimal BankruptcyPrice { get; set; }

        /// <summary>
        /// Whether to add margin automatically
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool AutoAddMargin { get; set; }

        /// <summary>
        /// Trade mode
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public bool TradeMode { get; set; }
    }
}
