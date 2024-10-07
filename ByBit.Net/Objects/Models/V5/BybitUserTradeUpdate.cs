using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

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
        [JsonProperty("execPnl")]
        public decimal? Pnl { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public Category Category { get; set; }
    }
}
