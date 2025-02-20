using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Product status
    /// </summary>
    public enum EarnProductStatus
    {
        /// <summary>
        /// Available
        /// </summary>
        [Map("Available")]
        Available,
        /// <summary>
        /// Not available
        /// </summary>
        [Map("NotAvailable")]
        NotAvailable
    }
}
