using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Enums.V5;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Request info
    /// </summary>
    public class BybitPlaceOrderRequest
    {
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Type of order
        /// </summary>
        [JsonProperty("orderType"), JsonConverter(typeof(EnumConverter))]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Side of the order
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(EnumConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("qty"), JsonConverter(typeof(DecimalToStringConverter))]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Price if order type is not market
        /// </summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
        public decimal? Price { get; set; }
        /// <summary>
        /// Time in force, if not passed GoodTillCanceled is used by default
        /// </summary>
        [JsonProperty("timeInForce", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(EnumConverter))]
        public TimeInForce? TimeInForce { get; set; }
        /// <summary>
        /// Client order id. Required for Options
        /// </summary>
        [JsonProperty("orderLinkId", NullValueHandling = NullValueHandling.Ignore)]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Set to true so your position can only reduce in size if this order is triggered.
        /// </summary>
        [JsonProperty("reduceOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReduceOnly { get; set; }
        /// <summary>
        /// Take profit / stop loss mode
        /// </summary>
        [JsonProperty("tpslMode", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(EnumConverter))]
        public StopLossTakeProfitMode? TakeProfitStopLossMode { get; set; }
        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonProperty("takeProfit", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonProperty("stopLoss", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// Trigger direction
        /// </summary>
        [JsonProperty("triggerDirection", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(EnumConverter), new object[] { true, true })]
        public TriggerDirection? TriggerDirection { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonProperty("triggerPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// Trigger price type
        /// </summary>
        [JsonProperty("triggerBy", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(EnumConverter))]
        public TriggerType? TriggerBy { get; set; }
        /// <summary>
        /// Position idx
        /// </summary>
        [JsonProperty("positionIdx", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(EnumConverter), new object[] { true, true })]
        public PositionIdx? PositionIdx { get; set; }
        /// <summary>
        /// Take profit limit price
        /// </summary>
        [JsonProperty("tpLimitPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
        public decimal? TakeProfitLimitPrice { get; set; }
        /// <summary>
        /// Stop loss limit price
        /// </summary>
        [JsonProperty("slLimitPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
        public decimal? StopLossLimitPrice { get; set; }
        /// <summary>
        /// Stop loss order type
        /// </summary>
        [JsonProperty("slOrderType", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(EnumConverter))]
        public OrderType? StopLossOrderType { get; set; }
        /// <summary>
        /// Take profit order type
        /// </summary>
        [JsonProperty("tpOrderType", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(EnumConverter))]
        public OrderType? TakeProfitOrderType { get; set; }
        /// <summary>
        /// Market maker protection. option only. true means set the order as a market maker protection order
        /// </summary>
        [JsonProperty("mmp", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MarketMakerProtection { get; set; }
        /// <summary>
        /// Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed. orderIv has a higher priority when price is passed as well
        /// </summary>
        [JsonProperty("orderIv", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
        public decimal? OrderImpliedVolatility { get; set; }
        /// <summary>
        /// The unit for qty when creating spot market orders for unified trading account
        /// </summary>
        [JsonProperty("marketUnit", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(EnumConverter))]
        public MarketUnit? MarketUnit { get; set; }
    }
}
