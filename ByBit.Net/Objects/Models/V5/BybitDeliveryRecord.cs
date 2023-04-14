using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Delivery record
    /// </summary>
    public class BybitDeliveryRecord
    {
        /// <summary>
        /// Delivery time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DeliveryTime { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Executed quantity
        /// </summary>
        public decimal Position { get; set; }
        /// <summary>
        /// Delivery price
        /// </summary>
        public decimal DeliveryPrice { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public decimal Strike { get; set; }
        /// <summary>
        /// Fee
        /// </summary>
        public decimal Fee { get; set; }
        /// <summary>
        /// Realized profit and loss
        /// </summary>
        public decimal RealizedPnl { get; set; }
    }
}
