using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Delayed withdrawal info
    /// </summary>
    [SerializationModel]
    public record BybitDelayedWithdrawal
    {
        /// <summary>
        /// Limit quantity usd
        /// </summary>
        [JsonPropertyName("limitAmountUsd")]
        public decimal LimitQuantityUsd { get; set; }
        /// <summary>
        /// Withdrawable amount per account
        /// </summary>
        [JsonPropertyName("withdrawableAmount")]
        public BybitDelayedWithdrawalQuantities WithdrawableQuantities { get; set; } = null!;
    }

    /// <summary>
    /// Delayed withdrawal account info
    /// </summary>
    [SerializationModel]
    public record BybitDelayedWithdrawalQuantities
    {
        /// <summary>
        /// Spot account
        /// </summary>
        [JsonPropertyName("SPOT")]
        public BybitDelayedWithdrawalQuantity Spot { get; set; } = null!;
        /// <summary>
        /// Fund account
        /// </summary>
        [JsonPropertyName("FUND")]
        public BybitDelayedWithdrawalQuantity Fund { get; set; } = null!;
        /// <summary>
        /// Universal Trade Account
        /// </summary>
        [JsonPropertyName("UTA")]
        public BybitDelayedWithdrawalQuantity Uta { get; set; } = null!;
    }

    /// <summary>
    /// Delayed withdrawal account quantity
    /// </summary>
    [SerializationModel]
    public record BybitDelayedWithdrawalQuantity
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Withdrawable quantity
        /// </summary>
        [JsonPropertyName("withdrawableAmount")]
        public decimal WithdrwawableQuantity { get; set; }
        /// <summary>
        /// Available balance
        /// </summary>
        [JsonPropertyName("availableBalance")]
        public decimal AvailableBalance { get; set; }
    }
}
