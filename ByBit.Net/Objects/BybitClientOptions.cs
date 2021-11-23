using Bybit.Net.Clients.Socket;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;


namespace ByBit.Net.Objects
{
    /// <summary>
    /// Options for the binance client
    /// </summary>
    public class BybitClientOptionsBase : RestClientOptions
    {
        /// <summary>
        /// The default receive window for requests
        /// </summary>
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Copy the values of the def to the input
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="def"></param>
        public new void Copy<T>(T input, T def) where T : BybitClientOptionsBase
        {
            base.Copy(input, def);

            input.ReceiveWindow = def.ReceiveWindow;
        }
    }

    /// <summary>
    /// Options for the Bybit inverse perpetual client
    /// </summary>
    public class BybitClientInversePerpetualOptions : BybitClientOptionsBase
    {
        /// <summary>
        /// Default options for the spot client
        /// </summary>
        public static BybitClientInversePerpetualOptions Default { get; set; } = new BybitClientInversePerpetualOptions()
        {
            BaseAddress = "https://api.bybit.com",
            RateLimiters = new List<IRateLimiter>
            {
                new RateLimiter() // TODO
            }
        };

        /// <summary>
        /// ctor
        /// </summary>
        public BybitClientInversePerpetualOptions()
        {
            if (Default == null)
                return;

            Copy(this, Default);
        }
    }

    /// <summary>
    /// Options for the inverse perpetual socket client
    /// </summary>
    public class BybitSocketClientInversePerpetualOptions : SocketClientOptions
    {
        /// <summary>
        /// Default options for the spot client
        /// </summary>
        public static BybitSocketClientInversePerpetualOptions Default { get; set; } = new BybitSocketClientInversePerpetualOptions()
        {
            BaseAddress = "wss://stream.bybit.com/realtime"
        };

        /// <summary>
        /// ctor
        /// </summary>
        public BybitSocketClientInversePerpetualOptions()
        {
            if (Default == null)
                return;

            Copy(this, Default);
        }
    }

    /// <summary>
    /// Options for the binance client
    /// </summary>
    public class BybitInversePerpetualSymbolOrderBookOptions : OrderBookOptions
    {
        public BybitSocketClientInversePerpetual? SocketClient { get; set; }
    }
}
