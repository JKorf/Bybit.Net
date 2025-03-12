using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Time in force
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TimeInForce>))]
    public enum TimeInForce
    {
        /// <summary>
        /// Good till canceled by user
        /// </summary>
        [Map("GTC")]
        GoodTillCanceled,
        /// <summary>
        /// Fill at least partially upon placing or cancel
        /// </summary>
        [Map("IOC")]
        ImmediateOrCancel,
        /// <summary>
        /// Fill fully upon placing or cancel
        /// </summary>
        [Map("FOK")]
        FillOrKill,
        /// <summary>
        /// Only place order if the order is added to the order book instead of being filled immediately
        /// </summary>
        [Map("PostOnly")]
        PostOnly,
        /// <summary>
        /// Retail Price Improvement orders act as PostOnly orders but also do cannot match with algorithmic (API) orders. See https://www.bybit.nl/nl-NL/help-center/article/Retail-Price-Improvement-RPI-Order
        /// </summary>
        [Map("RPI")]
        RetailPriceImprovement
    }
}
