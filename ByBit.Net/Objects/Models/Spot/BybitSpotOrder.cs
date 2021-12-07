using CryptoExchange.Net.Converters;
using CryptoExchange.Net.ExchangeInterfaces;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Spot order info
    /// </summary>
    public class BybitSpotOrder: BybitSpotOrderBase, ICommonOrder
    {        
        /// <summary>
        /// Exchange id
        /// </summary>
        public long ExchangeId { get; set; }
        /// <summary>
        /// Quantity executed
        /// </summary>
        [JsonProperty("executedQty")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Quote quantity
        /// </summary>
        [JsonProperty("cummulativeQuoteQty")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// Average execution price
        /// </summary>
        [JsonProperty("avgPrice")]
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// Stop price
        /// </summary>
        public decimal? StopPrice { get; set; }
        /// <summary>
        /// Ice berg quantity
        /// </summary>
        [JsonProperty("icebergQty")]
        public decimal? IcebergQuantity { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("time")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("updateTime")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Is working
        /// </summary>
        public bool IsWorking { get; set; }

        string ICommonOrder.CommonSymbol => Symbol;

        decimal ICommonOrder.CommonPrice => Price;

        decimal ICommonOrder.CommonQuantity => Quantity;

        IExchangeClient.OrderStatus ICommonOrder.CommonStatus =>
            Status == Enums.OrderStatus.Canceled || Status == Enums.OrderStatus.PendingCancel ? IExchangeClient.OrderStatus.Canceled :
            Status == Enums.OrderStatus.Filled ? IExchangeClient.OrderStatus.Filled :
            IExchangeClient.OrderStatus.Active;

        bool ICommonOrder.IsActive => Status == Enums.OrderStatus.Canceled || Status == Enums.OrderStatus.PendingCancel || Status == Enums.OrderStatus.Filled ? false : true;

        IExchangeClient.OrderSide ICommonOrder.CommonSide => Side == Enums.OrderSide.Buy ? IExchangeClient.OrderSide.Buy : IExchangeClient.OrderSide.Sell;

        IExchangeClient.OrderType ICommonOrder.CommonType => Type == Enums.OrderType.Limit ? IExchangeClient.OrderType.Limit :
                                                             Type == Enums.OrderType.Market ? IExchangeClient.OrderType.Market :
                                                             IExchangeClient.OrderType.Other;

        DateTime ICommonOrder.CommonOrderTime => CreateTime;

        string ICommonOrderId.CommonId => Id.ToString();
    }
}
