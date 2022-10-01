using Newtonsoft.Json;
using Bybit.Net.Converters;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Borrow info
    /// </summary>
    public class BybitBorrowInfoV3
    {
        /// <summary>
        /// Asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Interest rate
        /// </summary>
        [JsonProperty("interestRate"), JsonConverter(typeof(DecimalJsonConverter))]
        public decimal InterestRate { get; set; }
        /// <summary>
        /// Max loan quantity
        /// </summary>
        [JsonProperty("loanAbleAmount"), JsonConverter(typeof(DecimalJsonConverter))]
        public decimal MaxBorrowQuantity { get; set; }
        /// <summary>
        /// Borrowable quantity
        /// </summary>
        [JsonProperty("maxLoanAmount"), JsonConverter(typeof(DecimalJsonConverter))]
        public decimal BorrowableQuantity { get; set; }
    }
}
