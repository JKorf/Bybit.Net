using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Fee group
    /// </summary>
    [JsonConverter(typeof(EnumConverter<FeeGroup>))]
    public enum FeeGroup
    {
        /// <summary>
        /// Major coins
        /// </summary>
        [Map("1")]
        MajorCoins,
        /// <summary>
        /// High growth
        /// </summary>
        [Map("2")]
        HighGrowth,
        /// <summary>
        /// Mid-Tier liquidity
        /// </summary>
        [Map("3")]
        MidTierLiquidity,
        /// <summary>
        /// Mid-Tier activation
        /// </summary>
        [Map("4")]
        MidTierActivation,
        /// <summary>
        /// Long tail
        /// </summary>
        [Map("5")]
        LongTail,
        /// <summary>
        /// Innovation zone
        /// </summary>
        [Map("6")]
        InnovationZone,
        /// <summary>
        /// Pre-Listing
        /// </summary>
        [Map("7")]
        PreListing,
        /// <summary>
        /// USDC contracts
        /// </summary>
        [Map("8")]
        USDCContracts,
        /// <summary>
        /// TradeFi perps
        /// </summary>
        [Map("9")]
        TradeFiPerps,
    }

}
