using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Margin mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter<MarginMode>))]
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
        PortfolioMargin,
        /// <summary>
        /// Isolated margin
        /// </summary>
        [Map("ISOLATED_MARGIN")]
        IsolatedMargin
    }
}
