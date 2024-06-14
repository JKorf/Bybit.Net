using Newtonsoft.Json;

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
        [JsonProperty("code")]
        public int Code { get; set; }
        /// <summary>
        /// Result message
        /// </summary>
        [JsonProperty("msg")]
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
        public T? Data { get; set; }
    }
}
