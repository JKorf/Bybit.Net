using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Loan status
    /// </summary>
    public enum LoanStatus
    {
        /// <summary>
        /// Fully repaid manually
        /// </summary>
        [Map("1")]
        FullyRepaidManually,
        /// <summary>
        /// Fully repaid by liquidation
        /// </summary>
        [Map("2")]
        FullyRepaidByLiquidation
    }
}
