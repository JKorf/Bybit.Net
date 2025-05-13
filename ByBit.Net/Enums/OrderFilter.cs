using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Order filter
    /// </summary>
    [JsonConverter(typeof(EnumConverter<OrderFilter>))]
    public enum OrderFilter
    {
        /// <summary>
        /// Active order
        /// </summary>
        [Map("Order")]
        Order,
        /// <summary>
        /// Conditional order
        /// </summary>
        [Map("StopOrder")]
        StopOrder,
        /// <summary>
        /// Spot TakeProfit/StopLoss order
        /// </summary>
        [Map("tpslOrder")]
        TpSlOrder,
        /// <summary>
        /// Oco order
        /// </summary>
        [Map("OcoOrder")]
        OcoOrder,
        /// <summary>
        /// Bidirectional TakeProfit/StopLoss order
        /// </summary>
        [Map("BidirectionalTpslOrder")]
        BidirectionalTpslOrder
    }
}
