﻿using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Insurance pool info
    /// </summary>
    public record BybitInsurance
    {
        /// <summary>
        /// The asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Symbols
        /// </summary>
        [JsonPropertyName("symbols")]
        public string Symbols { get; set; } = string.Empty;
        /// <summary>
        /// Balance
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        [JsonPropertyName("value")]
        public decimal Value { get; set; }
    }
}
