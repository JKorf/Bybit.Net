using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Derivatives.Contract
{
    /// <summary>
    /// Position info
    /// </summary>
    public class BybitContractWalletFundRecord
    {
        /// <summary>
        /// Coin
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Risk id
        /// </summary>
        [JsonProperty("type"), JsonConverter(typeof(WalletFundTypeConverter))]
        public WalletFundType FundType { get; set; }

        /// <summary>
        /// Fund amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("wallet_balance")]
        public decimal WalletBalance { get; set; }

        /// <summary>
        /// Transaction time
        /// </summary>
        [JsonProperty("exec_time"), JsonConverter(typeof(DateTimeConverter))]
        public decimal TransactionTime { get; set; }
    }
}
