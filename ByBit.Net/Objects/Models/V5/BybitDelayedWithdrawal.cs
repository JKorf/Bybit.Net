using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Delayed withdrawal info
    /// </summary>
    public class BybitDelayedWithdrawal
    {
        /// <summary>
        /// Limit quantity usd
        /// </summary>
        [JsonProperty("limitAmountUsd")]
        public decimal LimitQuantityUsd { get; set; }
        /// <summary>
        /// Withdrawable amount per account
        /// </summary>
        [JsonProperty("withdrawableAmount")]
        public BybitDelayedWithdrawalQuantities WithdrawableQuantities { get; set; } = null!;
    }

    /// <summary>
    /// Delayed withdrawal account info
    /// </summary>
    public class BybitDelayedWithdrawalQuantities
    {
        /// <summary>
        /// Spot account
        /// </summary>
        public BybitDelayedWithdrawalQuantity Spot { get; set; } = null!;
        /// <summary>
        /// Fund account
        /// </summary>
        public BybitDelayedWithdrawalQuantity Fund { get; set; } = null!;
    }

    /// <summary>
    /// Delayed withdrawal account quantity
    /// </summary>
    public class BybitDelayedWithdrawalQuantity
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Withdrawable quantity
        /// </summary>
        [JsonProperty("withdrawableAmount")]
        public decimal WithdrwawableQuantity { get; set; }
        /// <summary>
        /// Available balance
        /// </summary>
        public decimal AvailableBalance { get; set; }
    }
}
