using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Loan type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<LoanType>))]
    public enum LoanType
    {
        /// <summary>
        /// Fixed term
        /// </summary>
        [Map("1")]
        FixedTerm,
        /// <summary>
        /// Flexible term
        /// </summary>
        [Map("2")]
        FlexibleTerm
    }
}
