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
    /// Leg category
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SpreadLegCategory>))]
    public enum SpreadLegCategory
    {
        /// <summary>
        /// Combination
        /// </summary>
        [Map("combination")]
        Combination,
        /// <summary>
        /// Spot leg
        /// </summary>
        [Map("spot_leg")]
        SpotLeg,
        /// <summary>
        /// Futures leg
        /// </summary>
        [Map("future_leg")]
        FutureLeg
    }
}
