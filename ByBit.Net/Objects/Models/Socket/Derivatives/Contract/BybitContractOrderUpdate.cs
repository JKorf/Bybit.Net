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
    }
}
