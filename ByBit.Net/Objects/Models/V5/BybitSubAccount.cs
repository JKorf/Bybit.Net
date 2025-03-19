using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    [SerializationModel]
    internal record BybitSubAccountWrapper
    {
        [JsonPropertyName("subMembers")]
        public BybitSubAccount[] SubMembers { get; set; } = [];
    }

    /// <summary>
    /// Sub account info
    /// </summary>
    [SerializationModel]
    public record BybitSubAccount
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonPropertyName("uid")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// Username
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Account type
        /// </summary>
        [JsonPropertyName("memberType")]
        public SubAccountType AccountType { get; set; }
        /// <summary>
        /// Account status
        /// </summary>
        [JsonPropertyName("status")]
        public SubAccountStatus Status { get; set; }
        /// <summary>
        /// Account mode
        /// </summary>
        [JsonPropertyName("accountMode")]
        public AccountMode? AccountMode { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        [JsonPropertyName("remark")]
        public string? Remark { get; set; }
    }
}
