using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Kline interval
    /// </summary>
    public enum KlineInterval
    {
        /// <summary>
        /// 1
        /// </summary>
        OneMinute,
        /// <summary>
        /// 3
        /// </summary>
        ThreeMinutes,
        /// <summary>
        /// 5
        /// </summary>
        FiveMinutes,
        /// <summary>
        /// 15
        /// </summary>
        FifteenMinutes,
        /// <summary>
        /// 30
        /// </summary>
        ThirtyMinutes,
        /// <summary>
        /// 60
        /// </summary>
        OneHour,
        /// <summary>
        /// 120
        /// </summary>
        TwoHours,
        /// <summary>
        /// 240
        /// </summary>
        FourHours,
        /// <summary>
        /// 360
        /// </summary>
        SixHours,
        /// <summary>
        /// 720
        /// </summary>
        TwelveHours,
        /// <summary>
        /// D
        /// </summary>
        OneDay,
        /// <summary>
        /// W
        /// </summary>
        OneWeek,
        /// <summary>
        /// M
        /// </summary>
        OneMonth
    }
}
