using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Linear/Inverse symbol
    /// </summary>
    [SerializationModel]
    public record BybitLinearInverseSymbol
    {
        /// <summary>
        /// ["<c>symbolId</c>"] Symbol id
        /// </summary>
        [JsonPropertyName("symbolId")]
        public int SymbolId { get; set; }
        /// <summary>
        /// ["<c>symbol</c>"] Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>displayName</c>"] Display name
        /// </summary>
        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// ["<c>forbidUplWithdrawal</c>"] Whether to prohibit unrealised profit withdrawal
        /// </summary>
        [JsonPropertyName("forbidUplWithdrawal")]
        public bool? ForbidUnrealizedPnlWithdrawal { get; set; }

        /// <summary>
        /// ["<c>contractType</c>"] Contract type
        /// </summary>
        [JsonPropertyName("contractType")]

        public ContractTypeV5 ContractType { get; set; }
        /// <summary>
        /// ["<c>baseCoin</c>"] Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>quoteCoin</c>"] Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>settleCoin</c>"] Settle asset
        /// </summary>
        [JsonPropertyName("settleCoin")]
        public string SettleAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>launchTime</c>"] Launch time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("launchTime")]
        public DateTime LaunchTime { get; set; }
        /// <summary>
        /// ["<c>deliveryTime</c>"] Delivery time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("deliveryTime")]
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Symbol status
        /// </summary>

        [JsonPropertyName("status")]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// ["<c>deliveryFeeRate</c>"] Delivery fee rate
        /// </summary>
        [JsonPropertyName("deliveryFeeRate")]
        public decimal? DeliveryFeeRate { get; set; }
        /// <summary>
        /// ["<c>priceScale</c>"] Price scale
        /// </summary>
        [JsonPropertyName("priceScale")]
        public int PriceScale { get; set; }
        /// <summary>
        /// ["<c>unifiedMarginTrade</c>"] Unified margin trade
        /// </summary>
        [JsonPropertyName("unifiedMarginTrade")]
        public bool UnifiedMarginTrade { get; set; }
        /// <summary>
        /// ["<c>fundingInterval</c>"] Funding interval in minutes
        /// </summary>
        [JsonPropertyName("fundingInterval")]
        public int FundingInterval { get; set; }
        /// <summary>
        /// ["<c>copyTrading</c>"] Copy trading support
        /// </summary>
        [JsonPropertyName("copyTrading")]
        public CopyTradeType CopyTrading { get; set; }
        /// <summary>
        /// ["<c>upperFundingRate</c>"] Upper limit of funding date
        /// </summary>
        [JsonPropertyName("upperFundingRate")]
        public decimal UpperFundingRate { get; set; }
        /// <summary>
        /// ["<c>lowerFundingRate</c>"] Lower limit of funding data
        /// </summary>
        [JsonPropertyName("lowerFundingRate")]
        public decimal LowerFundingRate { get; set; }
        /// <summary>
        /// ["<c>isPreListing</c>"] Whether the contract is a pre-market contract
        /// </summary>
        [JsonPropertyName("isPreListing")]
        public bool IsPrelisting { get; set; }
        /// <summary>
        /// ["<c>symbolType</c>"] Symbol type
        /// </summary>
        [JsonPropertyName("symbolType")]
        public SymbolType? SymbolType { get; set; }

        /// <summary>
        /// ["<c>preListingInfo</c>"] Prelisting information
        /// </summary>
        [JsonPropertyName("preListingInfo")]
        public BybitPrelistingInfo? PrelistingInfo { get; set; }

        /// <summary>
        /// ["<c>lotSizeFilter</c>"] Lot size order filter
        /// </summary>
        [JsonPropertyName("lotSizeFilter")]
        public BybitLinearInverseLotSizeFilter? LotSizeFilter { get; set; }
        /// <summary>
        /// ["<c>priceFilter</c>"] Price order filter
        /// </summary>
        [JsonPropertyName("priceFilter")]
        public BybitLinearInversePriceFilter? PriceFilter { get; set; }
        /// <summary>
        /// ["<c>leverageFilter</c>"] Leverage
        /// </summary>
        [JsonPropertyName("leverageFilter")]
        public BybitLinearInverseLeverageFilter? LeverageFilter { get; set; }
        /// <summary>
        /// ["<c>riskParameters</c>"] Risk limit parameters
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
        /// ["<c>priceLimitRatioX</c>"] Price limit ratio X value
        /// </summary>
        [JsonPropertyName("priceLimitRatioX")]
        public decimal? PriceLimitRatioX { get; set; }
        /// <summary>
        /// ["<c>priceLimitRatioY</c>"] Price limit ratio Y value
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
        /// ["<c>curAuctionPhase</c>"] Current auction phase
        /// </summary>
        [JsonPropertyName("curAuctionPhase")]
        public AuctionPhase CurrentPhase { get; set; }

        /// <summary>
        /// ["<c>phases</c>"] Phases
        /// </summary>
        [JsonPropertyName("phases")]
        public BybitPrelistingPhase[] Phases { get; set; } = Array.Empty<BybitPrelistingPhase>();

        /// <summary>
        /// ["<c>auctionFeeInfo</c>"] Fee info
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
        /// ["<c>auctionFeeRate</c>"] The trading fee rate during auction phase
        /// </summary>
        [JsonPropertyName("auctionFeeRate")]
        public decimal AuctionFeeRate { get; set; }
        /// <summary>
        /// ["<c>takerFeeRate</c>"] The taker fee rate during continues trading phase
        /// </summary>
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>makerFeeRate</c>"] The maker fee rate during continues trading phase
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
        /// ["<c>phase</c>"] Phase
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
    public record BybitLinearInverseLeverageFilter
    {
        /// <summary>
        /// ["<c>minLeverage</c>"] Min leverage
        /// </summary>
        [JsonPropertyName("minLeverage")]
        public decimal MinLeverage { get; set; }
        /// <summary>
        /// ["<c>maxLeverage</c>"] Max leverage
        /// </summary>
        [JsonPropertyName("maxLeverage")]
        public decimal MaxLeverage { get; set; }
        /// <summary>
        /// ["<c>leverageStep</c>"] Leverage step
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
        /// ["<c>qtyStep</c>"] Quantity step
        /// </summary>
        [JsonPropertyName("qtyStep")]
        public decimal QuantityStep { get; set; }
        /// <summary>
        /// ["<c>minOrderQty</c>"] Min order quantity
        /// </summary>
        [JsonPropertyName("minOrderQty")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>maxOrderQty</c>"] Max order quantity
        /// </summary>
        [JsonPropertyName("maxOrderQty")]
        public decimal MaxOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>maxMktOrderQty</c>"] Max market order quantity
        /// </summary>
        [JsonPropertyName("maxMktOrderQty")]
        public decimal MaxMarketOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>minNotionalValue</c>"] Minimal notional value of an order
        /// </summary>
        [JsonPropertyName("minNotionalValue")]
        public decimal? MinNotionalValue { get; set; }
        /// <summary>
        /// ["<c>postOnlyMaxOrderQty</c>"] Max order quantity for post only orders
        /// </summary>
        [JsonPropertyName("postOnlyMaxOrderQty")]
        public decimal? PostOnlyMaxOrderQuantity { get; set; }
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    [SerializationModel]
    public record BybitLinearInversePriceFilter
    {
        /// <summary>
        /// ["<c>tickSize</c>"] Tick size
        /// </summary>
        [JsonPropertyName("tickSize")]
        public decimal TickSize { get; set; }
        /// <summary>
        /// ["<c>minPrice</c>"] Min price
        /// </summary>
        [JsonPropertyName("minPrice")]
        public decimal MinPrice { get; set; }
        /// <summary>
        /// ["<c>maxPrice</c>"] Max price
        /// </summary>
        [JsonPropertyName("maxPrice")]
        public decimal MaxPrice { get; set; }
    }
}
