using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

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
        PortfolioMargin,
        /// <summary>
        /// Isolated margin
        /// </summary>
        [Map("ISOLATED_MARGIN")]
        IsolatedMargin
    }
}
