using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Symbol info
    /// </summary>
    public class BybitDerivativesSymbol
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Contract type
        /// </summary>
        public ContractType ContractType { get; set; }

        /// <summary>
        /// Symbol status
        /// </summary>
        [JsonConverter(typeof(SymbolStatusConverter))]
        public SymbolStatus Status { get; set; }

        /// <summary>
        /// Base currency of the symbol
        /// </summary>
        [JsonProperty("baseCoin")]
        public string BaseCurrency { get; set; } = string.Empty;

        /// <summary>
        /// Quote currency of the symbol
        /// </summary>
        [JsonProperty("quoteCoin")]
        public string QuoteCurrency { get; set; } = string.Empty;

        /// <summary>
        /// Settle coin. Like BTC. Option only
        /// </summary>
        [JsonProperty("settleCoin")]
        public string SettleCurrency { get; set; } = string.Empty;

        /// <summary>
        /// Call/Put Trading type of option
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public OptionType OptionsType { get; set; }

        /// <summary>
        /// Launch time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LaunchTime { get; set; }

        /// <summary>
        /// Expired date/Delivery time/Exercise time. For perpetual, returns "0"
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DeliveryTime { get; set; }

        /// <summary>
        /// Delivery fee rate
        /// </summary>
        public decimal? DeliveryFeeRate { get; set; }

        /// <summary>
        /// Funding interval
        /// </summary>
        public decimal? FundingInterval { get; set; }

        /// <summary>
        /// Price precision (amount of decimals)
        /// </summary>
        [JsonProperty("priceScale")]
        public int PricePrecision { get; set; }

        /// <summary>
        /// Min. order quantity increment
        /// </summary>
        [JsonProperty("unifiedMarginTrade")]
        public bool MinQuantityIncrement { get; set; }

        /// <summary>
        /// Leverage filter
        /// </summary>
        public BybitUnifiedMarginLeverageFilter LeverageFilter { get; set; } = default!;
        /// <summary>
        /// Price filter
        /// </summary>
        public BybitUnifiedMarginPriceFilter PriceFilter { get; set; } = default!;
        /// <summary>
        /// Lot size filter
        /// </summary>
        public BybitUnifiedMarginLotSizeFilter LotSizeFilter { get; set; } = default!;
    }

    /// <summary>
    /// Leverage rules
    /// </summary>
    public class BybitUnifiedMarginLeverageFilter
    {
        /// <summary>
        /// Minimal leverage
        /// </summary>
        public decimal MinLeverage { get; set; }
        /// <summary>
        /// Maximum leverage
        /// </summary>
        public decimal MaxLeverage { get; set; }
        /// <summary>
        /// Leverage step
        /// </summary>
        public decimal LeverageStep { get; set; }
    }

    /// <summary>
    /// Price rules
    /// </summary>
    public class BybitUnifiedMarginPriceFilter
    {
        /// <summary>
        /// Minimal price
        /// </summary>
        public decimal MinPrice { get; set; }
        /// <summary>
        /// Maximum price
        /// </summary>
        public decimal MaxPrice { get; set; }
        /// <summary>
        /// Tick size
        /// </summary>
        public decimal TickSize { get; set; }
    }

    /// <summary>
    /// Lot size rules
    /// </summary>
    public class BybitUnifiedMarginLotSizeFilter
    {
        /// <summary>
        /// Minimal quantity
        /// </summary>
        [JsonProperty("minTradingQty")]
        public decimal MinQuantity { get; set; }
        /// <summary>
        /// Maximum quantity
        /// </summary>
        [JsonProperty("maxTradingQty")]
        public decimal MaxQuantity { get; set; }
        /// <summary>
        /// Quantity step
        /// </summary>
        [JsonProperty("qtyStep")]
        public decimal QuantityStep { get; set; }
        /// <summary>
        /// postOnlyMaxOrderQty
        /// </summary>
        /// <remarks> Not described in API docs </remarks>
        [JsonProperty("postOnlyMaxOrderQty")]
        public decimal MaxOrderQuantity { get; set; }
    }
}
