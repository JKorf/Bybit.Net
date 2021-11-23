using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// Insurance update
    /// </summary>
    public class BybitInsuranceUpdate
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("wallet_balance")]
        public decimal WalletBalance { get; set; }
    }
}
