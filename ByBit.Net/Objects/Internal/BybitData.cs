using System;
using System.Collections.Generic;
using System.Text;

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
        public T Data { get; set; }
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

}
