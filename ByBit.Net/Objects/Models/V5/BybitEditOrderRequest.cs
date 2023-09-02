using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Request info
    /// </summary>
    public class BybitEditOrderRequest
    {
        /// <summary>
        /// Edit by order id
        /// </summary>
        [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
        public string? OrderId { get; set; }
        /// <summary>
        /// Edit by client order id
        /// </summary>
        [JsonProperty("orderLinkId", NullValueHandling = NullValueHandling.Ignore)]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Price if order type is not market
        /// </summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Price { get; set; }
        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonProperty("takeProfit", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonProperty("stopLoss", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonProperty("triggerPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// Trigger price type
        /// </summary>
        [JsonProperty("triggerBy", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(EnumConverter))]
        public TriggerType? TriggerBy { get; set; }
        /// <summary>
        /// Take profit limit price
        /// </summary>
        [JsonProperty("tpLimitPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TakeProfitLimitPrice { get; set; }
        /// <summary>
        /// Stop loss limit price
        /// </summary>
        [JsonProperty("slLimitPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? StopLossLimitPrice { get; set; }
        /// <summary>
        /// Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed. orderIv has a higher priority when price is passed as well
        /// </summary>
        [JsonProperty("orderIv", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? OrderImpliedVolatility { get; set; }
    }
}
