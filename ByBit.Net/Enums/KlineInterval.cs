using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Kline interval, int value represents the time in seconds
    /// </summary>
    [JsonConverter(typeof(EnumConverter<KlineInterval>))]
    public enum KlineInterval
    {
        /// <summary>
        /// 1
        /// </summary>
        [Map("1", "1m")]
        OneMinute = 60,
        /// <summary>
        /// 3
        /// </summary>
        [Map("3", "3m")]
        ThreeMinutes = 60 * 3,
        /// <summary>
        /// 5
        /// </summary>
        [Map("5", "5m")]
        FiveMinutes = 60 * 5,
        /// <summary>
        /// 15
        /// </summary>
        [Map("15", "15m")]
        FifteenMinutes = 60 * 15,
        /// <summary>
        /// 30
        /// </summary>
        [Map("30", "30m")]
        ThirtyMinutes = 60 * 30,
        /// <summary>
        /// 60
        /// </summary>
        [Map("60", "1h")]
        OneHour = 60 * 60,
        /// <summary>
        /// 120
        /// </summary>
        [Map("120", "2h")]
        TwoHours = 60 * 60 * 2,
        /// <summary>
        /// 240
        /// </summary>
        [Map("240", "4h")]
        FourHours = 60 * 60 * 4,
        /// <summary>
        /// 360
        /// </summary>
        [Map("360", "6h")]
        SixHours = 60 * 60 * 6,
        /// <summary>
        /// 720
        /// </summary>
        [Map("720", "12h")]
        TwelveHours = 60 * 60 * 12,
        /// <summary>
        /// D
        /// </summary>
        [Map("D", "1d")]
        OneDay = 60 * 60 * 24,
        /// <summary>
        /// W
        /// </summary>
        [Map("W", "1w")]
        OneWeek = 60 * 60 * 24 * 7,
        /// <summary>
        /// M
        /// </summary>
        [Map("M", "1M")]
        OneMonth = 60 * 60 * 24 * 30
    }
}
