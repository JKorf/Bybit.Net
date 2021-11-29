using Bybit.Net.Clients.Socket;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;


namespace Bybit.Net.Objects
{
    /// <summary>
    /// Options for the binance client
    /// </summary>
    public class BybitClientOptions : RestClientOptions
    {
        /// <summary>
        /// Default options for the futures client
        /// </summary>
        public static BybitClientOptions Default { get; set; } = new BybitClientOptions()
        {
            OptionsInverseFutures = new RestSubClientOptions
            {
                BaseAddress = "https://api.bybit.com/"
            },
            OptionsInversePerpetual = new RestSubClientOptions
            {
                BaseAddress = "https://api.bybit.com/"
            },
            OptionsUsdPerpetual = new RestSubClientOptions
            {
                BaseAddress = "https://api.bybit.com/"
            },
            OptionsSpot = new RestSubClientOptions
            {
                BaseAddress = "https://api.bybit.com/"
            }
        };

        /// <summary>
        /// The default receive window for requests
        /// </summary>
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        public RestSubClientOptions OptionsInverseFutures { get; set; }
        public RestSubClientOptions OptionsInversePerpetual { get; set; }
        public RestSubClientOptions OptionsUsdPerpetual { get; set; }
        public RestSubClientOptions OptionsSpot { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public BybitClientOptions()
        {
            if (Default == null)
                return;

            Copy(this, Default);
        }

        /// <summary>
        /// Copy the values of the def to the input
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="def"></param>
        public new void Copy<T>(T input, T def) where T : BybitClientOptions
        {
            base.Copy(input, def);

            input.ReceiveWindow = def.ReceiveWindow;

            input.OptionsInverseFutures = new RestSubClientOptions();
            def.OptionsInverseFutures.Copy(input.OptionsInverseFutures, def.OptionsInverseFutures);

            input.OptionsInversePerpetual = new RestSubClientOptions();
            def.OptionsInversePerpetual.Copy(input.OptionsInversePerpetual, def.OptionsInversePerpetual);

            input.OptionsUsdPerpetual = new RestSubClientOptions();
            def.OptionsUsdPerpetual.Copy(input.OptionsUsdPerpetual, def.OptionsUsdPerpetual);

            input.OptionsSpot = new RestSubClientOptions();
            def.OptionsSpot.Copy(input.OptionsSpot, def.OptionsSpot);
        }
    }

    /// <summary>
    /// Options for the futures socket client
    /// </summary>
    public class BybitSocketClientOptions : SocketClientOptions
    {
        /// <summary>
        /// Default options for the futures socket client
        /// </summary>
        public static BybitSocketClientOptions Default { get; set; } = new BybitSocketClientOptions()
        {
            OptionsInverseFutures = new SocketSubClientOptions
            {
                BaseAddress = "wss://stream.bybit.com/realtime"
            },
            OptionsInversePerpetual = new SocketSubClientOptions
            {
                BaseAddress = "wss://stream.bybit.com/realtime"
            },
            OptionsUsdPerpetual = new SocketSubClientOptions
            {
                BaseAddress = "wss://stream.bybit.com/realtime"
            },
            OptionsSpot = new SocketSubClientOptions
            {
                BaseAddress = "wss://stream.bybit.com/realtime"
            }
        };

        public SocketSubClientOptions OptionsInverseFutures { get; set; }
        public SocketSubClientOptions OptionsInversePerpetual { get; set; }
        public SocketSubClientOptions OptionsUsdPerpetual { get; set; }
        public SocketSubClientOptions OptionsSpot { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public BybitSocketClientOptions()
        {
            if (Default == null)
                return;

            Copy(this, Default);
        }

        /// <summary>
        /// Copy the values of the def to the input
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="def"></param>
        public new void Copy<T>(T input, T def) where T : BybitSocketClientOptions
        {
            base.Copy(input, def);

            input.OptionsInverseFutures = new SocketSubClientOptions();
            def.OptionsInverseFutures.Copy(input.OptionsInverseFutures, def.OptionsInverseFutures);

            input.OptionsInversePerpetual = new SocketSubClientOptions();
            def.OptionsInversePerpetual.Copy(input.OptionsInversePerpetual, def.OptionsInversePerpetual);

            input.OptionsUsdPerpetual = new SocketSubClientOptions();
            def.OptionsUsdPerpetual.Copy(input.OptionsUsdPerpetual, def.OptionsUsdPerpetual);

            input.OptionsSpot = new SocketSubClientOptions();
            def.OptionsSpot.Copy(input.OptionsSpot, def.OptionsSpot);
        }
    }

    /// <summary>
    /// Options for the futures symbol order book
    /// </summary>
    public class BybitFuturesSymbolOrderBookOptions : OrderBookOptions
    {
        public IBybitSocketClient? SocketClient { get; set; }
    }
}
