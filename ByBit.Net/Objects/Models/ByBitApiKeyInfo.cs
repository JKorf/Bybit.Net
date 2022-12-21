using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Api key info
    /// </summary>
    public class ByBitApiKeyInfo
    {
        /// <summary>
        /// The api key
        /// </summary>
        [JsonProperty("api_key")]
        public string Apikey { get; set; } = string.Empty;
        /// <summary>
        /// Type of key
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// Inviter id
        /// </summary>
        [JsonProperty("inviter_id")]
        public long InviterId { get; set; }
        /// <summary>
        /// IP whitelist
        /// </summary>
        [JsonProperty("ips")]
        public IEnumerable<string> IpWhitelist { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Notes
        /// </summary>
        public string Note { get; set; } = string.Empty;
        /// <summary>
        /// Key permissions
        /// </summary>
        public IEnumerable<string> Permissions { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Expiry time
        /// </summary>
        [JsonProperty("expired_at")]
        public DateTime? ExpireTime { get; set; }
        /// <summary>
        /// Is readonly key
        /// </summary>
        [JsonProperty("read_only")]
        public bool Readonly { get; set; }
        /// <summary>
        /// Vip Level
        /// </summary>
        [JsonProperty("vip_level")]
        public string VipLevel { get; set; } = string.Empty;
        /// <summary>
        /// Market Maker Level
        /// </summary>
        [JsonProperty("mkt_maker_level")]
        public int MarketMakerLevel { get; set; }
        /// <summary>
        /// Affiliate Id
        /// </summary>
        [JsonProperty("affiliate_id")]
        public long AffiliateId { get; set; }
    }
}
