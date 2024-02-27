using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Linear/Inverse symbol
    /// </summary>
    public class BybitLinearInverseSymbol
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Contract type
        /// </summary>
        [JsonProperty("contractType")]
        [JsonConverter(typeof(EnumConverter))]
        public ContractTypeV5 ContractType { get; set; }
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonProperty("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonProperty("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Settle asset
        /// </summary>
        [JsonProperty("settleCoin")]
        public string SettleAsset { get; set; } = string.Empty;
        /// <summary>
        /// Launch time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LaunchTime { get; set; }
        /// <summary>
        /// Delivery time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// Symbol status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// Delivery fee rate
        /// </summary>
        public decimal? DeliveryFeeRate { get; set; }
        /// <summary>
        /// Price scale
        /// </summary>
        public decimal PriceScale { get; set; }
        /// <summary>
        /// Unified margin trade
        /// </summary>
        public bool UnifiedMarginTrade { get; set; }
        /// <summary>
        /// Funding interval in minutes
        /// </summary>
        public int FundingInterval { get; set; }
        /// <summary>
        /// Copy trading support
        /// </summary>
        [JsonProperty("copyTrading"), JsonConverter(typeof(EnumConverter))]
        public CopyTradeType CopyTrading { get; set; }
        /// <summary>
        /// Upper limit of funding date
        /// </summary>
        [JsonProperty("upperFundingRate")]
        public decimal UpperFundingRate { get; set; }
        /// <summary>
        /// Lower limit of funding data
        /// </summary>
        [JsonProperty("lowerFundingRate")]
        public decimal LowerFundingRate { get; set; }

        /// <summary>
        /// Lot size order filter
        /// </summary>
        public BybitLinearInverseLotSizeFilter? LotSizeFilter { get; set; }
        /// <summary>
        /// Price order filter
        /// </summary>
        public BybitLinearInversePriceFilter? PriceFilter { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        public BybitLinearInverseLeveragefilter? LeverageFilter { get; set; }
    }

    /// <summary>
    /// Leverage filter info
    /// </summary>
    public class BybitLinearInverseLeveragefilter
    {
        /// <summary>
        /// Min leverage
        /// </summary>
        public decimal MinLeverage { get; set; }
        /// <summary>
        /// Max leverage
        /// </summary>
        public decimal MaxLeverage { get; set; }
        /// <summary>
        /// Leverage step
        /// </summary>
        public decimal LeverageStep { get; set; }
    }

    /// <summary>
    /// Lot size filter info
    /// </summary>
    public class BybitLinearInverseLotSizeFilter
    {
        /// <summary>
        /// Quantity step
        /// </summary>
        [JsonProperty("qtyStep")]
        public decimal QuantityStep { get; set; }
        /// <summary>
        /// Min order quantity
        /// </summary>
        [JsonProperty("minOrderQty")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// Max order quantity
        /// </summary>
        [JsonProperty("maxOrderQty")]
        public decimal MaxOrderQuantity { get; set; }
        /// <summary>
        /// Max market order quantity
        /// </summary>
        [JsonProperty("maxMktOrderQty")]
        public decimal MaxMarketOrderQuantity { get; set; }
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    public class BybitLinearInversePriceFilter
    {
        /// <summary>
        /// Tick size
        /// </summary>
        public decimal TickSize { get; set; }
        /// <summary>
        /// Min price
        /// </summary>
        public decimal MinPrice { get; set; }
        /// <summary>
        /// Max price
        /// </summary>
        public decimal MaxPrice { get; set; }
    }
}
