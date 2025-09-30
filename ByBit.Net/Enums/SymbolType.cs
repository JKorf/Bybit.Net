using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
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
        /// Innovation
        /// </summary>
        [Map("innovation")]
        Innovation,
        /// <summary>
        /// Adventure
        /// </summary>
        [Map("adventure")]
        Adventure,
        /// <summary>
        /// X Stocks
        /// </summary>
        [Map("xstocks")]
        XStocks,
    }
}
