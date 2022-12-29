using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Trade info
    /// </summary>
    public class BybitDerivativesTrade
    {
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("execId")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Trade price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Order quantity in USD
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Side of the trade
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Timestamp of the trade
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Time { get; set; }

        /// <summary>
        /// The batch id from paradigm. It is null if normal trade.
        /// </summary>
        public bool IsBlockTrade { get; set; }
    }
}
