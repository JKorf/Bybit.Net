using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Tier of account
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AccountLevel>))]
    public enum AccountLevel
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        [Map("No VIP", "VIP0")]
        Default,
        [Map("VIP-1")]
        Vip1,
        [Map("VIP-2")]
        Vip2,
        [Map("VIP-3")]
        Vip3,
        [Map("VIP-4")]
        Vip4,
        [Map("VIP-5")]
        Vip5,
        [Map("VIP-Supreme", "VIP99")]
        VipSupreme,
        [Map("PRO-1")]
        Pro1,
        [Map("PRO-2")]
        Pro2,
        [Map("PRO-3")]
        Pro3,
        [Map("PRO-4")]
        Pro4,
        [Map("PRO-5")]
        Pro5,
        [Map("PRO-6")]
        Pro6
    }
}
