using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Leverage token purchase record
    /// </summary>
    public class BybitLeverageTokenRecord
    {
        /// <summary>
        /// Token abbreviation
        /// </summary>
        [JsonProperty("ltCoin")]
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("ltOrderStatus"), JsonConverter(typeof(EnumConverter))]
        public LeverageTokenOrderStatus Status { get; set; }
        /// <summary>
        /// Filled quantity
        /// </summary>
        [JsonProperty("execQty")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// Filled quantity
        /// </summary>
        [JsonProperty("execAmt")]
        public decimal? ValueFilled { get; set; }
        /// <summary>
        /// Purchase amount
        /// </summary>
        [JsonProperty("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Purchase id
        /// </summary>
        [JsonProperty("purchaseId")]
        public string PurchaseId { get; set; } = string.Empty;
        /// <summary>
        /// Serial number
        /// </summary>
        [JsonProperty("serialNo")]
        public string? ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonProperty("valueCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
    }
}
