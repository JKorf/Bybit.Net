using Bybit.Net.Objects.Models;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Internal
{
    /// <summary>
    /// Data wrapper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BybitData<T>
    {
        /// <summary>
        /// The data
        /// </summary>
#pragma warning disable 8618
        public T Data { get; set; }
#pragma warning restore

        [JsonProperty("list")]
        internal T ListData { set => Data = value; get => Data; }
        [JsonProperty("rows")]
        internal T RowData { set => Data = value; get => Data; }
    }

    /// <summary>
    /// Cursor paged data wrapper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BybitCursorPage<T> : BybitData<T> 
    {
        /// <summary>
        /// Cursor for requesting next/previous page
        /// </summary>
        public string? Cursor { get; set; }
    }

    /// <summary>
    /// Cursor paged data wrapper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BybitPage<T> : BybitData<T>
    {
        /// <summary>
        /// Current page
        /// </summary>
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }
    }

    internal class BybitPositionData: BybitData<BybitPosition>
    {
        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }
    }

    internal class BybitPositionUsdData : BybitData<BybitPositionUsd>
    {
        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }
    }

}
