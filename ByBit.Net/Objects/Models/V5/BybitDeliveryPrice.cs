using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Delivery price info
    /// </summary>
    public class BybitDeliveryPrice
    {
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
