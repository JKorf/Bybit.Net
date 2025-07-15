using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// User trade info
    /// </summary>
    [SerializationModel]
    public record BybitUserTradeUpdate : BybitUserTrade
    {
        /// <summary>
        /// Profit and Loss for a position execution
        /// </summary>
        [JsonPropertyName("execPnl")]
        public decimal? Pnl { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
