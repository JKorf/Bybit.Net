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

        internal BybitSocketApiOptions Copy()
        {
            var result = Copy<BybitSocketApiOptions>();
            result.PingInterval = PingInterval;
            return result;
        }
    }
}
