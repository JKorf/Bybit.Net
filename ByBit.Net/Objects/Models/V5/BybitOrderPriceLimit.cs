using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Order price limit
    /// </summary>
    public record BybitOrderPriceLimit
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Highest bid price
        /// </summary>
        [JsonPropertyName("buyLmt")]
        public decimal BuyLimit { get; set; }
        /// <summary>
        /// Lowest ask price
        /// </summary>
        [JsonPropertyName("sellLmt")]
        public decimal SellLimit { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
    }
}
