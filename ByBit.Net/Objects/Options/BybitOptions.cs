using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.SharedApis;

namespace Bybit.Net.Objects.Options
{
    /// <summary>
    /// Bybit options
    /// </summary>
    public class BybitOptions : LibraryOptions<BybitRestOptions, BybitSocketOptions, BybitCredentials, BybitEnvironment>
    {
        /// <summary>
        /// Options for Shared API usage
        /// </summary>
        public SharedApiOptions SharedApi { get; set; } = new();

    }
}
