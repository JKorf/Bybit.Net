using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Spot.v3
{
    /// <summary>
    /// Borrow order place responce
    /// </summary>
    public class BybitBorrowOrderV3
    {
        /// <summary>
        /// Borrow order transaction id
        /// </summary>
        [JsonProperty("transactId")]
        public decimal TransactionId { get; set; }
    }
}
