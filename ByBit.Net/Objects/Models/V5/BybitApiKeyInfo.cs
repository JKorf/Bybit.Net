using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Api key info
    /// </summary>
    [SerializationModel]
    public record BybitApiKeyInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Key name
        /// </summary>
        [JsonPropertyName("note")]
        public string Note { get; set; } = string.Empty;
        /// <summary>
        /// Api key
        /// </summary>
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; } = string.Empty;
        /// <summary>
        /// Secret (when creating new API key)
        /// </summary>
        [JsonPropertyName("secret")]
        public string? Secret { get; set; }
        /// <summary>
        /// Is read only
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("readOnly")]
        public bool Readonly { get; set; }
        /// <summary>
        /// Allowed ip addresses
        /// </summary>
        [JsonPropertyName("ips")]
        public string[] Ips { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Remaining valid days
        /// </summary>
        [JsonPropertyName("deadlineDay")]
        public int DeadlineDays { get; set; }
        /// <summary>
        /// Expire time
        /// </summary>
        [JsonPropertyName("expiredAt")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ExpireTime { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonPropertyName("createdAt")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Is unified margin account
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("unified")]
        public bool Unified { get; set; }
        /// <summary>
        /// Is unified trade account
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("uta")]
        public bool Uta { get; set; }
        /// <summary>
        /// User id
        /// </summary>
        [JsonPropertyName("userID")]
        public long UserId { get; set; }
        /// <summary>
        /// Inviter id
        /// </summary>
        [JsonPropertyName("inviterID")]
        public long? InviterId { get; set; }
        /// <summary>
        /// Vip level
        /// </summary>
        [JsonPropertyName("vipLevel")]
        public AccountLevel VipLevel { get; set; }
        /// <summary>
        /// Market maker level
        /// </summary>
        [JsonPropertyName("mktMakerLevel")]
        public string MarketMakerLevel { get; set; } = string.Empty;
        /// <summary>
        /// Affiliate id
        /// </summary>
        [JsonPropertyName("affiliateID")]
        public long AffiliateId { get; set; }
        /// <summary>
        /// Public key
        /// </summary>
        [JsonPropertyName("rsaPublicKey")]
        public string RsaPublicKey { get; set; } = string.Empty;
        /// <summary>
        /// Is master
        /// </summary>
        [JsonPropertyName("isMaster")]
        public bool IsMaster { get; set; }

        /// <summary>
        /// Parent Uid, 0 if main account
        /// </summary>
        [JsonPropertyName("parentUid")]
        public string? ParentUid { get; set; }

        /// <summary>
        /// Parent Uid, 0 if main account
        /// </summary>
        [JsonPropertyName("kycLevel")]
        public KycLevel? KycLevel { get; set; }

        /// <summary>
        /// Parent Uid, 0 if main account
        /// </summary>
        [JsonPropertyName("kycRegion")]
        public string? KycRegion { get; set; }

        /// <summary>
        /// The type of api key. 1：personal, 2：connected to the third-party app
        /// </summary>
        [JsonPropertyName("type")]
        public int ApiKeyType { get; set; }
        /// <summary>
        /// Permissions
        /// </summary>
        [JsonPropertyName("permissions")]
        public BybitPermissions Permissions { get; set; } = null!;
    }

    /// <summary>
    /// Permission info
    /// </summary>
    [SerializationModel]
    public record BybitPermissions
    {
        /// <summary>
        /// Contract trade permissions
        /// </summary>
        [JsonPropertyName("ContractTrade")]
        public string[] ContractTrade { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Spot permissions
        /// </summary>
        [JsonPropertyName("Spot")]
        public string[] Spot { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Wallet permissions
        /// </summary>
        [JsonPropertyName("Wallet")]
        public string[] Wallet { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Options permissions
        /// </summary>
        [JsonPropertyName("Options")]
        public string[] Options { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Derivatives permissions
        /// </summary>
        [JsonPropertyName("Derivatives")]
        public string[] Derivatives { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Copy trading permissions
        /// </summary>
        [JsonPropertyName("CopyTrading")]
        public string[] CopyTrading { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Block trade permissions
        /// </summary>
        [JsonPropertyName("BlockTrade")]
        public string[] BlockTrade { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Exchange permissions
        /// </summary>
        [JsonPropertyName("Exchange")]
        public string[] Exchange { get; set; } = Array.Empty<string>();
        /// <summary>
        /// NFT permissions
        /// </summary>
        [JsonPropertyName("NFT")]
        public string[] NFT { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Affiliate permissions
        /// </summary>
        [JsonPropertyName("Affiliate")]
        public string[] Affiliate { get; set; } = Array.Empty<string>();
    }
}
