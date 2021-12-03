using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Order book entry
    /// </summary>
    [JsonConverter(typeof(ArrayConverter))]
    public class BybitSpotOrderBookEntry: ISymbolOrderBookEntry
    {
        /// <summary>
        /// Price
        /// </summary>
        [ArrayProperty(0)]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [ArrayProperty(1)]
        public decimal Quantity { get; set; }
    }
}
