using CryptoExchange.Net.Converters.SystemTextJson;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Transferable
    /// </summary>
    [SerializationModel]
    public record BybitTransferable
    {
        /// <summary>
        /// Available transferable quantity, if multiple assets requested this is for the first asset
        /// </summary>
        [JsonPropertyName("availableWithdrawal")]
        public decimal Available { get; set; }
        /// <summary>
        /// Map of all requested assets and available values
        /// </summary>
        [JsonPropertyName("availableWithdrawalMap")]
        public Dictionary<string, decimal> AssetsAvailable { get; set; } = new Dictionary<string, decimal>();
    }
}
