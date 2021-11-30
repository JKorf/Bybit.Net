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

    public class BybitSocketSubClientOptions: SubClientOptions
    {
        /// <summary>
        /// The base address for the authenticated websocket
        /// </summary>
        public string BaseAddressAuthenticated { get; set; }

        public new void Copy<T>(T input, T def) where T : BybitSocketSubClientOptions
        {
            base.Copy(input, def);

            input.BaseAddressAuthenticated = def.BaseAddressAuthenticated;
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
            OptionsInverseFutures = new BybitSocketSubClientOptions
            {
                BaseAddress = "wss://stream.bybit.com/realtime",
                BaseAddressAuthenticated = "wss://stream.bybit.com/realtime"
            },
            OptionsInversePerpetual = new BybitSocketSubClientOptions
            {
                BaseAddress = "wss://stream.bybit.com/realtime",
                BaseAddressAuthenticated = "wss://stream.bybit.com/realtime"
            },
            OptionsUsdPerpetual = new BybitSocketSubClientOptions
            {
                BaseAddress = "wss://stream.bybit.com/realtime_public",
                BaseAddressAuthenticated = "wss://stream.bybit.com/realtime_private"
            },
            OptionsSpot = new BybitSocketSubClientOptions
            {
                BaseAddress = "wss://stream.bybit.com/realtime",
                BaseAddressAuthenticated = "wss://stream.bybit.com/realtime"
            }
        };

        public BybitSocketSubClientOptions OptionsInverseFutures { get; set; }
        public BybitSocketSubClientOptions OptionsInversePerpetual { get; set; }
        public BybitSocketSubClientOptions OptionsUsdPerpetual { get; set; }
        public BybitSocketSubClientOptions OptionsSpot { get; set; }

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

            input.OptionsInverseFutures = new BybitSocketSubClientOptions();
            def.OptionsInverseFutures.Copy(input.OptionsInverseFutures, def.OptionsInverseFutures);

            input.OptionsInversePerpetual = new BybitSocketSubClientOptions();
            def.OptionsInversePerpetual.Copy(input.OptionsInversePerpetual, def.OptionsInversePerpetual);

            input.OptionsUsdPerpetual = new BybitSocketSubClientOptions();
            def.OptionsUsdPerpetual.Copy(input.OptionsUsdPerpetual, def.OptionsUsdPerpetual);

            input.OptionsSpot = new BybitSocketSubClientOptions();
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
