using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Set risk limit info
    /// </summary>
    public class BybitSetRiskLimit
    {
        /// <summary>
        /// The risk id
        /// </summary>
        public int RiskId { get; set; }
        /// <summary>
        /// Risk limit value
        /// </summary>
        public decimal RiskLimitValue { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public Category Category { get; set; }
    }
}
