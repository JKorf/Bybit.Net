using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Leverage token purchase record
    /// </summary>
    [SerializationModel]
    public record BybitLeverageTokenRecord
    {
        /// <summary>
        /// Token abbreviation
        /// </summary>
        [JsonPropertyName("ltCoin")]
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// Order status
        /// </summary>
        [JsonPropertyName("ltOrderStatus")]
        public LeverageTokenOrderStatus Status { get; set; }
        /// <summary>
        /// Filled quantity
        /// </summary>
        [JsonPropertyName("execQty")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// Filled quantity
        /// </summary>
        [JsonPropertyName("execAmt")]
        public decimal? ValueFilled { get; set; }
        /// <summary>
        /// Purchase amount
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal? Quantity { get; set; }
        [JsonInclude, JsonPropertyName("quantity")]
        internal decimal? QuantityInt
        {
            set => Quantity = value;
            get => Quantity;
        }
        /// <summary>
        /// Serial number
        /// </summary>
        [JsonPropertyName("serialNo")]
        public string? ClientOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonPropertyName("valueCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
    }

    /// <summary>
    /// Purchase record
    /// </summary>
    [SerializationModel]
    public record BybitLeverageTokenPurchase : BybitLeverageTokenRecord
    {
        /// <summary>
        /// Purchase id
        /// </summary>
        [JsonPropertyName("purchaseId")]
        public string PurchaseId { get; set; } = string.Empty;
    }

    /// <summary>
    /// Purchase record
    /// </summary>
    [SerializationModel]
    public record BybitLeverageTokenRedemption : BybitLeverageTokenRecord
    {
        /// <summary>
        /// Redeem id
        /// </summary>
        [JsonPropertyName("redeemId")]
        public string RedeemId { get; set; } = string.Empty;
    }
}
