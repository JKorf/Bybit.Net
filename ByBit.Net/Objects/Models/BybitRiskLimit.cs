using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Risk limit info
    /// </summary>
    public class BybitRiskLimit
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
        [JsonProperty("maintain_margin")]
        public decimal MaintainMargin { get; set; }
        /// <summary>
        /// Starting margin
        /// </summary>
        [JsonProperty("starting_margin")]
        public decimal StartingMargin { get; set; }
        /// <summary>
        /// Section
        /// </summary>
        public IEnumerable<string> Section { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Is lowest risk
        /// </summary>
        [JsonProperty("is_lowest_risk")]
        public bool IsLowestRisk { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updated_at")]        
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Max leverage
        /// </summary>
        [JsonProperty("max_leverage")]
        public decimal MaxLeverage { get; set; }
    }
}
