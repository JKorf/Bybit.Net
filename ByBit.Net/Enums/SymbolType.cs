using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Symbol type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SymbolType>))]
    public enum SymbolType
    {
        /// <summary>
        /// ["<c>innovation</c>"] Innovation
        /// </summary>
        [Map("innovation")]
        Innovation,
        /// <summary>
        /// ["<c>adventure</c>"] Adventure
        /// </summary>
        [Map("adventure")]
        Adventure,
        /// <summary>
        /// ["<c>xstocks</c>"] X Stocks
        /// </summary>
        [Map("xstocks")]
        XStocks,
        /// <summary>
        /// ["<c>commodity</c>"] Commodity
        /// </summary>
        [Map("commodity")]
        Commodity,
        /// <summary>
        /// ["<c>stock</c>"] Stock
        /// </summary>
        [Map("stock")]
        Stock,
        /// <summary>
        /// ["<c>forex</c>"] Forex
        /// </summary>
        [Map("forex")]
        Forex,
    }
}
