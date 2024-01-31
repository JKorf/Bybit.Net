using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Api key info
    /// </summary>
    public class BybitApiKeyInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Key name
        /// </summary>
        public string Note { get; set; } = string.Empty;
        /// <summary>
        /// Api key
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;
        /// <summary>
        /// Secret (when creating new API key)
        /// </summary>
        public string? Secret { get; set; }
        /// <summary>
        /// Is read only
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool Readonly { get; set; }
        /// <summary>
        /// Allowed ip addresses
        /// </summary>
        public IEnumerable<string> Ips { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Remaining valid days
        /// </summary>
        [JsonProperty("deadlineDay")]
        public int DeadlineDays { get; set; }
        /// <summary>
        /// Expire time
        /// </summary>
        [JsonProperty("expiredAt")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ExpireTime { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("createdAt")]
        [JsonConverter(typeof(BoolConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Is unified margin account
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool Unified { get; set; }
        /// <summary>
        /// Is unified trade account
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool Uta { get; set; }
        /// <summary>
        /// User id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Inviter id
        /// </summary>
        public long? InviterId { get; set; }
        /// <summary>
        /// Vip level
        /// </summary>
        public string VipLevel { get; set; } = string.Empty;
        /// <summary>
        /// Market maker level
        /// </summary>
        [JsonProperty("mktMakerLevel")]
        public string MarketMakerLevel { get; set; } = string.Empty;
        /// <summary>
        /// Affiliate id
        /// </summary>
        public long AffiliateId { get; set; }
        /// <summary>
        /// Public key
        /// </summary>
        public string RsaPublicKey { get; set; } = string.Empty;
        /// <summary>
        /// Is master
        /// </summary>
        public bool IsMaster { get; set; }
        /// <summary>
        /// Permissions
        /// </summary>
        public BybitPermissions Permissions { get; set; } = null!;
    }

    /// <summary>
    /// Permission info
    /// </summary>
    public class BybitPermissions
    {
        /// <summary>
        /// Contract trade permissions
        /// </summary>
        public IEnumerable<string> ContractTrade { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Spot permissions
        /// </summary>
        public IEnumerable<string> Spot { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Wallet permissions
        /// </summary>
        public IEnumerable<string> Wallet { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Options permissions
        /// </summary>
        public IEnumerable<string> Options { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Derivatives permissions
        /// </summary>
        public IEnumerable<string> Derivatives { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Copy trading permissions
        /// </summary>
        public IEnumerable<string> CopyTrading { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Block trade permissions
        /// </summary>
        public IEnumerable<string> BlockTrade { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Exchange permissions
        /// </summary>
        public IEnumerable<string> Exchange { get; set; } = Array.Empty<string>();
        /// <summary>
        /// NFT permissions
        /// </summary>
        public IEnumerable<string> NFT { get; set; } = Array.Empty<string>();
    }
}
