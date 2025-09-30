using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Index components
    /// </summary>
    public record BybitIndexComponents
    {
        /// <summary>
        /// Index name
        /// </summary>
        [JsonPropertyName("indexName")]
        public string IndexName { get; set; } = string.Empty;
        /// <summary>
        /// Last price
        /// </summary>
        [JsonPropertyName("lastPrice")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("updateTime")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// The components
        /// </summary>
        [JsonPropertyName("components")]
        public BybitIndexComponent[] Components { get; set; } = [];
    }

    /// <summary>
    /// Index component
    /// </summary>
    public record BybitIndexComponent
    {
        /// <summary>
        /// Exchange name
        /// </summary>
        [JsonPropertyName("exchange")]
        public string Exchange { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("spotPair")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Equivalent price
        /// </summary>
        [JsonPropertyName("equivalentPrice")]
        public decimal EquivalentPrice { get; set; }
        /// <summary>
        /// Multiplier used for the component price
        /// </summary>
        [JsonPropertyName("multiplier")]
        public decimal Multiplier { get; set; }
        /// <summary>
        /// Actual price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Weight in the index calculation
        /// </summary>
        [JsonPropertyName("weight")]
        public decimal Weight { get; set; }

    }
}
