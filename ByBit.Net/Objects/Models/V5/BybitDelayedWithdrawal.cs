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
        /// ["<c>limitAmountUsd</c>"] Limit quantity usd
        /// </summary>
        [JsonPropertyName("limitAmountUsd")]
        public decimal LimitQuantityUsd { get; set; }
        /// <summary>
        /// ["<c>withdrawableAmount</c>"] Withdrawable amount per account
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
        /// ["<c>SPOT</c>"] Spot account
        /// </summary>
        [JsonPropertyName("SPOT")]
        public BybitDelayedWithdrawalQuantity Spot { get; set; } = null!;
        /// <summary>
        /// ["<c>FUND</c>"] Fund account
        /// </summary>
        [JsonPropertyName("FUND")]
        public BybitDelayedWithdrawalQuantity Fund { get; set; } = null!;
        /// <summary>
        /// ["<c>UTA</c>"] Universal Trade Account
        /// </summary>
        [JsonPropertyName("UTA")]
        public BybitDelayedWithdrawalQuantity Uta { get; set; } = null!;
        /// <summary>
        /// ["<c>EARN</c>"] Earn account
        /// </summary>
        [JsonPropertyName("EARN")]
        public BybitDelayedWithdrawalQuantity Earn { get; set; } = null!;
    }

    /// <summary>
    /// Delayed withdrawal account quantity
    /// </summary>
    [SerializationModel]
    public record BybitDelayedWithdrawalQuantity
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>withdrawableAmount</c>"] Withdrawable quantity
        /// </summary>
        [JsonPropertyName("withdrawableAmount")]
        public decimal WithdrwawableQuantity { get; set; }
        /// <summary>
        /// ["<c>availableBalance</c>"] Available balance
        /// </summary>
        [JsonPropertyName("availableBalance")]
        public decimal AvailableBalance { get; set; }
    }
}
