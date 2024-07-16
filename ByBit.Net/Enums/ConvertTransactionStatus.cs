using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Convert status
    /// </summary>
    public enum ConvertTransactionStatus
    {
        /// <summary>
        /// Initial
        /// </summary>
        [Map("init")]
        Initial,
        /// <summary>
        /// Processing
        /// </summary>
        [Map("processing")]
        Processing,
        /// <summary>
        /// Successful
        /// </summary>
        [Map("success")]
        Success,
        /// <summary>
        /// Failure
        /// </summary>
        [Map("failure")]
        Failed
    }
}
