using System.Text.Json.Serialization;
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
        /// ["<c>Trade</c>"] Normal trade
        /// </summary>
        [Map("Trade")]
        Trade,
        /// <summary>
        /// ["<c>AdlTrade</c>"] Adl trade
        /// </summary>
        [Map("AdlTrade")]
        AdlTrade,
        /// <summary>
        /// ["<c>Funding</c>"] Funding trade
        /// </summary>
        [Map("Funding")]
        Funding,
        /// <summary>
        /// ["<c>BustTrade</c>"] Bankruptcy trade
        /// </summary>
        [Map("BustTrade")]
        BustTrade,
        /// <summary>
        /// ["<c>Settle</c>"] Settle
        /// </summary>
        [Map("Settle")]
        Settle,
        /// <summary>
        /// ["<c>Delivery</c>"] Delivery
        /// </summary>
        [Map("Delivery")]
        Delivery,
        /// <summary>
        /// ["<c>BlockTrade</c>"] Block trade
        /// </summary>
        [Map("BlockTrade")]
        BlockTrade,
        /// <summary>
        /// ["<c>MovePosition</c>"] Move position
        /// </summary>
        [Map("MovePosition")]
        MovePosition,
        /// <summary>
        /// ["<c>FutureSpread</c>"] Spread trade
        /// </summary>
        [Map("FutureSpread")]
        FutureSpread,
        /// <summary>
        /// ["<c>CorporateAction</c>"] Stock split or reverse stock split
        /// </summary>
        [Map("CorporateAction")]
        CorporateAction
    }
}
