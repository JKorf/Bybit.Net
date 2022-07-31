using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using System;


namespace Bybit.Net.Objects
{
    /// <summary>
    /// Options for the Bybit client
    /// </summary>
    public class BybitClientOptions : BaseRestClientOptions
    {
        /// <summary>
        /// Default options for the Bybit client
        /// </summary>
        public static BybitClientOptions Default { get; set; } = new BybitClientOptions();

        /// <summary>
        /// A referer, will be sent in the x-referer header
        /// </summary>
        public string? Referer { get; set; } = "JKorf";

        /// <summary>
        /// The default receive window for requests
        /// </summary>
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        private RestApiClientOptions _inverseFuturesApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.InverseFuturesRestClientAddress);
        /// <summary>
        /// Inverse futures API options
        /// </summary>
        public RestApiClientOptions InverseFuturesApiOptions
        {
            get => _inverseFuturesApiOptions;
            set => _inverseFuturesApiOptions = new RestApiClientOptions(_inverseFuturesApiOptions, value);
        }

        private RestApiClientOptions _inversePerpetualApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.InversePerpetualRestClientAddress);
        /// <summary>
        /// Inverse perpetual API options
        /// </summary>
        public RestApiClientOptions InversePerpetualApiOptions
        {
            get => _inversePerpetualApiOptions;
            set => _inversePerpetualApiOptions = new RestApiClientOptions(_inversePerpetualApiOptions, value);
        }

        private RestApiClientOptions _usdPerpetualApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.UsdPerpetualRestClientAddress);
        /// <summary>
        /// Usd perpetual API options
        /// </summary>
        public RestApiClientOptions UsdPerpetualApiOptions
        {
            get => _usdPerpetualApiOptions;
            set => _usdPerpetualApiOptions = new RestApiClientOptions(_usdPerpetualApiOptions, value);
        }

        private RestApiClientOptions _spotApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.SpotRestClientAddress);
        /// <summary>
        /// Spot API options
        /// </summary>
        public RestApiClientOptions SpotApiOptions
        {
            get => _spotApiOptions;
            set => _spotApiOptions = new RestApiClientOptions(_spotApiOptions, value);
        }

        private RestApiClientOptions _copyTradingApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.SpotRestClientAddress);
        /// <summary>
        /// Copy trading API options
        /// </summary>
        public RestApiClientOptions CopyTradingApiOptions
        {
            get => _copyTradingApiOptions;
            set => _copyTradingApiOptions = new RestApiClientOptions(_copyTradingApiOptions, value);
        }

        /// <summary>
        /// ctor
        /// </summary>
        public BybitClientOptions() : this(Default)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseOn">Base the new options on other options</param>
        internal BybitClientOptions(BybitClientOptions baseOn) : base(baseOn)
        {
            if (baseOn == null)
                return;

            ReceiveWindow = baseOn.ReceiveWindow;
            Referer = baseOn.Referer;

            InverseFuturesApiOptions = new RestApiClientOptions(baseOn.InverseFuturesApiOptions, null);
            InversePerpetualApiOptions = new RestApiClientOptions(baseOn.InversePerpetualApiOptions, null);
            SpotApiOptions = new RestApiClientOptions(baseOn.SpotApiOptions, null);
            UsdPerpetualApiOptions = new RestApiClientOptions(baseOn.UsdPerpetualApiOptions, null);
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
        public static BybitSocketClientOptions Default { get; set; } = new BybitSocketClientOptions()
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        private BybitSocketApiClientOptions _inverseFuturesStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.InverseFuturesSocketClientAddress, BybitApiAddresses.Default.InverseFuturesSocketClientAddress);
        /// <summary>
        /// Inverse futures streams options
        /// </summary>
        public BybitSocketApiClientOptions InverseFuturesStreamsOptions
        {
            get => _inverseFuturesStreamsOptions;
            set => _inverseFuturesStreamsOptions = new BybitSocketApiClientOptions(_inverseFuturesStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _inversePerpetualStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.InversePerpetualSocketClientAddress, BybitApiAddresses.Default.InversePerpetualSocketClientAddress);
        /// <summary>
        /// Inverse perpetual streams options
        /// </summary>
        public BybitSocketApiClientOptions InversePerpetualStreamsOptions
        {
            get => _inversePerpetualStreamsOptions;
            set => _inversePerpetualStreamsOptions = new BybitSocketApiClientOptions(_inversePerpetualStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _usdPerpetualStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.UsdPerpetualPublicSocketClientAddress, BybitApiAddresses.Default.UsdPerpetualPrivateSocketClientAddress);
        /// <summary>
        /// Usd perpetual streams options
        /// </summary>
        public BybitSocketApiClientOptions UsdPerpetualStreamsOptions
        {
            get => _usdPerpetualStreamsOptions;
            set => _usdPerpetualStreamsOptions = new BybitSocketApiClientOptions(_usdPerpetualStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _spotStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.SpotPublicSocketClientAddress, BybitApiAddresses.Default.SpotPrivateSocketClientAddress);
        /// <summary>
        /// Spot streams options
        /// </summary>
        public BybitSocketApiClientOptions SpotStreamsOptions
        {
            get => _spotStreamsOptions;
            set => _spotStreamsOptions = new BybitSocketApiClientOptions(_spotStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _copyTradingStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.CopyTradingSocketClientAddress, BybitApiAddresses.Default.CopyTradingSocketClientAddress);
        /// <summary>
        /// Copy trading streams options
        /// </summary>
        public BybitSocketApiClientOptions CopyTradingStreamsOptions
        {
            get => _copyTradingStreamsOptions;
            set => _copyTradingStreamsOptions = new BybitSocketApiClientOptions(_copyTradingStreamsOptions, value);
        }

        /// <summary>
        /// Interval at which to send a ping to the server
        /// </summary>
        public TimeSpan PingInterval { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public BybitSocketClientOptions() : this(Default)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseOn">Base the new options on other options</param>
        internal BybitSocketClientOptions(BybitSocketClientOptions baseOn) : base(baseOn)
        {
            if (baseOn == null)
                return;

            PingInterval = baseOn.PingInterval;

            InverseFuturesStreamsOptions = new BybitSocketApiClientOptions(baseOn.InverseFuturesStreamsOptions, null);
            InversePerpetualStreamsOptions = new BybitSocketApiClientOptions(baseOn.InversePerpetualStreamsOptions, null);
            SpotStreamsOptions = new BybitSocketApiClientOptions(baseOn.SpotStreamsOptions, null);
            UsdPerpetualStreamsOptions = new BybitSocketApiClientOptions(baseOn.UsdPerpetualStreamsOptions, null);
        }
    }

    /// <summary>
    /// Bybit socket API client options
    /// </summary>
    public class BybitSocketApiClientOptions : ApiClientOptions
    {
        /// <summary>
        /// The base address for the authenticated websocket
        /// </summary>
        public string BaseAddressAuthenticated { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
#pragma warning disable 8618
        public BybitSocketApiClientOptions()
        {
        }
#pragma warning restore

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseOn"></param>
        /// <param name="newValues"></param>
        internal BybitSocketApiClientOptions(BybitSocketApiClientOptions baseOn, BybitSocketApiClientOptions? newValues) : base(baseOn, newValues)
        {
            BaseAddressAuthenticated = newValues?.BaseAddressAuthenticated ?? baseOn.BaseAddressAuthenticated;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="baseAddressAuthenticated"></param>
        internal BybitSocketApiClientOptions(string baseAddress, string baseAddressAuthenticated): base(baseAddress)
        {
            BaseAddressAuthenticated = baseAddressAuthenticated;
        }
    }

    /// <summary>
    /// Options for the futures symbol order book
    /// </summary>
    public class BybitSymbolOrderBookOptions : OrderBookOptions
    {
        /// <summary>
        /// After how much time we should consider the connection dropped if no data is received for this time after the initial subscriptions
        /// </summary>
        public TimeSpan? InitialDataTimeout { get; set; }
        /// <summary>
        /// The client to use for the socket connection. When using the same client for multiple order books the connection can be shared.
        /// </summary>
        public IBybitSocketClient? SocketClient { get; set; }

        /// <summary>
        /// The limit of entries in the order book, either 25 or 200
        /// </summary>
        public int? Limit { get; set; }
    }
}
