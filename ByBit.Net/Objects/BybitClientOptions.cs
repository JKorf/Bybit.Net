using Bybit.Net.Clients.Socket;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;


namespace Bybit.Net.Objects
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
    /// Options for the Bybit futures client
    /// </summary>
    public class BybitClientFuturesOptions : BybitClientOptionsBase
    {
        /// <summary>
        /// Default options for the futures client
        /// </summary>
        public static BybitClientFuturesOptions Default { get; set; } = new BybitClientFuturesOptions()
        {
            BaseAddress = "https://api.bybit.com/",
            RateLimiters = new List<IRateLimiter>
            {
                new RateLimiter() // TODO
            }
        };

        /// <summary>
        /// ctor
        /// </summary>
        public BybitClientFuturesOptions()
        {
            if (Default == null)
                return;

            Copy(this, Default);
        }
    }

    /// <summary>
    /// Options for the futures socket client
    /// </summary>
    public class BybitSocketClientFuturesOptions : SocketClientOptions
    {
        /// <summary>
        /// Default options for the futures socket client
        /// </summary>
        public static BybitSocketClientFuturesOptions Default { get; set; } = new BybitSocketClientFuturesOptions()
        {
            BaseAddress = "wss://stream.bybit.com/realtime"
        };

        /// <summary>
        /// ctor
        /// </summary>
        public BybitSocketClientFuturesOptions()
        {
            if (Default == null)
                return;

            Copy(this, Default);
        }
    }

    /// <summary>
    /// Options for the futures symbol order book
    /// </summary>
    public class BybitFuturesSymbolOrderBookOptions : OrderBookOptions
    {
        public BybitSocketClientCoinFutures? SocketClient { get; set; }
    }
}
