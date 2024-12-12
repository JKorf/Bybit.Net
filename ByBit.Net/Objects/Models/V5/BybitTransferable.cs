using CryptoExchange.Net.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
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
        [JsonProperty("availableWithdrawal")]
        public decimal Available { get; set; }
    }
}
