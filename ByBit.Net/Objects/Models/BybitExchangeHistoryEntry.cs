using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Asset exchange history info
    /// </summary>
    public class BybitExchangeHistoryEntry
    {
        /// <summary>
        /// Exchange id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Exchange rate
        /// </summary>
        [JsonProperty("exchange_rate")]
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// From asset
        /// </summary>
        [JsonProperty("from_coin")]
        public string FromAsset { get; set; } = string.Empty;
        /// <summary>
        /// From quantity
        /// </summary>
        [JsonProperty("from_amount")]
        public decimal FromQuantity { get; set; }
        /// <summary>
        /// From fee
        /// </summary>
        [JsonProperty("from_fee")]
        public decimal FromFee { get; set; }
        /// <summary>
        /// To asset
        /// </summary>
        [JsonProperty("to_coin")]
        public string ToAsset { get; set; } = string.Empty;
        /// <summary>
        /// To quantity
        /// </summary>
        [JsonProperty("to_amount")]
        public decimal ToQuantity { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreateTime { get; set; }
    }
}
