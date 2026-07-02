using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Option symbol
    /// </summary>
    [SerializationModel]
    public record BybitOptionSymbol
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
        public string DisplayName { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>optionsType</c>"] Options type
        /// </summary>
        [JsonPropertyName("optionsType")]
        public OptionType OptionType { get; set; }
        /// <summary>
        /// ["<c>symbolType</c>"] Symbol type
        /// </summary>
        [JsonPropertyName("symbolType")]
        public SymbolType? SymbolType { get; set; }
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
        public DateTime DeliveryTime { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Symbol status
        /// </summary>

        [JsonPropertyName("status")]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// ["<c>deliveryFeeRate</c>"] Delivery fee rate
        /// </summary>
        [JsonPropertyName("deliveryFeeRate")]
        public decimal DeliveryFeeRate { get; set; }
        /// <summary>
        /// ["<c>lotSizeFilter</c>"] Lot size order filter
        /// </summary>
        [JsonPropertyName("lotSizeFilter")]
        public BybitOptionLotSizeFilter? LotSizeFilter { get; set; }
        /// <summary>
        /// ["<c>priceFilter</c>"] Price order filter
        /// </summary>
        [JsonPropertyName("priceFilter")]
        public BybitOptionPriceFilter? PriceFilter { get; set; }
    }

    /// <summary>
    /// Lot size filter info
    /// </summary>
    [SerializationModel]
    public record BybitOptionLotSizeFilter
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
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    [SerializationModel]
    public record BybitOptionPriceFilter
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
