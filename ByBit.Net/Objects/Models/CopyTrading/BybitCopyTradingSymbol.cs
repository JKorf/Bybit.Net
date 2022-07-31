using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.CopyTrading
{
    /// <summary>
    /// Copy trading symbol
    /// </summary>
    public class BybitCopyTradingSymbol
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonProperty("baseCurrency")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonProperty("quoteCurrency")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Price scale (the number of decimal places to which a price can be submitted, although the final price may be rounded to conform to the tick_size)
        /// </summary>
        public decimal PriceScale { get; set; }
        /// <summary>
        /// Taker fee
        /// </summary>
        public decimal TakerFee { get; set; }
        /// <summary>
        /// Maker fee
        /// </summary>
        public decimal MakerFee { get; set; }
        /// <summary>
        /// Funding fee interval
        /// </summary>
        public int FundingInterval { get; set; }
        /// <summary>
        /// Leverage filter
        /// </summary>
        public BybitCopyTradingLeverageFilter LeverageFilter { get; set; } = null!;
        /// <summary>
        /// Price filter
        /// </summary>
        public BybitCopyTradingPriceFilter PriceFilter { get; set; } = null!;
        /// <summary>
        /// Lot size filter
        /// </summary>
        public BybitCopyTradingLotSizeFilter LotSizeFilter { get; set; } = null!;
    }

    /// <summary>
    /// Leverage rules
    /// </summary>
    public class BybitCopyTradingLeverageFilter
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
        public decimal? LeverageStep { get; set; }
    }

    /// <summary>
    /// Price rules
    /// </summary>
    public class BybitCopyTradingPriceFilter
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
    public class BybitCopyTradingLotSizeFilter
    {
        /// <summary>
        /// Minimal quantity
        /// </summary>
        [JsonProperty("minOrderQty")]
        public decimal MinQuantity { get; set; }
        /// <summary>
        /// Maximum quantity
        /// </summary>
        [JsonProperty("maxOrderQty")]
        public decimal MaxQuantity { get; set; }
        /// <summary>
        /// Quantity step
        /// </summary>
        [JsonProperty("qtyStep")]
        public decimal QuantityStep { get; set; }
    }
}
