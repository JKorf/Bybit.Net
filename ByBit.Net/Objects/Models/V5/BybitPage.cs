using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Bybit page
    /// </summary>
    public record BybitPage<T>
    {
        /// <summary>
        /// Current page
        /// </summary>
        [JsonPropertyName("cursor")]
        public int Page { get; set; }
        /// <summary>
        /// Page size
        /// </summary>
        [JsonPropertyName("size")]
        public int PageSize { get; set; }
        /// <summary>
        /// Last page
        /// </summary>
        [JsonPropertyName("lastPage")]
        public int LastPage { get; set; }
        /// <summary>
        /// Total count
        /// </summary>
        [JsonPropertyName("totalCount")]
        public int Total { get; set; }
        /// <summary>
        /// Page records
        /// </summary>
        [JsonPropertyName("records")]
        public T[] Records { get; set; } = [];
    }
}
