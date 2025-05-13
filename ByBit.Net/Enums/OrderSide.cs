using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Side of an order
    /// </summary>
    [JsonConverter(typeof(EnumConverter<OrderSide>))]
    public enum OrderSide
    {
        /// <summary>
        /// Buy
        /// </summary>
        [Map("Buy", "BUY")]
        Buy,
        /// <summary>
        /// Sell
        /// </summary>
        [Map("Sell", "SELL")]
        Sell
    }
}
