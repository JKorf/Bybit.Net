using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Margin item
    /// </summary>
    public record BybitSpotMarginBorrowRate
    {
        /// <summary>
        /// The asset
        /// </summary>
        [JsonProperty("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Vip level
        /// </summary>
        [JsonProperty("vipLevel")]
        public string VipLevel { get; set; } = string.Empty;
        /// <summary>
        /// Collateral ratio
        /// </summary>
        [JsonProperty("hourlyBorrowRate")]
        public decimal HourlyBorrowRate { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("timestamp"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
