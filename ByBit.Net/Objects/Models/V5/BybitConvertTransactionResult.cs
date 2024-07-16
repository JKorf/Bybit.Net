using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Transaction info
    /// </summary>
    public record BybitConvertTransactionResult
    {
        /// <summary>
        /// Quote transaction id
        /// </summary>
        [JsonProperty("quoteTxId")]
        public string QuoteTransactionId { get; set; } = string.Empty;
        /// <summary>
        /// Convert status
        /// </summary>
        [JsonProperty("exchangeStatus"), JsonConverter(typeof(EnumConverter))]
        public ConvertTransactionStatus Status { get; set; }
    }
}
