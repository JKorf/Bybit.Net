using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Borrow quota info
    /// </summary>
    public record BybitBorrowQuota
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Max trade quantity in base asset
        /// </summary>
        [JsonProperty("maxTradeQty")]
        public decimal MaxTradeQuantity { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        public OrderSide Side { get; set; }
        /// <summary>
        /// Max trade amount in quote asset
        /// </summary>
        public decimal MaxTradeAmount { get; set; }
        /// <summary>
        /// Borrow asset
        /// </summary>
        [JsonProperty("borrowCoin")]
        public string BorrowAsset { get; set; } = string.Empty;
        /// <summary>
        /// No matter your Spot margin switch on or not, it always returns actual qty of base coin you can trade or you have, up to 4 decimals
        /// </summary>
        [JsonProperty("spotMaxTradeQty")]
        public decimal SpotMaxTradeQty { get; set; }
        /// <summary>
        /// No matter your Spot margin switch on or not, it always returns actual amount of quote coin you can trade or you have, up to 8 decimals
        /// </summary>
        [JsonProperty("spotMaxTradeAmount")]
        public decimal SpotMaxTradeAmount { get; set; }
    }
}
