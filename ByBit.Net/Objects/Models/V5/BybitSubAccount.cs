using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    internal record BybitSubAccountWrapper
    {
        [JsonPropertyName("subMembers")]
        public List<BybitSubAccount> SubMembers { get; set; } = new List<BybitSubAccount>();
    }

    /// <summary>
    /// Sub account info
    /// </summary>
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
        [JsonPropertyName("memberType"), JsonConverter(typeof(EnumConverter))]
        public SubAccountType AccountType { get; set; }
        /// <summary>
        /// Account status
        /// </summary>
        [JsonPropertyName("status"), JsonConverter(typeof(EnumConverter))]
        public SubAccountStatus Status { get; set; }
        /// <summary>
        /// Account mode
        /// </summary>
        [JsonPropertyName("accountMode"), JsonConverter(typeof(EnumConverter))]
        public AccountMode? AccountMode { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        [JsonPropertyName("remark")]
        public string? Remark { get; set; }
    }
}
