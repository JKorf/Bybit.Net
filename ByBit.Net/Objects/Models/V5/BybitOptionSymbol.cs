using CryptoExchange.Net.Converters.SystemTextJson;
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
        /// Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Display name
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; } = string.Empty;
        /// <summary>
        /// Options type
        /// </summary>
        [JsonPropertyName("optionsType")]
        public OptionType OptionType { get; set; }
        /// <summary>
        /// Symbol type
        /// </summary>
        [JsonPropertyName("symbolType")]
        public SymbolType? SymbolType { get; set; }
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
        public DateTime DeliveryTime { get; set; }
        /// <summary>
        /// Symbol status
        /// </summary>

        [JsonPropertyName("status")]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// Delivery fee rate
        /// </summary>
        [JsonPropertyName("deliveryFeeRate")]
        public decimal DeliveryFeeRate { get; set; }
        /// <summary>
        /// Lot size order filter
        /// </summary>
        [JsonPropertyName("lotSizeFilter")]
        public BybitOptionLotSizeFilter? LotSizeFilter { get; set; }
        /// <summary>
        /// Price order filter
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
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    [SerializationModel]
    public record BybitOptionPriceFilter
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
