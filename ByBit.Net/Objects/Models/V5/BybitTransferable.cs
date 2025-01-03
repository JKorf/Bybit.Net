using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Transferable
    /// </summary>
    public record BybitTransferable
    {
        /// <summary>
        /// Available transferable quantity
        /// </summary>
        [JsonPropertyName("availableWithdrawal")]
        public decimal Available { get; set; }
    }
}
