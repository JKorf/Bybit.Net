using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Options
{
    /// <summary>
    /// Bybit options
    /// </summary>
    public class BybitOptions
    {
        /// <summary>
        /// Rest client options
        /// </summary>
        public BybitRestOptions Rest { get; set; } = new BybitRestOptions();

        /// <summary>
        /// Socket client options
        /// </summary>
        public BybitSocketOptions Socket { get; set; } = new BybitSocketOptions();

        /// <summary>
        /// Trade environment. Contains info about URL's to use to connect to the API. Use `BybitEnvironment` to swap environment, for example `Environment = BybitEnvironment.Live`
        /// </summary>
        public BybitEnvironment? Environment { get; set; }

        /// <summary>
        /// The api credentials used for signing requests.
        /// </summary>
        public ApiCredentials? ApiCredentials { get; set; }

        /// <summary>
        /// The DI service lifetime for the IBybitSocketClient
        /// </summary>
        public ServiceLifetime? SocketClientLifeTime { get; set; }
    }
}
