using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Margin mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum MarginMode
    {
        /// <summary>
        /// Regular margin
        /// </summary>
        [Map("REGULAR_MARGIN")]
        RegularMargin,
        /// <summary>
        /// Portfolio margin
        /// </summary>
        [Map("PORTFOLIO_MARGIN")]
        PortfolioMargin
    }
}
