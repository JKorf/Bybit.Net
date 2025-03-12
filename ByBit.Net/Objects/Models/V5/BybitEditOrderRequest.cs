using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Request info
    /// </summary>
    [SerializationModel]
    public record BybitEditOrderRequest
    {
        /// <summary>
        /// Edit by order id
        /// </summary>
        [JsonPropertyName("orderId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? OrderId { get; set; }
        /// <summary>
        /// Edit by client order id
        /// </summary>
        [JsonPropertyName("orderLinkId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// The symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// New order quantity
        /// </summary>
        [JsonPropertyName("qty"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Price if order type is not market
        /// </summary>
        [JsonPropertyName("price"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? Price { get; set; }
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
        /// Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed. orderIv has a higher priority when price is passed as well
        /// </summary>
        [JsonPropertyName("orderIv"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? OrderImpliedVolatility { get; set; }
        /// <summary>
        /// Take profit/Stop loss mode
        /// </summary>
        [JsonPropertyName("tpslMode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public StopLossTakeProfitMode? TakeProfitStopLossMode { get; set; }
        /// <summary>
        /// Stop Loss Trigger price type
        /// </summary>
        [JsonPropertyName("slTriggerBy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TriggerType? StopLossTriggerBy { get; set; }
        /// <summary>
        /// Take Profit Trigger price type
        /// </summary>
        [JsonPropertyName("tpTriggerBy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TriggerType? TakeProfitTriggerBy { get; set; }
    }

    [SerializationModel]
    internal record BybitSocketEditOrderRequest : BybitEditOrderRequest
    {
        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
