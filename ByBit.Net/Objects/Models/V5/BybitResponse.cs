using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Bybit response
    /// </summary>
    public class BybitBaseResponse
    {
        /// <summary>
        /// Category
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public Category? Category { get; set; }
        /// <summary>
        /// Total items
        /// </summary>
        public int? Total { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string? Symbol { get; set; }
        /// <summary>
        /// Cursor for pagination
        /// </summary>
        public string? NextPageCursor { get; set; }
        /// <summary>
        /// Data updated time
        /// </summary>
        [JsonProperty("updatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdateTime { get; set; }
    }

    /// <summary>
    /// Bybit response info
    /// </summary>
    /// <typeparam name="T">Type of the response data</typeparam>
    public class BybitResponse<T> : BybitBaseResponse
    {
        /// <summary>
        /// Data list
        /// </summary>
        public IEnumerable<T> List { get; set; } = Array.Empty<T>();

        [JsonProperty("rows")]
        internal IEnumerable<T> Rows
        {
            get => List;
            set => List = value;
        }
    }
}
