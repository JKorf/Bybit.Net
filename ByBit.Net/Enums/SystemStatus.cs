using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
