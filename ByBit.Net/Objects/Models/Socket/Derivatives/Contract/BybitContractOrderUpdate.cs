using Bybit.Net.Objects.Models.Contract;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket.Derivatives.Contract
{
    /// <summary>
    /// Order info
    /// </summary>
    public class BybitContractOrderUpdate : BybitContractOrder
    {
        /// <summary>
        /// Quantity to close
        /// </summary>
        public decimal ClosedSize { get; set; }

        /// <summary>
        /// Time of trade (unit: ms)
        /// </summary>
        [JsonProperty("execTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? TradeTime { get; set; }

        /// <summary>
        /// Filled price
        /// </summary>
        [JsonProperty("lastExecPrice")]
        public decimal? FilledPrice { get; set; }

        /// <summary>
        /// When the order is filled or partially filled, it is filled qty. When the order is canceled, it is unfilled qty.
        /// </summary>
        [JsonProperty("lastExecQty")]
        public decimal? FilledQuantity { get; set; }
    }
}
