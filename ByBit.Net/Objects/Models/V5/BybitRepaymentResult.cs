using Bybit.Net.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// UTA loan manual repay result
    /// </summary>
    [SerializationModel]
    public record BybitRepaymentResult
    {
        /// <summary>
        /// ["<c>resultStatus</c>"] Result status
        /// </summary>
        [JsonPropertyName("resultStatus")]
        public RepaymentResultStatus ResultStatus { get; set; }
    }
}