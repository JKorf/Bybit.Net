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
    /// Maintenance types
    /// </summary>
    [JsonConverter(typeof(EnumConverter<MaintenanceType>))]
    public enum MaintenanceType
    {
        /// <summary>
        /// Planned maintenance
        /// </summary>
        [Map("1")]
        PlannedMaintenance,
        /// <summary>
        /// Temporary maintenance
        /// </summary>
        [Map("2")]
        TemporaryMaintenance,
        /// <summary>
        /// Incident
        /// </summary>
        [Map("3")]
        Incident
    }
}
