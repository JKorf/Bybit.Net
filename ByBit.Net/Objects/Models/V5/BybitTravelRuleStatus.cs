using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Travel rule status
    /// </summary>
    public record BybitTravelRuleStatus
    {
        /// <summary>
        /// ["<c>travel_rule_status</c>"] Travel rule status
        /// </summary>
        [JsonPropertyName("travel_rule_status")]
        public TravelRuleStatus Status { get; set; }
    }
}
