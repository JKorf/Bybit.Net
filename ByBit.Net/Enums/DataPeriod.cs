using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Period
    /// </summary>
    [JsonConverter(typeof(EnumConverter<DataPeriod>))]
    public enum DataPeriod
    {
        /// <summary>
        /// 5min
        /// </summary>
        [Map("5min")]
        FiveMinutes,
        /// <summary>
        /// 15min
        /// </summary>
        [Map("15min")]
        FifteenMinutes,
        /// <summary>
        /// 30min
        /// </summary>
        [Map("30min")]
        ThirtyMinutes,
        /// <summary>
        /// 1h
        /// </summary>
        [Map("1h")]
        OneHour,
        /// <summary>
        /// 4h
        /// </summary>
        [Map("4h")]
        FourHours,
        /// <summary>
        /// 1d
        /// </summary>
        [Map("1d")]
        OneDay
    }
}
