using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Get option delivery price
    /// </summary>
    public class BybitDerivativesOptionDeliveryPrice
    {
        /// <summary>
        /// Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public Category Category { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Delivery price
        /// </summary>
        public decimal DeliveryPrice { get; set; }
        /// <summary>
        /// Delivery time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DeliveryTime { get; set; }
    }
}
