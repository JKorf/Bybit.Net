using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Request info
    /// </summary>
    [SerializationModel]
    public record BybitPlaceOrderRequest
    {
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Type of order
        /// </summary>
        [JsonPropertyName("orderType")]
        public NewOrderType OrderType { get; set; }
        /// <summary>
        /// Side of the order
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonPropertyName("qty"), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Price if order type is not market
        /// </summary>
        [JsonPropertyName("price"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? Price { get; set; }
        /// <summary>
        /// Time in force, if not passed GoodTillCanceled is used by default
        /// </summary>
        [JsonPropertyName("timeInForce"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TimeInForce? TimeInForce { get; set; }
        /// <summary>
        /// Client order id. Required for Options
        /// </summary>
        [JsonPropertyName("orderLinkId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Set to true so your position can only reduce in size if this order is triggered.
        /// </summary>
        [JsonPropertyName("reduceOnly"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ReduceOnly { get; set; }
        /// <summary>
        /// Take profit / stop loss mode
        /// </summary>
        [JsonPropertyName("tpslMode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public StopLossTakeProfitMode? TakeProfitStopLossMode { get; set; }
        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonPropertyName("takeProfit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? TakeProfit { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonPropertyName("stopLoss"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? StopLoss { get; set; }
        /// <summary>
        /// Trigger direction
        /// </summary>
        [JsonPropertyName("triggerDirection"),
            JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault),
            JsonConverter(typeof(EnumIntWriterConverter<TriggerDirection>))]
        public TriggerDirection? TriggerDirection { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonPropertyName("triggerPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// Trigger price type
        /// </summary>
        [JsonPropertyName("triggerBy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TriggerType? TriggerBy { get; set; }
        /// <summary>
        /// Position idx
        /// </summary>
        [JsonPropertyName("positionIdx"),
            JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault),
            JsonConverter(typeof(EnumIntWriterConverter<PositionIdx>))]
        public PositionIdx? PositionIdx { get; set; }
        /// <summary>
        /// Take profit limit price
        /// </summary>
        [JsonPropertyName("tpLimitPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? TakeProfitLimitPrice { get; set; }
        /// <summary>
        /// Stop loss limit price
        /// </summary>
        [JsonPropertyName("slLimitPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? StopLossLimitPrice { get; set; }
        /// <summary>
        /// Stop loss order type
        /// </summary>
        [JsonPropertyName("slOrderType"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public OrderType? StopLossOrderType { get; set; }
        /// <summary>
        /// Take profit order type
        /// </summary>
        [JsonPropertyName("tpOrderType"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public OrderType? TakeProfitOrderType { get; set; }
        /// <summary>
        /// Market maker protection. option only. true means set the order as a market maker protection order
        /// </summary>
        [JsonPropertyName("mmp"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? MarketMakerProtection { get; set; }
        /// <summary>
        /// Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed. orderIv has a higher priority when price is passed as well
        /// </summary>
        [JsonPropertyName("orderIv"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? OrderImpliedVolatility { get; set; }
        /// <summary>
        /// The unit for qty when creating spot market orders for unified trading account
        /// </summary>
        [JsonPropertyName("marketUnit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MarketUnit? MarketUnit { get; set; }
        /// <summary>
        /// Close on trigger, can only reduce the position
        /// </summary>
        [JsonPropertyName("closeOnTrigger"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? CloseOnTrigger { get; set; }
        /// <summary>
        /// Self match prevention type
        /// </summary>
        [JsonPropertyName("smpType"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SelfMatchPreventionType? StpType { get; set; }
        /// <summary>
        /// Stop loss trigger by
        /// </summary>
        [JsonPropertyName("slTriggerBy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TriggerType? StopLossTriggerBy { get; set; }
        /// <summary>
        /// Take profit trigger by
        /// </summary>
        [JsonPropertyName("tpTriggerBy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TriggerType? TakeProfitTriggerBy { get; set; }
        /// <summary>
        /// Order filter
        /// </summary>
        [JsonPropertyName("orderFilter"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public OrderFilter? OrderFilter { get; set; }
        /// <summary>
        /// Whether to borrow. Valid for Unified spot only. 1 for true
        /// </summary>
        [JsonPropertyName("isLeverage"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? IsLeverage { get; set; }
    }

    [SerializationModel]
    internal record BybitSocketPlaceOrderRequest : BybitPlaceOrderRequest
    {
        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
