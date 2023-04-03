using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Kline interval, int value represents the time in seconds
    /// </summary>
    public enum KlineInterval
    {
        /// <summary>
        /// 1
        /// </summary>
        [Map("1")]
        OneMinute = 60,
        /// <summary>
        /// 3
        /// </summary>
        [Map("3")]
        ThreeMinutes = 60 * 3,
        /// <summary>
        /// 5
        /// </summary>
        [Map("5")]
        FiveMinutes = 60 * 5,
        /// <summary>
        /// 15
        /// </summary>
        [Map("15")]
        FifteenMinutes = 60 * 15,
        /// <summary>
        /// 30
        /// </summary>
        [Map("30")]
        ThirtyMinutes = 60 * 30,
        /// <summary>
        /// 60
        /// </summary>
        [Map("60")]
        OneHour = 60 * 60,
        /// <summary>
        /// 120
        /// </summary>
        [Map("120")]
        TwoHours = 60 * 60 * 2,
        /// <summary>
        /// 240
        /// </summary>
        [Map("240")]
        FourHours = 60 * 60 * 4,
        /// <summary>
        /// 360
        /// </summary>
        [Map("360")]
        SixHours = 60 * 60 * 6,
        /// <summary>
        /// 720
        /// </summary>
        [Map("720")]
        TwelveHours = 60 * 60 * 12,
        /// <summary>
        /// D
        /// </summary>
        [Map("D")]
        OneDay = 60 * 60 * 24,
        /// <summary>
        /// W
        /// </summary>
        [Map("W")]
        OneWeek = 60 * 60 * 24 * 7,
        /// <summary>
        /// M
        /// </summary>
        [Map("M")]
        OneMonth = 60 * 60 * 24 * 30
    }
}
