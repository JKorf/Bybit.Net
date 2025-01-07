using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// User trade info
    /// </summary>
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
        [JsonConverter(typeof(EnumConverter))]
        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
