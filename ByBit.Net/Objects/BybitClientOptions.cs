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
    public class BybitClientOptions : BaseRestClientOptions
    {
        /// <summary>
        /// Default options for the futures client
        /// </summary>
        public static BybitClientOptions Default { get; set; } = new BybitClientOptions();

        /// <summary>
        /// The default receive window for requests
        /// </summary>
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        private RestApiClientOptions _inverseFuturesApiOptions = new RestApiClientOptions("https://api.bybit.com/");
        public RestApiClientOptions InverseFuturesApiOptions
        {
            get => _inverseFuturesApiOptions;
            set => _inverseFuturesApiOptions.Copy(_inverseFuturesApiOptions, value);
        }

        private RestApiClientOptions _inversePerpetualApiOptions = new RestApiClientOptions("https://api.bybit.com/");
        public RestApiClientOptions InversePerpetualApiOptions
        {
            get => _inversePerpetualApiOptions;
            set => _inversePerpetualApiOptions.Copy(_inversePerpetualApiOptions, value);
        }

        private RestApiClientOptions _usdPerpetualApiOptions = new RestApiClientOptions("https://api.bybit.com/");
        public RestApiClientOptions UsdPerpetualApiOptions
        {
            get => _usdPerpetualApiOptions;
            set => _usdPerpetualApiOptions.Copy(_usdPerpetualApiOptions, value);
        }

        private RestApiClientOptions _spotApiOptions = new RestApiClientOptions("https://api.bybit.com/");
        public RestApiClientOptions SpotApiOptions
        {
            get => _spotApiOptions;
            set => _spotApiOptions.Copy(_spotApiOptions, value);
        }

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
            input.InverseFuturesApiOptions = new RestApiClientOptions(def.InverseFuturesApiOptions);
            input.InversePerpetualApiOptions = new RestApiClientOptions(def.InversePerpetualApiOptions);
            input.SpotApiOptions = new RestApiClientOptions(def.SpotApiOptions);
            input.UsdPerpetualApiOptions = new RestApiClientOptions(def.UsdPerpetualApiOptions);
        }
    }

    /// <summary>
    /// Options for the futures socket client
    /// </summary>
    public class BybitSocketClientOptions : BaseSocketClientOptions
    {
        /// <summary>
        /// Default options for the futures socket client
        /// </summary>
        public static BybitSocketClientOptions Default { get; set; } = new BybitSocketClientOptions();

        private BybitSocketApiClientOptions _inverseFuturesStreamsOptions = new BybitSocketApiClientOptions("wss://stream.bybit.com/realtime", "wss://stream.bybit.com/realtime");
        public BybitSocketApiClientOptions InverseFuturesStreamsOptions
        {
            get => _inverseFuturesStreamsOptions;
            set => _inverseFuturesStreamsOptions.Copy(_inverseFuturesStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _inversePerpetualStreamsOptions = new BybitSocketApiClientOptions("wss://stream.bybit.com/realtime", "wss://stream.bybit.com/realtime");
        public BybitSocketApiClientOptions InversePerpetualStreamsOptions
        {
            get => _inversePerpetualStreamsOptions;
            set => _inversePerpetualStreamsOptions.Copy(_inversePerpetualStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _usdPerpetualStreamsOptions = new BybitSocketApiClientOptions("wss://stream.bybit.com/realtime_public", "wss://stream.bybit.com/realtime_private");
        public BybitSocketApiClientOptions UsdPerpetualStreamsOptions
        {
            get => _usdPerpetualStreamsOptions;
            set => _usdPerpetualStreamsOptions.Copy(_usdPerpetualStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _spotStreamsOptions = new BybitSocketApiClientOptions("wss://stream.bybit.com/realtime", "wss://stream.bybit.com/realtime");
        public BybitSocketApiClientOptions SpotStreamsOptions
        {
            get => _spotStreamsOptions;
            set => _spotStreamsOptions.Copy(_spotStreamsOptions, value);
        }

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

            input.InverseFuturesStreamsOptions = new BybitSocketApiClientOptions(def.InverseFuturesStreamsOptions);
            input.InversePerpetualStreamsOptions = new BybitSocketApiClientOptions(def.InverseFuturesStreamsOptions);
            input.SpotStreamsOptions = new BybitSocketApiClientOptions(def.InverseFuturesStreamsOptions);
            input.UsdPerpetualStreamsOptions = new BybitSocketApiClientOptions(def.InverseFuturesStreamsOptions);
        }
    }

    public class BybitSocketApiClientOptions : ApiClientOptions
    {
        /// <summary>
        /// The base address for the authenticated websocket
        /// </summary>
        public string BaseAddressAuthenticated { get; set; }

        public BybitSocketApiClientOptions()
        {
        }

        public BybitSocketApiClientOptions(BybitSocketApiClientOptions baseOn): base(baseOn)
        {
            BaseAddressAuthenticated = BaseAddressAuthenticated;
        }

        public BybitSocketApiClientOptions(string baseAddress, string baseAddressAuthenticated): base(baseAddress)
        {
            BaseAddressAuthenticated = baseAddressAuthenticated;
        }

        public new void Copy<T>(T input, T def) where T : BybitSocketApiClientOptions
        {
            base.Copy(input, def);

            input.BaseAddressAuthenticated = def.BaseAddressAuthenticated;
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
