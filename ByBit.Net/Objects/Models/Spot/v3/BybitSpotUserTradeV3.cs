using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// User trade info
    /// </summary>
    public class BybitSpotUserTradeV3
    {
        /// <summary>
        /// Transaction id
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("tradeId")]
        public long TradeId { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("matchOrderId")]
        public long MatchOrderId { get; set; }
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonProperty("orderPrice")]
        public decimal Price { get; set; }
        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonProperty("orderQty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Fee
        /// </summary>
        [JsonProperty("execFee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonProperty("feeTokenId")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("creatTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Trade time
        /// </summary>
        [JsonProperty("executionTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime TradeTime { get; set; }
        /// <summary>
        /// Is buyer
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("isBuyer")]
        public bool IsBuyer { get; set; }
        /// <summary>
        /// Is maker
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonProperty("isMaker")]
        public bool IsMaker { get; set; }
        /// <summary>
        /// Maker rebate
        /// </summary>
        [JsonProperty("makerRebate")]
        public decimal MakerRebate { get; set; }
        /// <summary>
        /// Block trade id
        /// </summary>
        public string? BlockTradeId { get; set; } = string.Empty;
    }
}
