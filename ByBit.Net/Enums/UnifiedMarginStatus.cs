using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Unified margin status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<UnifiedMarginStatus>))]
    public enum UnifiedMarginStatus
    {
        /// <summary>
        /// Regular account
        /// </summary>
        [Map("1")]
        Regular,
        /// <summary>
        /// Unified margin account, can only trade linear perpetual and options.
        /// </summary>
        [Map("2")]
        UnifiedMarginAccount,
        /// <summary>
        /// Unified trade account, can trade linear perpetual, options and spot
        /// </summary>
        [Map("3")]
        UnifiedTradeAccount,
        /// <summary>
        /// Unified trade account pro, can trade bulk order api endpoints
        /// </summary>
        [Map("4")]
        UnifiedTradeAccountPro,
        /// <summary>
        /// Unified trade account 2.0 pro, can trade bulk order api endpoints
        /// </summary>
        [Map("5")]
        UnifiedTradeAccount2,
        /// <summary>
        /// Unified trade account 2.0 pro, can trade bulk order api endpoints
        /// </summary>
        [Map("6")]
        UnifiedTradeAccount2Pro
    }
}
