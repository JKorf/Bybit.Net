using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Transfer coin balance
    /// </summary>
    public class CoinBalanceQuery
    {
        /// <summary>
        /// Account type
        /// </summary>
        [JsonProperty("accountType")]
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Account business subtype
        /// </summary>
        [JsonProperty("bizType")]
        public int BizType { get; set; }

        /// <summary>
        /// AccountID
        /// </summary>
        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        /// <summary>
        /// UserID
        /// </summary>
        [JsonProperty("memberId")]
        public int UserId { get; set; }

        /// <summary>
        /// Balance info
        /// </summary>
        [JsonProperty("balance")]
        public QueryBalance Balance { get; set; } = null!;
    }

    /// <summary>
    /// Transfer balance info
    /// </summary>
    public class QueryBalance
    {
        /// <summary>
        /// The asset
        /// </summary>
        [JsonProperty("coin")]
        public string? Asset { get; set; }

        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("walletBalance")]
        public decimal WalletBalance { get; set; }

        /// <summary>
        /// Transferable balance = available balance - bonus
        /// </summary>
        [JsonProperty("transferBalance")]
        public decimal TransferBalance { get; set; }

        /// <summary>
        /// The bonus
        /// </summary>
        [JsonProperty("bonus")]
        public string BonusAmount { get; set; } = string.Empty;
    }
}
