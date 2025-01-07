using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Loan type
    /// </summary>
    public enum LoanType
    {
        /// <summary>
        /// Fixed term
        /// </summary>
        [Map("1")]
        FixedTerm,
        /// <summary>
        /// Flexible term
        /// </summary>
        [Map("2")]
        FlexibleTerm
    }
}
