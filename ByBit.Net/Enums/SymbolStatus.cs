using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Status of a symbol
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SymbolStatus>))]
    public enum SymbolStatus
    {
        /// <summary>
        /// ["<c>PreLaunch</c>"] Pre launch
        /// </summary>
        [Map("PreLaunch")]
        PreLaunch,
        /// <summary>
        /// ["<c>PendingOpen</c>"] [Futures] Pending open
        /// </summary>
        [Map("PendingOpen")]
        PendingOpen,
        /// <summary>
        /// ["<c>Trading</c>"] Currently trading
        /// </summary>
        [Map("Trading")]
        Trading,
        /// <summary>
        /// ["<c>Settling</c>"] Settling
        /// </summary>
        [Map("Settling")]
        Settling,
        /// <summary>
        /// ["<c>Delivering</c>"] Settling
        /// </summary>
        [Map("Delivering")]
        Delivering,
        /// <summary>
        /// ["<c>Closed</c>"] Closed
        /// </summary>
        [Map("Closed")]
        Closed
    }
}
