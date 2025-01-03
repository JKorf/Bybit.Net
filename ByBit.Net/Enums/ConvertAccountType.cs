﻿using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Convert account type
    /// </summary>
    public enum ConvertAccountType
    {
        /// <summary>
        /// Funding account
        /// </summary>
        [Map("eb_convert_funding")]
        ConvertFunding,
        /// <summary>
        /// UTA account
        /// </summary>
        [Map("eb_convert_uta")]
        ConvertUta,
        /// <summary>
        /// Spot account
        /// </summary>
        [Map("eb_convert_spot")]
        ConvertSpot,
        /// <summary>
        /// Contract account
        /// </summary>
        [Map("eb_convert_contract")]
        ConvertContract,
        /// <summary>
        /// Inverse account
        /// </summary>
        [Map("eb_convert_inverse")]
        ConvertInverse
    }
}
