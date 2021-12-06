using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Transfer type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum TransferType
    {
        /// <summary>
        /// In transfer
        /// </summary>
        [Map("IN")]
        In,
        /// <summary>
        /// Out transfer
        /// </summary>
        [Map("OUT")]
        Out
    }
}
