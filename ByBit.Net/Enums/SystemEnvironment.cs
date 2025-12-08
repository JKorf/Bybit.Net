using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// System environment
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SystemEnvironment>))]
    public enum SystemEnvironment
    {
        /// <summary>
        /// Production
        /// </summary>
        [Map("1")]
        Production,
        /// <summary>
        /// Production demo services
        /// </summary>
        [Map("2")]
        DemoServices
    }
}
