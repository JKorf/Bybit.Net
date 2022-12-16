using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Repay record
    /// </summary>
    public class BybitRepayRecord
    {
        /// <summary>
        /// Order id
        /// </summary>
        public string RepayMarginOrderId { get; set; } = string.Empty;
        /// <summary>
        /// Repay id
        /// </summary>
        public string RepayId { get; set; } = string.Empty;
        /// <summary>
        /// Account id
        /// </summary>
        public string AccountId { get; set; } = string.Empty;
        /// <summary>
        /// Asset repaid
        /// </summary>
        [JsonProperty("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Asset borrowed (v3)
        /// </summary>
        [JsonProperty("coin")]
        private string AssetV3
        {
            set
            {
                Asset = value;
            }
        }
        /// <summary>
        /// Quantity repaid
        /// </summary>
        [JsonProperty("repaidAmount")]
        public decimal RepaidQuantity { get; set; }
        /// <summary>
        /// Repay timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime RepayTime { get; set; }
        /// <summary>
        /// Transaction ids
        /// </summary>
        [JsonProperty("transactIds")]
        public IEnumerable<BybitRepayIds> TransactionIds { get; set; } = Array.Empty<BybitRepayIds>();
    }

    /// <summary>
    /// Repayment ids
    /// </summary>
    public class BybitRepayIds
    {
        /// <summary>
        /// Transaction id
        /// </summary>
        [JsonProperty("transactId")]
        public string TransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Serial number
        /// </summary>
        public string RepaidSerialNumber { get; set; } = string.Empty;
        /// <summary>
        /// Repaid quantity
        /// </summary>
        [JsonProperty("repaidAmount")]
        public decimal RepaidQuantity { get; set; }
        /// <summary>
        /// Repaid principal
        /// </summary>
        public decimal RepaidPrincipal { get; set; }
        /// <summary>
        /// Interest paid
        /// </summary>
        public decimal RepaidInterest { get; set; }
    }
}
