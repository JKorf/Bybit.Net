using Bybit.Net.Enums;
using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Api key info
    /// </summary>
    [SerializationModel]
    public record BybitApiKeyInfo
    {
        /// <summary>
        /// ["<c>id</c>"] Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>note</c>"] Key name
        /// </summary>
        [JsonPropertyName("note")]
        public string Note { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>apiKey</c>"] Api key
        /// </summary>
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>secret</c>"] Secret (when creating new API key)
        /// </summary>
        [JsonPropertyName("secret")]
        public string? Secret { get; set; }
        /// <summary>
        /// ["<c>readOnly</c>"] Is read only
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("readOnly")]
        public bool Readonly { get; set; }
        /// <summary>
        /// ["<c>ips</c>"] Allowed ip addresses
        /// </summary>
        [JsonPropertyName("ips")]
        public string[] Ips { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>deadlineDay</c>"] Remaining valid days
        /// </summary>
        [JsonPropertyName("deadlineDay")]
        public int DeadlineDays { get; set; }
        /// <summary>
        /// ["<c>expiredAt</c>"] Expire time
        /// </summary>
        [JsonPropertyName("expiredAt")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ExpireTime { get; set; }
        /// <summary>
        /// ["<c>createdAt</c>"] Creation time
        /// </summary>
        [JsonPropertyName("createdAt")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>unified</c>"] Is unified margin account
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("unified")]
        public bool Unified { get; set; }
        /// <summary>
        /// ["<c>uta</c>"] Is unified trade account
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("uta")]
        public bool Uta { get; set; }
        /// <summary>
        /// ["<c>userID</c>"] User id
        /// </summary>
        [JsonPropertyName("userID")]
        public long UserId { get; set; }
        /// <summary>
        /// ["<c>inviterID</c>"] Inviter id
        /// </summary>
        [JsonPropertyName("inviterID")]
        public long? InviterId { get; set; }
        /// <summary>
        /// ["<c>vipLevel</c>"] Vip level
        /// </summary>
        [JsonPropertyName("vipLevel")]
        public AccountLevel VipLevel { get; set; }
        /// <summary>
        /// ["<c>mktMakerLevel</c>"] Market maker level
        /// </summary>
        [JsonPropertyName("mktMakerLevel")]
        public string MarketMakerLevel { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>affiliateID</c>"] Affiliate id
        /// </summary>
        [JsonPropertyName("affiliateID")]
        public long AffiliateId { get; set; }
        /// <summary>
        /// ["<c>rsaPublicKey</c>"] Public key
        /// </summary>
        [JsonPropertyName("rsaPublicKey")]
        public string RsaPublicKey { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>isMaster</c>"] Is master
        /// </summary>
        [JsonPropertyName("isMaster")]
        public bool IsMaster { get; set; }

        /// <summary>
        /// ["<c>parentUid</c>"] Parent Uid, 0 if main account
        /// </summary>
        [JsonPropertyName("parentUid")]
        public string? ParentUid { get; set; }

        /// <summary>
        /// ["<c>kycLevel</c>"] Parent Uid, 0 if main account
        /// </summary>
        [JsonPropertyName("kycLevel")]
        public KycLevel? KycLevel { get; set; }

        /// <summary>
        /// ["<c>kycRegion</c>"] Parent Uid, 0 if main account
        /// </summary>
        [JsonPropertyName("kycRegion")]
        public string? KycRegion { get; set; }

        /// <summary>
        /// ["<c>type</c>"] The type of api key. 1ï¼špersonal, 2ï¼šconnected to the third-party app
        /// </summary>
        [JsonPropertyName("type")]
        public int ApiKeyType { get; set; }
        /// <summary>
        /// ["<c>permissions</c>"] Permissions
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
        /// ["<c>ContractTrade</c>"] Contract trade permissions
        /// </summary>
        [JsonPropertyName("ContractTrade")]
        public string[] ContractTrade { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>Spot</c>"] Spot permissions
        /// </summary>
        [JsonPropertyName("Spot")]
        public string[] Spot { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>Wallet</c>"] Wallet permissions
        /// </summary>
        [JsonPropertyName("Wallet")]
        public string[] Wallet { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>Options</c>"] Options permissions
        /// </summary>
        [JsonPropertyName("Options")]
        public string[] Options { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>Derivatives</c>"] Derivatives permissions
        /// </summary>
        [JsonPropertyName("Derivatives")]
        public string[] Derivatives { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>CopyTrading</c>"] Copy trading permissions
        /// </summary>
        [JsonPropertyName("CopyTrading")]
        public string[] CopyTrading { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>BlockTrade</c>"] Block trade permissions
        /// </summary>
        [JsonPropertyName("BlockTrade")]
        public string[] BlockTrade { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>Exchange</c>"] Exchange permissions
        /// </summary>
        [JsonPropertyName("Exchange")]
        public string[] Exchange { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>NFT</c>"] NFT permissions
        /// </summary>
        [JsonPropertyName("NFT")]
        public string[] NFT { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>Affiliate</c>"] Affiliate permissions
        /// </summary>
        [JsonPropertyName("Affiliate")]
        public string[] Affiliate { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>Earn</c>"] Earn permissions
        /// </summary>
        [JsonPropertyName("Earn")]
        public string[] Earn { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>FiatP2P</c>"] Fiat P2P permissions
        /// </summary>
        [JsonPropertyName("FiatP2P")]
        public string[] FiatP2P { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>FiatConvertBroker</c>"] Fiat convert broker permissions
        /// </summary>
        [JsonPropertyName("FiatConvertBroker")]
        public string[] FiatConvertBroker { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>FiatBitPay</c>"] Fiat bit pay permissions
        /// </summary>
        [JsonPropertyName("FiatBitPay")]
        public string[] FiatBitPay { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>BitCard</c>"] Bit card permissions
        /// </summary>
        [JsonPropertyName("BitCard")]
        public string[] BitCard { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>ByXPost</c>"] ByX Post permissions
        /// </summary>
        [JsonPropertyName("ByXPost")]
        public string[] ByXPost { get; set; } = Array.Empty<string>();
    }
}
