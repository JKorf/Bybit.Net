using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Linear/Inverse symbol
    /// </summary>
    [SerializationModel]
    public record BybitLinearInverseSymbol
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Display name
        /// </summary>
        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// Contract type
        /// </summary>
        [JsonPropertyName("contractType")]

        public ContractTypeV5 ContractType { get; set; }
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Settle asset
        /// </summary>
        [JsonPropertyName("settleCoin")]
        public string SettleAsset { get; set; } = string.Empty;
        /// <summary>
        /// Launch time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("launchTime")]
        public DateTime LaunchTime { get; set; }
        /// <summary>
        /// Delivery time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("deliveryTime")]
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// Symbol status
        /// </summary>

        [JsonPropertyName("status")]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// Delivery fee rate
        /// </summary>
        [JsonPropertyName("deliveryFeeRate")]
        public decimal? DeliveryFeeRate { get; set; }
        /// <summary>
        /// Price scale
        /// </summary>
        [JsonPropertyName("priceScale")]
        public decimal PriceScale { get; set; }
        /// <summary>
        /// Unified margin trade
        /// </summary>
        [JsonPropertyName("unifiedMarginTrade")]
        public bool UnifiedMarginTrade { get; set; }
        /// <summary>
        /// Funding interval in minutes
        /// </summary>
        [JsonPropertyName("fundingInterval")]
        public int FundingInterval { get; set; }
        /// <summary>
        /// Copy trading support
        /// </summary>
        [JsonPropertyName("copyTrading")]
        public CopyTradeType CopyTrading { get; set; }
        /// <summary>
        /// Upper limit of funding date
        /// </summary>
        [JsonPropertyName("upperFundingRate")]
        public decimal UpperFundingRate { get; set; }
        /// <summary>
        /// Lower limit of funding data
        /// </summary>
        [JsonPropertyName("lowerFundingRate")]
        public decimal LowerFundingRate { get; set; }
        /// <summary>
        /// Whether the contract is a pre-market contract
        /// </summary>
        [JsonPropertyName("isPreListing")]
        public bool IsPrelisting { get; set; }
        /// <summary>
        /// Symbol type
        /// </summary>
        [JsonPropertyName("symbolType")]
        public SymbolType? SymbolType { get; set; }

        /// <summary>
        /// Prelisting information
        /// </summary>
        [JsonPropertyName("preListingInfo")]
        public BybitPrelistingInfo? PrelistingInfo { get; set; }

        /// <summary>
        /// Lot size order filter
        /// </summary>
        [JsonPropertyName("lotSizeFilter")]
        public BybitLinearInverseLotSizeFilter? LotSizeFilter { get; set; }
        /// <summary>
        /// Price order filter
        /// </summary>
        [JsonPropertyName("priceFilter")]
        public BybitLinearInversePriceFilter? PriceFilter { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverageFilter")]
        public BybitLinearInverseLeveragefilter? LeverageFilter { get; set; }
        /// <summary>
        /// Risk limit parameters
        /// </summary>
        [JsonPropertyName("riskParameters")]
        public BybitRiskParameters? BybitRiskParameters { get; set; }
    }

    /// <summary>
    /// Risk limit parameters
    /// </summary>
    [SerializationModel]
    public record BybitRiskParameters
    {
        /// <summary>
        /// Price limit ratio X value
        /// </summary>
        [JsonPropertyName("priceLimitRatioX")]
        public decimal? PriceLimitRatioX { get; set; }
        /// <summary>
        /// Price limit ratio Y value
        /// </summary>
        [JsonPropertyName("priceLimitRatioY")]
        public decimal? PriceLimitRatioY { get; set; }
    }

    /// <summary>
    /// Prelisting info
    /// </summary>
    [SerializationModel]
    public record BybitPrelistingInfo
    {
        /// <summary>
        /// Current auction phase
        /// </summary>
        [JsonPropertyName("curAuctionPhase")]
        public AuctionPhase CurrentPhase { get; set; }

        /// <summary>
        /// Phases
        /// </summary>
        [JsonPropertyName("phases")]
        public BybitPrelistingPhase[] Phases { get; set; } = Array.Empty<BybitPrelistingPhase>();

        /// <summary>
        /// Fee info
        /// </summary>
        [JsonPropertyName("auctionFeeInfo")]
        public BybitPrelistingFees Fees { get; set; } = null!;
    }

    /// <summary>
    /// Prelisting fee info
    /// </summary>
    [SerializationModel]
    public record BybitPrelistingFees
    {
        /// <summary>
        /// The trading fee rate during auction phase
        /// </summary>
        [JsonPropertyName("auctionFeeRate")]
        public decimal AuctionFeeRate { get; set; }
        /// <summary>
        /// The taker fee rate during continues trading phase
        /// </summary>
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// The maker fee rate during continues trading phase
        /// </summary>
        [JsonPropertyName("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
    }

    /// <summary>
    /// Prelisting phase
    /// </summary>
    [SerializationModel]
    public record BybitPrelistingPhase
    {
        /// <summary>
        /// Phase
        /// </summary>
        [JsonPropertyName("phase")]
        public AuctionPhase Phase { get; set; }
        /// <summary>
        /// Phase start time
        /// </summary>
        [JsonPropertyName("startTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Phase end time
        /// </summary>
        [JsonPropertyName("endTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime EndTime { get; set; }
    }

    /// <summary>
    /// Leverage filter info
    /// </summary>
    [SerializationModel]
    public record BybitLinearInverseLeveragefilter
    {
        /// <summary>
        /// Min leverage
        /// </summary>
        [JsonPropertyName("minLeverage")]
        public decimal MinLeverage { get; set; }
        /// <summary>
        /// Max leverage
        /// </summary>
        [JsonPropertyName("maxLeverage")]
        public decimal MaxLeverage { get; set; }
        /// <summary>
        /// Leverage step
        /// </summary>
        [JsonPropertyName("leverageStep")]
        public decimal LeverageStep { get; set; }
    }

    /// <summary>
    /// Lot size filter info
    /// </summary>
    [SerializationModel]
    public record BybitLinearInverseLotSizeFilter
    {
        /// <summary>
        /// Quantity step
        /// </summary>
        [JsonPropertyName("qtyStep")]
        public decimal QuantityStep { get; set; }
        /// <summary>
        /// Min order quantity
        /// </summary>
        [JsonPropertyName("minOrderQty")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// Max order quantity
        /// </summary>
        [JsonPropertyName("maxOrderQty")]
        public decimal MaxOrderQuantity { get; set; }
        /// <summary>
        /// Max market order quantity
        /// </summary>
        [JsonPropertyName("maxMktOrderQty")]
        public decimal MaxMarketOrderQuantity { get; set; }
        /// <summary>
        /// Minimal notional value of an order
        /// </summary>
        [JsonPropertyName("minNotionalValue")]
        public decimal? MinNotionalValue { get; set; }
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    [SerializationModel]
    public record BybitLinearInversePriceFilter
    {
        /// <summary>
        /// Tick size
        /// </summary>
        [JsonPropertyName("tickSize")]
        public decimal TickSize { get; set; }
        /// <summary>
        /// Min price
        /// </summary>
        [JsonPropertyName("minPrice")]
        public decimal MinPrice { get; set; }
        /// <summary>
        /// Max price
        /// </summary>
        [JsonPropertyName("maxPrice")]
        public decimal MaxPrice { get; set; }
    }
}
