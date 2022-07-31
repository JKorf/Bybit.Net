using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.CopyTrading
{
    /// <summary>
    /// Copy trade update
    /// </summary>
    public class BybitCopyTradingUserTradeUpdate
    {
        /// <summary>
        /// Order id
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Side
        /// </summary>
        public OrderSide Side { get; set; }
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("execId")]
        public string TransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Executed quantity
        /// </summary>
        [JsonProperty("execQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade type
        /// </summary>
        [JsonProperty("execType")]
        public TradeType TradeType { get; set; }
        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonProperty("execFee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Trade price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("orderQty")]
        public decimal OrderQuantity { get; set; }
        /// <summary>
        /// Trade time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime TradeTime { get; set; }
    }
}
