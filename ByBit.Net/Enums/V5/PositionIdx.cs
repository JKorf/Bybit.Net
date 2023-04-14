using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums.V5
{
    /// <summary>
    /// Position idx
    /// </summary>
    public enum PositionIdx
    {
        /// <summary>
        /// One way mode
        /// </summary>
        [Map("0")]
        OneWayMode,
        /// <summary>
        /// Buy side of hedge mode
        /// </summary>
        [Map("1")]
        BuyHedgeMode,
        /// <summary>
        /// Sell side of hedge mode
        /// </summary>
        [Map("2")]
        SellHedgeMode
    }
}
