﻿using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Bybit response
    /// </summary>
    public record BybitBaseResponse
    {
        /// <summary>
        /// Category
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("category")]
        public Category? Category { get; set; }
        /// <summary>
        /// Total items
        /// </summary>
        [JsonPropertyName("total")]
        public int? Total { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }
        /// <summary>
        /// Cursor for pagination
        /// </summary>
        [JsonPropertyName("nextPageCursor")]
        public string? NextPageCursor { get; set; }
        /// <summary>
        /// Data updated time
        /// </summary>
        [JsonPropertyName("updatedTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? UpdateTime { get; set; }
    }

    /// <summary>
    /// Bybit response info
    /// </summary>
    /// <typeparam name="T">Type of the response data</typeparam>
    public record BybitResponse<T> : BybitBaseResponse
    {
        /// <summary>
        /// Data list
        /// </summary>
        [JsonPropertyName("list")]
        public IEnumerable<T> List { get; set; } = Array.Empty<T>();

        [JsonPropertyName("rows")]
        internal IEnumerable<T> Rows
        {
            get => List;
            set => List = value;
        }
    }
}
