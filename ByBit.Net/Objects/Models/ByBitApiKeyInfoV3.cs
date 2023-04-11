using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Api key info
    /// https://bybit-exchange.github.io/docs/account-asset/apikey-info
    /// </summary>
    public class ByBitApiKeyInfoV3
    {
        /// <summary>
        /// Internal Bybit ID of ApiKey
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Remark stored on the ApiKey
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// The api key
        /// </summary>
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; } = string.Empty;

        /// <summary>
        /// Read/Write or ReadOnly
        /// </summary>
        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Key permissions dictionary
        /// </summary>
        [JsonProperty("permissions")]
        public Dictionary<string, string[]?> Permissions { get; set; } = new();

        /// <summary>
        /// IP whitelist
        /// </summary>
        [JsonProperty("ips")]
        public IEnumerable<string> IpWhitelist { get; set; } = Array.Empty<string>();
        
        /// <summary>
        /// Type of key
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The remaining valid days of api key. Only for those api key with no IP bound or the password has been changed
        /// </summary>
        [JsonProperty("deadlineDay")]
        public int DeadlineDay { get; set; }

        /// <summary>
        /// The expiry day of the api key. Only for those api key with no IP bound or the password has been changed
        /// </summary>
        [JsonProperty("expiredAt")]
        public DateTime? ExpiredAt { get; set; }

        /// <summary>
        /// The create day of the api key
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Whether the account to which the api key belongs is a unified account. 0：regular account; 1：unified margin account
        /// </summary>
        [JsonProperty("unified")]
        public int Unified { get; set; }

        /// <summary>
        /// Whether the account to which the account upgrade to unified trade account. 0：regular account; 1：unified trade account
        /// </summary>
        [JsonProperty("uta")]
        public int UnifiedTradeAccount { get; set; }

        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("userID")]
        public long UserId { get; set; }

        /// <summary>
        /// Inviter ID (the UID of the account which invited this account to the platform)
        /// </summary>
        [JsonProperty("inviterID")]
        public long InviterId { get; set; }

        /// <summary>
        /// Vip Level
        /// </summary>
        [JsonProperty("vipLevel")]
        public string VipLevel { get; set; } = string.Empty;

        /// <summary>
        /// Market Maker Level
        /// </summary>
        [JsonProperty("mktMakerLevel")]
        public int MarketMakerLevel { get; set; }

        /// <summary>
        /// Affiliate Id
        /// </summary>
        [JsonProperty("affiliateID")]
        public long AffiliateId { get; set; }

        /// <summary>
        /// Rsa public key
        /// </summary>
        [JsonProperty("rsaPublicKey")]
        public string RsaPublicKey { get; set; } = string.Empty;

        /// <summary>
        /// If this api key belongs to the master account or not
        /// </summary>
        [JsonProperty("isMaster")]
        public bool IsMaster { get; set; }
    }
}
