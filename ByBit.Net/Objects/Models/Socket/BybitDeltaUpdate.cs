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
        public IEnumerable<T> Delete { get; set; }
        /// <summary>
        /// Update entries
        /// </summary>
        public IEnumerable<T> Update { get; set; }
        /// <summary>
        /// Insert entries
        /// </summary>
        public IEnumerable<T> Insert { get; set; }
    }
}
