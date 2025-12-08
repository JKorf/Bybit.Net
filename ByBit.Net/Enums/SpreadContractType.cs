using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Spread symbol contract type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SpreadContractType>))]
    public enum SpreadContractType
    {
        /// <summary>
        /// Perpetual and spot combination
        /// </summary>
        [Map("FundingRateArb")]
        FundingRateArb,
        /// <summary>
        /// Futures and spot combination
        /// </summary>
        [Map("CarryTrade")]
        CarryTrade,
        /// <summary>
        /// Different expiry futures combination
        /// </summary>
        [Map("FutureSpread")]
        FutureSpread,
        /// <summary>
        /// Futures and Perpetual combination
        /// </summary>
        [Map("PerpBasis")]
        PerpBasis
    }
}
