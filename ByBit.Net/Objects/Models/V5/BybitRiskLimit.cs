using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Risk limit info
    /// </summary>
    public class BybitRiskLimit
    {
        /// <summary>
        /// Risk limit id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Risk limit value
        /// </summary>
        public decimal RiskLimitValue { get; set; }
        /// <summary>
        /// Maintenance margin
        /// </summary>
        public decimal MaintenanceMargin { get; set; }
        /// <summary>
        /// Initial margin
        /// </summary>
        public decimal InitialMargin { get; set; }
        /// <summary>
        /// Is lowest risk
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool IsLowestRisk { get; set; }
        /// <summary>
        /// Max leverage
        /// </summary>
        public decimal MaxLeverage { get; set; }
    }
}
