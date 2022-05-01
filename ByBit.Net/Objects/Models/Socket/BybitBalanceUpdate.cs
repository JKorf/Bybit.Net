using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// Balance update
    /// </summary>
    public class BybitBalanceUpdate
    {
        /// <summary>
        /// The asset
        /// </summary>
        [JsonProperty("coin")]
        public string? Asset { get; set; }
        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("wallet_balance")]
        public decimal WalletBalance { get; set; }
        /// <summary>
        /// Available balance = wallet balance - used margin
        /// </summary>
        [JsonProperty("available_balance")]
        public decimal AvailableBalance { get; set; }
    }
}
