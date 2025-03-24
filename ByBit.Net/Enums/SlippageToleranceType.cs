﻿using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Tolerance type
    /// </summary>
    public enum SlippageToleranceType
    {
        /// <summary>
        /// Tick size, the best price at the moment + (slippageTolerance * tickSize)
        /// </summary>
        [Map("TickSize")]
        TickSize,
        /// <summary>
        /// Percentage
        /// </summary>
        [Map("Percent")]
        Percentage,
        /// <summary>
        /// Unknown
        /// </summary>
        [Map("UNKNOWN")]
        Unknown
    }
}
