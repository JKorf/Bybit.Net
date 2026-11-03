using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Repayment type of a UTA loan manual repay
    /// </summary>
    [JsonConverter(typeof(EnumConverter<RepaymentType>))]
    public enum RepaymentType
    {
        /// <summary>
        /// ["<c>ALL</c>"] Repay both fixed-rate and floating-rate liabilities, floating-rate first
        /// </summary>
        [Map("ALL")]
        All,
        /// <summary>
        /// ["<c>FIXED</c>"] Repay fixed-rate liabilities only
        /// </summary>
        [Map("FIXED")]
        Fixed,
        /// <summary>
        /// ["<c>FLEXIBLE</c>"] Repay floating-rate liabilities only
        /// </summary>
        [Map("FLEXIBLE")]
        Flexible
    }
}