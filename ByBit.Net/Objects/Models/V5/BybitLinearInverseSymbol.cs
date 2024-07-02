using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Linear/Inverse symbol
    /// </summary>
    public record BybitLinearInverseSymbol
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
        /// Whether the contract is a pre-market contract
        /// </summary>
        [JsonProperty("isPreListing")]
        public bool IsPrelisting { get; set; }

        /// <summary>
        /// Prelisting information
        /// </summary>
        [JsonProperty("preListingInfo")]
        public BybitPrelistingInfo? PrelistingInfo { get; set; }

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
    /// Prelisting info
    /// </summary>
    public record BybitPrelistingInfo
    {
        /// <summary>
        /// Current auction phase
        /// </summary>
        [JsonProperty("curAuctionPhase"), JsonConverter(typeof(EnumConverter))]
        public AuctionPhase CurrentPhase { get; set; }

        /// <summary>
        /// Phases
        /// </summary>
        [JsonProperty("phases")]
        public IEnumerable<BybitPrelistingPhase> Phases { get; set; } = Array.Empty<BybitPrelistingPhase>();

        /// <summary>
        /// Fee info
        /// </summary>
        [JsonProperty("auctionFeeInfo")]
        public BybitPrelistingFees Fees { get; set; } = null!;
    }

    /// <summary>
    /// Prelisting fee info
    /// </summary>
    public record BybitPrelistingFees
    {
        /// <summary>
        /// The trading fee rate during auction phase
        /// </summary>
        [JsonProperty("auctionFeeRate")]
        public decimal AuctionFeeRate { get; set; }
        /// <summary>
        /// The taker fee rate during continues trading phase
        /// </summary>
        [JsonProperty("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// The maker fee rate during continues trading phase
        /// </summary>
        [JsonProperty("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
    }

    /// <summary>
    /// Prelisting phase
    /// </summary>
    public record BybitPrelistingPhase
    {
        /// <summary>
        /// Phase
        /// </summary>
        [JsonProperty("phase"), JsonConverter(typeof(EnumConverter))]
        public AuctionPhase Phase { get; set; }
        /// <summary>
        /// Phase start time
        /// </summary>
        [JsonProperty("startTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Phase end time
        /// </summary>
        [JsonProperty("endTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime EndTime { get; set; }
    }

    /// <summary>
    /// Leverage filter info
    /// </summary>
    public record BybitLinearInverseLeveragefilter
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
    public record BybitLinearInverseLotSizeFilter
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
        /// <summary>
        /// Minimal notional value of an order
        /// </summary>
        [JsonProperty("minNotionalValue")]
        public decimal? MinNotionalValue { get; set; }
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    public record BybitLinearInversePriceFilter
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
