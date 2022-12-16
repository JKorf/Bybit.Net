using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Risk limit info
    /// </summary>
    public class BybitDerivativesRiskLimit
    {
        /// <summary>
        /// Risk id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Risk limit
        /// </summary>
        public decimal Limit { get; set; }
        /// <summary>
        /// Maintain margin
        /// </summary>
        public decimal MaintainMargin { get; set; }
        /// <summary>
        /// Starting margin
        /// </summary>
        [JsonProperty("initialMargin")]
        public decimal StartingMargin { get; set; }
        /// <summary>
        /// Section
        /// </summary>
        public IEnumerable<string> Section { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Is lowest risk
        /// </summary>
        public bool IsLowestRisk { get; set; }
        /// <summary>
        /// Max leverage
        /// </summary>
        public decimal MaxLeverage { get; set; }
    }
}
