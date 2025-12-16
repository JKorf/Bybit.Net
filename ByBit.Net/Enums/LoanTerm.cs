using System.Text.Json.Serialization;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Loan term
    /// </summary>
    [JsonConverter(typeof(EnumConverter<LoanTerm>))]
    public enum LoanTerm
    {
        /// <summary>
        /// 7 days
        /// </summary>
        Days7,
        /// <summary>
        /// 14 days
        /// </summary>
        Days14,
        /// <summary>
        /// 30 days
        /// </summary>
        Days30,
        /// <summary>
        /// 90 days
        /// </summary>
        Days90,
        /// <summary>
        /// 180 days
        /// </summary>
        Days180
    }
}
