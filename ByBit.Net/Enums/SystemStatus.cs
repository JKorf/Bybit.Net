using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// System status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SystemStatus>))]
    public enum SystemStatus
    {
        /// <summary>
        /// Scheduled
        /// </summary>
        [Map("scheduled")]
        Scheduled,
        /// <summary>
        /// Ongoing
        /// </summary>
        [Map("ongoing")]
        Ongoing,
        /// <summary>
        /// Completed
        /// </summary>
        [Map("completed")]
        Completed,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("canceled")]
        Canceled
    }
}
