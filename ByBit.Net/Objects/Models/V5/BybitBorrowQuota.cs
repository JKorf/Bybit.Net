using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Borrow quota info
    /// </summary>
    public class BybitBorrowQuota
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
        public string BorrowAsset { get; set; } = string.Empty;
    }
}
