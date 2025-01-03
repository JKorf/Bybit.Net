﻿using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Asset side
    /// </summary>
    public enum ConvertAssetSide
    {
        /// <summary>
        /// From asset list, the balance is given if you have it
        /// </summary>
        [Map("0")]
        FromAssetList,
        /// <summary>
        /// To asset list, asset to buy
        /// </summary>
        [Map("1")]
        ToAssetList
    }
}
