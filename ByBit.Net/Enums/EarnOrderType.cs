using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Earn order type
    /// </summary>
    public enum EarnOrderType
    {
        /// <summary>
        /// Stake
        /// </summary>
        [Map("Stake")]
        Stake,
        /// <summary>
        /// Redeem
        /// </summary>
        [Map("Redeem")]
        Redeem
    }
}
