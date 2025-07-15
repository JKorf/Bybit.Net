using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
