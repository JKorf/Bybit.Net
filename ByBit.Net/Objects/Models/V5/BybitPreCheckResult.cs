using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// PreCheck order result
    /// </summary>
    public record BybitPreCheckResult
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Initial margin rate before checking, keep four decimal places. For examples, 30 means IMR = 30/1e4 = 0.30%
        /// </summary>
        [JsonPropertyName("preImrE4")]
        public decimal InitialMarginRatePreCheck { get; set; }
        /// <summary>
        /// Maintenance margin rate before checking, keep four decimal places. For examples, 30 means MMR = 30/1e4 = 0.30%
        /// </summary>
        [JsonPropertyName("preMmrE4")]
        public decimal MaintenanceMarginRatePreCheck { get; set; }
        /// <summary>
        /// Initial margin rate calculated after checking, keep four decimal places. For examples, 30 means IMR = 30/1e4 = 0.30%
        /// </summary>
        [JsonPropertyName("postImrE4")]
        public decimal InitialMarginRatePostCheck { get; set; }
        /// <summary>
        /// Maintenance margin rate calculated after checking, keep four decimal places. For examples, 30 means MMR = 30/1e4 = 0.30%
        /// </summary>
        [JsonPropertyName("postMmrE4")]
        public decimal MaintenanceMarginRatePostCheck { get; set; }
    }


}
