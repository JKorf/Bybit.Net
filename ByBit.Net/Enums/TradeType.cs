using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Trade type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TradeType>))]
    public enum TradeType
    {
        /// <summary>
        /// Normal trade
        /// </summary>
        [Map("Trade")]
        Trade,
        /// <summary>
        /// Adl trade
        /// </summary>
        [Map("AdlTrade")]
        AdlTrade,
        /// <summary>
        /// Funding trade
        /// </summary>
        [Map("Funding")]
        Funding,
        /// <summary>
        /// Bankruptcy trade
        /// </summary>
        [Map("BustTrade")]
        BustTrade,
        /// <summary>
        /// Settle
        /// </summary>
        [Map("Settle")]
        Settle,
        /// <summary>
        /// Delivery
        /// </summary>
        [Map("Delivery")]
        Delivery,
        /// <summary>
        /// Block trade
        /// </summary>
        [Map("BlockTrade")]
        BlockTrade,
        /// <summary>
        /// Move position
        /// </summary>
        [Map("MovePosition")]
        MovePosition,
        /// <summary>
        /// Spread trade
        /// </summary>
        [Map("FutureSpread")]
        FutureSpread
    }
}
