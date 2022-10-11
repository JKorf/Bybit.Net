using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Borrow record
    /// </summary>
    public class BybitBorrowRecord
    {
        /// <summary>
        /// Borrow id
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Account id
        /// </summary>
        public string AccountId { get; set; } = string.Empty;
        /// <summary>
        /// Asset borrowed
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
        /// Borrowed quantity
        /// </summary>
        [JsonProperty("loanAmount")]
        public decimal LoanQuantity { get; set; }
        /// <summary>
        /// Outstanding principal
        /// </summary>
        public decimal LoanBalance { get; set; }
        /// <summary>
        /// Total interest
        /// </summary>
        [JsonProperty("interestAmount")]
        public decimal InterestQuantity { get; set; }
        /// <summary>
        /// Outstanding interest
        /// </summary>
        public decimal InterestBalance { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("createdTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public BorrowType Type { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public BorrowStatus Status { get; set; }
    }
}
