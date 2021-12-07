using CryptoExchange.Net.Converters;
using CryptoExchange.Net.ExchangeInterfaces;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Spot trade info
    /// </summary>
    public class BybitSpotTrade: ICommonRecentTrade
    {
        /// <summary>
        /// Trade price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Timestamp of the trade
        /// </summary>
        [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime TradeTime { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Is the buyer the maker
        /// </summary>
        public bool IsBuyerMaker { get; set; }

        decimal ICommonRecentTrade.CommonPrice => Price;

        decimal ICommonRecentTrade.CommonQuantity => Quantity;

        DateTime ICommonRecentTrade.CommonTradeTime => TradeTime;
    }
}
