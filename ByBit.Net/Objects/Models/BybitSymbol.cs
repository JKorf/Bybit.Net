using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Symbol info
    /// </summary>
    public class BybitSymbol
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Alias
        /// </summary>
        public string Alias { get; set; } = string.Empty;
        /// <summary>
        /// Symbol status
        /// </summary>
        [JsonConverter(typeof(SymbolStatusConverter))]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// Base currency of the symbol
        /// </summary>
        [JsonProperty("base_currency")]
        public string BaseCurrency { get; set; } = string.Empty;
        /// <summary>
        /// Quote currency of the symbol
        /// </summary>
        [JsonProperty("quote_currency")]
        public string QuoteCurrency { get; set; } = string.Empty;
        /// <summary>
        /// Price precision (amount of decimals)
        /// </summary>
        [JsonProperty("price_scale")]
        public int PricePrecision { get; set; }
        /// <summary>
        /// Taker fee rate
        /// </summary>
        [JsonProperty("taker_fee")]
        public decimal TakerFee { get; set; }
        /// <summary>
        /// Maker fee rate
        /// </summary>
        [JsonProperty("maker_fee")]
        public decimal MakerFee { get; set; }
        /// <summary>
        /// Leverage filter
        /// </summary>
        [JsonProperty("leverage_filter")]
        public BybitLeverageFilter LeverageFilter { get; set; } = default!;
        /// <summary>
        /// Price filter
        /// </summary>
        [JsonProperty("price_filter")]
        public BybitPriceFilter PriceFilter { get; set; } = default!;
        /// <summary>
        /// Lot size filter
        /// </summary>
        [JsonProperty("lot_size_filter")]
        public BybitLotSizeFilter LotSizeFilter { get; set; } = default!;
    }

    /// <summary>
    /// Leverage rules
    /// </summary>
    public class BybitLeverageFilter
    {
        /// <summary>
        /// Minimal leverage
        /// </summary>
        [JsonProperty("min_leverage")]
        public decimal MinLeverage { get; set; }
        /// <summary>
        /// Maximum leverage
        /// </summary>
        [JsonProperty("max_leverage")]
        public decimal MaxLeverage { get; set; }
        /// <summary>
        /// Leverage step
        /// </summary>
        [JsonProperty("leverage_step")]
        public decimal LeverageStep { get; set; }
    }

    /// <summary>
    /// Price rules
    /// </summary>
    public class BybitPriceFilter
    {
        /// <summary>
        /// Minimal price
        /// </summary>
        [JsonProperty("min_price")]
        public decimal MinPrice { get; set; }
        /// <summary>
        /// Maximum price
        /// </summary>
        [JsonProperty("max_price")]
        public decimal MaxPrice { get; set; }
        /// <summary>
        /// Tick size
        /// </summary>
        [JsonProperty("tick_size")]
        public decimal TickSize { get; set; }
    }

    /// <summary>
    /// Lot size rules
    /// </summary>
    public class BybitLotSizeFilter
    {
        /// <summary>
        /// Minimal quantity
        /// </summary>
        [JsonProperty("min_trading_qty")]
        public decimal MinQuantity { get; set; }
        /// <summary>
        /// Maximum quantity
        /// </summary>
        [JsonProperty("max_trading_qty")]
        public decimal MaxQuantity { get; set; }
        /// <summary>
        /// Quantity step
        /// </summary>
        [JsonProperty("qty_step")]
        public decimal QuantityStep { get; set; }
    }
}
