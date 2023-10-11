using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    internal class BybitSubAccountWrapper
    {
        [JsonProperty("subMembers")]
        public List<BybitSubAccount> SubMembers { get; set; } = new List<BybitSubAccount>();
    }

    /// <summary>
    /// Sub account info
    /// </summary>
    public class BybitSubAccount
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("uid")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// Username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Account type
        /// </summary>
        [JsonProperty("memberType"), JsonConverter(typeof(EnumConverter))]
        public SubAccountType AccountType { get; set; }
        /// <summary>
        /// Account status
        /// </summary>
        [JsonProperty("status"), JsonConverter(typeof(EnumConverter))]
        public SubAccountStatus Status { get; set; }
        /// <summary>
        /// Account mode
        /// </summary>
        [JsonProperty("accountMode"), JsonConverter(typeof(EnumConverter))]
        public AccountMode? AccountMode { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        [JsonProperty("remark")]
        public string? Remark { get; set; }
    }
}
