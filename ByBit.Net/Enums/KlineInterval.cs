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
        OneMinute = 60,
        /// <summary>
        /// 3
        /// </summary>
        ThreeMinutes = 60 * 3,
        /// <summary>
        /// 5
        /// </summary>
        FiveMinutes = 60 * 5,
        /// <summary>
        /// 15
        /// </summary>
        FifteenMinutes = 60 * 15,
        /// <summary>
        /// 30
        /// </summary>
        ThirtyMinutes = 60 * 30,
        /// <summary>
        /// 60
        /// </summary>
        OneHour = 60 * 60,
        /// <summary>
        /// 120
        /// </summary>
        TwoHours = 60 * 60 * 2,
        /// <summary>
        /// 240
        /// </summary>
        FourHours = 60 * 60 * 4,
        /// <summary>
        /// 360
        /// </summary>
        SixHours = 60 * 60 * 6,
        /// <summary>
        /// 720
        /// </summary>
        TwelveHours = 60 * 60 * 12,
        /// <summary>
        /// D
        /// </summary>
        OneDay = 60 * 60 * 24,
        /// <summary>
        /// W
        /// </summary>
        OneWeek = 60 * 60 * 24 * 7,
        /// <summary>
        /// M
        /// </summary>
        OneMonth = 60 * 60 * 24 * 30
    }
}
