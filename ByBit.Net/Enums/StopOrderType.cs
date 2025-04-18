using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Stop order type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<StopOrderType>))]
    public enum StopOrderType
    {
        /// <summary>
        /// Take profit
        /// </summary>
        [Map("TakeProfit")]
        TakeProfit,
        /// <summary>
        /// Stop loss
        /// </summary>
        [Map("StopLoss")]
        StopLoss,
        /// <summary>
        /// Trailing stop
        /// </summary>
        [Map("TrailingStop")]
        TrailingStop,
        /// <summary>
        /// Trailing profit
        /// </summary>
        [Map("TrailingProfit")]
        TrailingProfit,
        /// <summary>
        /// Stop
        /// </summary>
        [Map("Stop")]
        Stop,
        /// <summary>
        /// Partial stop loss
        /// </summary>
        [Map("PartialStopLoss")]
        PartialStopLoss,
        /// <summary>
        /// Partial stop loss
        /// </summary>
        [Map("PartialTakeProfit")]
        PartialTakeProfit,
        /// <summary>
        /// Spot TP/SL order
        /// </summary>
        [Map("tpslOrder")]
        TpSlOrder,
        /// <summary>
        /// Oco Order
        /// </summary>
        [Map("OcoOrder")]
        OcoOrder,
        /// <summary>
        /// MmRateClose (only from web)
        /// </summary>
        [Map("MmRateClose")]
        MmRateClose,
        /// <summary>
        /// Spot bidirectional tpsl order
        /// </summary>
        [Map("BidirectionalTpslOrder")]
        BidirectionalTpslOrder,
        /// <summary>
        /// Unknown type
        /// </summary>
        [Map("Unknown")]
        Unknown
    }
}
