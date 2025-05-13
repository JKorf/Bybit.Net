using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Margin item
    /// </summary>
    [SerializationModel]
    public record BybitSpotMarginBorrowRate
    {
        /// <summary>
        /// The asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Vip level
        /// </summary>
        [JsonPropertyName("vipLevel")]
        public string VipLevel { get; set; } = string.Empty;
        /// <summary>
        /// Collateral ratio
        /// </summary>
        [JsonPropertyName("hourlyBorrowRate")]
        public decimal HourlyBorrowRate { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("timestamp"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
