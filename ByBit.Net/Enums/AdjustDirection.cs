using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Adjust direction
    /// </summary>
    public enum AdjustDirection
    {
        /// <summary>
        /// Add
        /// </summary>
        [Map("0")]
        Add,
        /// <summary>
        /// Reduce
        /// </summary>
        [Map("1")]
        Reduce
    }
}
