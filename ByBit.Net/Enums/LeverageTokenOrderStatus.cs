using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Leverage token purchase status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<LeverageTokenOrderStatus>))]
    public enum LeverageTokenOrderStatus
    {
        /// <summary>
        /// Completed
        /// </summary>
        [Map("1")]
        Completed,
        /// <summary>
        /// In progress
        /// </summary>
        [Map("2")]
        InProgress,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("3")]
        Failed,
    }
}
