using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Repayment status
    /// </summary>
    public enum RepayStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        [Map("1")]
        Success,
        /// <summary>
        /// Processing
        /// </summary>
        [Map("2")]
        Processing
    }
}
