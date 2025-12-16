using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

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
