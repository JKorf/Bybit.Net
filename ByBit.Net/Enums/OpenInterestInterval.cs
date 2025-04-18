using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Open interest interval, int value represents the time in seconds
    /// </summary>
    [JsonConverter(typeof(EnumConverter<OpenInterestInterval>))]
    public enum OpenInterestInterval
    {
        /// <summary>
        /// 5
        /// </summary>
        [Map("5min")]
        FiveMinutes = 60 * 5,
        /// <summary>
        /// 15
        /// </summary>
        [Map("15min")]
        FifteenMinutes = 60 * 15,
        /// <summary>
        /// 30
        /// </summary>
        [Map("30min")]
        ThirtyMinutes = 60 * 30,
        /// <summary>
        /// 60
        /// </summary>
        [Map("1h")]
        OneHour = 60 * 60,
        /// <summary>
        /// 240
        /// </summary>
        [Map("4h")]
        FourHours = 60 * 60 * 4,
        /// <summary>
        /// D
        /// </summary>
        [Map("1d")]
        OneDay = 60 * 60 * 24
    }
}
