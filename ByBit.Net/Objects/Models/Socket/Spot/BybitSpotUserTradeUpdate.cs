using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket.Spot
{
    /// <summary>
    /// Spot order update
    /// </summary>
    public class BybitSpotUserTradeUpdate : BybitSocketEvent
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("q")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade time
        /// </summary>
        [JsonProperty("t"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime TradeTime { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("p")]
        public decimal Price { get; set; }
        /// <summary>
        /// Transaction id
        /// </summary>
        [JsonProperty("T")]
        public long TransactionId { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("o")]
        public long OrderId { get; set; }
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("c")]
        public string ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Matching order id
        /// </summary>
        [JsonProperty("O")]
        public long MatchOrderId { get; set; }
        /// <summary>
        /// Account id
        /// </summary>
        [JsonProperty("a")]
        public long AccountId { get; set; }
        /// <summary>
        /// Matching account id
        /// </summary>
        [JsonProperty("A")]
        public long MatchAccountId { get; set; }
        /// <summary>
        /// Is maker
        /// </summary>
        [JsonProperty("m")]
        public bool Maker { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        [JsonProperty("S")]
        public OrderSide Side { get; set; }
    }
}
