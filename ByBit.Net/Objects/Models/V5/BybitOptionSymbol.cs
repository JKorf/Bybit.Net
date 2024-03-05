using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Option symbol
    /// </summary>
    public class BybitOptionSymbol
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Options type
        /// </summary>
        [JsonProperty("optionsType")]
        [JsonConverter(typeof(EnumConverter))]
        public OptionType OptionType { get; set; }
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
        public DateTime DeliveryTime { get; set; }
        /// <summary>
        /// Symbol status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// Delivery fee rate
        /// </summary>
        public decimal DeliveryFeeRate { get; set; }
        /// <summary>
        /// Lot size order filter
        /// </summary>
        public BybitOptionLotSizeFilter? LotSizeFilter { get; set; }
        /// <summary>
        /// Price order filter
        /// </summary>
        public BybitOptionPriceFilter? PriceFilter { get; set; }
    }

    /// <summary>
    /// Lot size filter info
    /// </summary>
    public class BybitOptionLotSizeFilter
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
    }

    /// <summary>
    /// Price filter info
    /// </summary>
    public class BybitOptionPriceFilter
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
