using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Repayment type
    /// </summary>
    public enum RepayType
    {
        /// <summary>
        /// By user
        /// </summary>
        [Map("1")]
        ByUser,
        /// <summary>
        /// By liquidation
        /// </summary>
        [Map("2")]
        ByLiquidation
    }
}
