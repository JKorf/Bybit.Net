using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Earn order status
    /// </summary>
    public enum EarnOrderStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        [Map("Success")]
        Success,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("Fail")]
        Failed,
        /// <summary>
        /// Pending
        /// </summary>
        [Map("Pending")]
        Pending
    }
}
