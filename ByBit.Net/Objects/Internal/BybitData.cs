using Bybit.Net.Enums;
using System.Text.Json.Serialization;

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

        [JsonPropertyName("list")]
        internal T ListData { set => Data = value; get => Data; }
        [JsonPropertyName("dataList")]
        internal T ListData1 { set => Data = value; get => Data; }
        [JsonPropertyName("rows")]
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

        [JsonPropertyName("nextPageCursor")]
        internal string? NextPageCursor { set => Cursor = value; get => Cursor; }

        /// <summary>
        /// Result total size
        /// </summary>
        public int? ResultTotalSize { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string? Currency { get; set; } = string.Empty;
    }

    /// <summary>
    /// Cursof paged data wrapper for unified margin
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BybitDerivativesCursorPage<T> : BybitCursorPage<T>
    {
        /// <summary>
        /// Type of derivatives product
        /// </summary>
        [JsonPropertyName("category"), JsonConverter(typeof(EnumConverter))]
        public Category Category { get; set; } = Category.Undefined;
    }
}
