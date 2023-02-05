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
        /// Trade id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Symbol name
        /// </summary>
        public string SymbolName { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        public long OrderId { get; set; }
        /// <summary>
        /// Matching order id
        /// </summary>
        public long MatchOrderId { get; set; }
        /// <summary>
        /// Trade price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Fee
        /// </summary>
        [JsonProperty("commission")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonProperty("commissionAsset")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Trade time
        /// </summary>
        [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime TradeTime { get; set; }
        /// <summary>
        /// Is buyer
        /// </summary>
        public bool IsBuyer { get; set; }
        [JsonProperty("isBuyer")]
        private int isBuyer { get => IsBuyer ? 1 : 0; set => IsBuyer = value == 1; }
        /// <summary>
        /// Is maker
        /// </summary>
        public bool IsMaker { get; set; }
        [JsonProperty("isMaker")]
        private int isMaker { get => IsMaker ? 1 : 0; set => IsMaker = value == 1; }
        /// <summary>
        /// Fee details
        /// </summary>
        [JsonProperty("fee")]
        public BybitTradeFee FeeDetails { get; set; } = default!;
        /// <summary>
        /// Fee otken id
        /// </summary>
        public string FeeTokenId { get; set; } = string.Empty;
        /// <summary>
        /// Trading fee
        /// </summary>
        public decimal FeeAmount { get; set; }
        /// <summary>
        /// Maker rebate
        /// </summary>
        public decimal MakerRebate { get; set; }
    }
}
