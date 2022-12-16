using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Spot.v1
{
    /// <summary>
    /// Borrow info
    /// </summary>
    public class BybitBorrowInfoV1
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Interest rate
        /// </summary>
        public decimal InterestRate { get; set; }
        /// <summary>
        /// Max loan quantity
        /// </summary>
        [JsonProperty("maxLoanAmount")]
        public decimal MaxBorrowQuantity { get; set; }
        /// <summary>
        /// Borrowable quantity
        /// </summary>
        [JsonProperty("loanAbleAmount")]
        public decimal BorrowableQuantity { get; set; }
    }
}
