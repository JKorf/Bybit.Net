using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Small balance exchange status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SmallBalanceConvertStatus>))]
    public enum SmallBalanceConvertStatus
    {
        /// <summary>
        /// Initial
        /// </summary>
        [Map("init")]
        Init,
        /// <summary>
        /// Processing
        /// </summary>
        [Map("processing")]
        Processing,
        /// <summary>
        /// Success
        /// </summary>
        [Map("success")]
        Success,
        /// <summary>
        /// Failure
        /// </summary>
        [Map("failure")]
        Failure,
        /// <summary>
        /// Partially filled
        /// </summary>
        [Map("partial_fulfillment")]
        PartiallyFilled
    }
}
