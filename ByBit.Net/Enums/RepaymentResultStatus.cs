using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Result status of a UTA loan manual repay
    /// </summary>
    [JsonConverter(typeof(EnumConverter<RepaymentResultStatus>))]
    public enum RepaymentResultStatus
    {
        /// <summary>
        /// ["<c>P</c>"] Processing
        /// </summary>
        [Map("P")]
        Processing,
        /// <summary>
        /// ["<c>SU</c>"] Success
        /// </summary>
        [Map("SU")]
        Success,
        /// <summary>
        /// ["<c>FA</c>"] Failed
        /// </summary>
        [Map("FA")]
        Failed
    }
}