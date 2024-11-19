using CryptoExchange.Net.Objects.Options;
using System;

namespace Bybit.Net.Objects.Options
{
    /// <summary>
    /// Bybit socket API options
    /// </summary>
    public class BybitSocketApiOptions : SocketApiOptions
    {
        /// <summary>
        /// Interval at which to send a ping to the server
        /// </summary>
        public TimeSpan PingInterval { get; set; } = TimeSpan.FromSeconds(20);

        internal BybitSocketApiOptions Set(BybitSocketApiOptions targetOptions)
        {
            targetOptions = base.Set<BybitSocketApiOptions>(targetOptions);
            targetOptions.PingInterval = PingInterval;
            return targetOptions;
        }
    }
}
