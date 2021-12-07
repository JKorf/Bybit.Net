using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// Delta update
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class BybitDeltaUpdate<T>
    {
        /// <summary>
        /// Delete entries
        /// </summary>
        public IEnumerable<T> Delete { get; set; } = Array.Empty<T>();
        /// <summary>
        /// Update entries
        /// </summary>
        public IEnumerable<T> Update { get; set; } = Array.Empty<T>();
        /// <summary>
        /// Insert entries
        /// </summary>
        public IEnumerable<T> Insert { get; set; } = Array.Empty<T>();
    }
}
