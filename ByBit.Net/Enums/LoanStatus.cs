using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Loan status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<LoanStatus>))]
    public enum LoanStatus
    {
        /// <summary>
        /// Fully repaid manually
        /// </summary>
        [Map("1")]
        FullyRepaidManually,
        /// <summary>
        /// Fully repaid by liquidation
        /// </summary>
        [Map("2")]
        FullyRepaidByLiquidation
    }
}
