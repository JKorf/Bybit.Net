﻿using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Batch item result
    /// </summary>
    public record BybitBatchResult
    {
        /// <summary>
        /// Result code
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }
        /// <summary>
        /// Result message
        /// </summary>
        [JsonPropertyName("msg")]
        public string Message { get; set; } = string.Empty;
    }
    
    /// <summary>
    /// Batch item result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public record BybitBatchResult<T> : BybitBatchResult
    {
        /// <summary>
        /// Response data
        /// </summary>
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}
