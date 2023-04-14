using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects
{
    /// <summary>
    /// Options for the Bybit client
    /// </summary>
    public class BybitClientOptions : ClientOptions
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

        private RestApiClientOptions _copyTradingApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.CopyTradingRestClientAddress);
        /// <summary>
        /// Copy trading API options
        /// </summary>
        public RestApiClientOptions CopyTradingApiOptions
        {
            get => _copyTradingApiOptions;
            set => _copyTradingApiOptions = new RestApiClientOptions(_copyTradingApiOptions, value);
        }

        private RestApiClientOptions _derivativesApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.DerivativesRestClientAddress);
        /// <summary>
        /// Copy trading API options
        /// </summary>
        public RestApiClientOptions DerivativesApiOptions
        {
            get => _derivativesApiOptions;
            set => _derivativesApiOptions = new RestApiClientOptions(_derivativesApiOptions, value);
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
            DerivativesApiOptions = new RestApiClientOptions(baseOn.DerivativesApiOptions, null);
        }
    }

    /// <summary>
    /// Options for the futures socket client
    /// </summary>
    public class BybitSocketClientOptions : ClientOptions
    {
        /// <summary>
        /// Default options for the futures socket client
        /// </summary>
        public static BybitSocketClientOptions Default { get; set; } = new BybitSocketClientOptions();

        private BybitSocketApiClientOptions _inverseFuturesStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.InverseFuturesSocketClientAddress, BybitApiAddresses.Default.InverseFuturesSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Inverse futures streams options
        /// </summary>
        public BybitSocketApiClientOptions InverseFuturesStreamsOptions
        {
            get => _inverseFuturesStreamsOptions;
            set => _inverseFuturesStreamsOptions = new BybitSocketApiClientOptions(_inverseFuturesStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _inversePerpetualStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.InversePerpetualSocketClientAddress, BybitApiAddresses.Default.InversePerpetualSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Inverse perpetual streams options
        /// </summary>
        public BybitSocketApiClientOptions InversePerpetualStreamsOptions
        {
            get => _inversePerpetualStreamsOptions;
            set => _inversePerpetualStreamsOptions = new BybitSocketApiClientOptions(_inversePerpetualStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _usdPerpetualStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.UsdPerpetualPublicSocketClientAddress, BybitApiAddresses.Default.UsdPerpetualPrivateSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Usd perpetual streams options
        /// </summary>
        public BybitSocketApiClientOptions UsdPerpetualStreamsOptions
        {
            get => _usdPerpetualStreamsOptions;
            set => _usdPerpetualStreamsOptions = new BybitSocketApiClientOptions(_usdPerpetualStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _spotStreamsV1Options = new BybitSocketApiClientOptions(BybitApiAddresses.Default.SpotPublicSocketV1ClientAddress, BybitApiAddresses.Default.SpotPrivateSocketV1ClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Spot streams options version 1
        /// </summary>
        public BybitSocketApiClientOptions SpotStreamsV1Options
        {
            get => _spotStreamsV1Options;
            set => _spotStreamsV1Options = new BybitSocketApiClientOptions(_spotStreamsV1Options, value);
        }

        private BybitSocketApiClientOptions _spotStreamsV2Options = new BybitSocketApiClientOptions(BybitApiAddresses.Default.SpotPublicSocketV2ClientAddress, BybitApiAddresses.Default.SpotPrivateSocketV1ClientAddress)
        {

            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Spot streams options version 2
        /// </summary>
        public BybitSocketApiClientOptions SpotStreamsV2Options
        {
            get => _spotStreamsV2Options;
            set => _spotStreamsV2Options = new BybitSocketApiClientOptions(_spotStreamsV2Options, value);
        }

        private BybitSocketApiClientOptions _spotStreamsV3Options = new BybitSocketApiClientOptions(BybitApiAddresses.Default.SpotPublicSocketV3ClientAddress, BybitApiAddresses.Default.SpotPrivateSocketV3ClientAddress)
        {

            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Spot streams options version 2
        /// </summary>
        public BybitSocketApiClientOptions SpotStreamsV3Options
        {
            get => _spotStreamsV3Options;
            set => _spotStreamsV3Options = new BybitSocketApiClientOptions(_spotStreamsV3Options, value);
        }

        private BybitSocketApiClientOptions _copyTradingStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.CopyTradingSocketClientAddress, BybitApiAddresses.Default.CopyTradingSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Copy trading streams options
        /// </summary>
        public BybitSocketApiClientOptions CopyTradingStreamsOptions
        {
            get => _copyTradingStreamsOptions;
            set => _copyTradingStreamsOptions = new BybitSocketApiClientOptions(_copyTradingStreamsOptions, value);
        }

        private BybitDerivativesSocketApiClientOptions _derivativesPublicStreamsOptions = new BybitDerivativesSocketApiClientOptions(
                                                                                        BybitApiAddresses.Default.DerivativesPublicUSDTContractSocketClientAddress,
                                                                                        BybitApiAddresses.Default.DerivativesPublicUSDCContractSocketClientAddress,
                                                                                        BybitApiAddresses.Default.DerivativesPublicUSDCOptionSocketClientAddress,
                                                                                        BybitApiAddresses.Default.DerivativesPublicInverseSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Unified margin streams options
        /// </summary>
        public BybitDerivativesSocketApiClientOptions DerivativesPublicStreamsOptions
        {
            get => _derivativesPublicStreamsOptions;
            set => _derivativesPublicStreamsOptions = new BybitDerivativesSocketApiClientOptions(_derivativesPublicStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _unifiedMarginStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.UnifiedMarginPrivateSocketClientAddress, BybitApiAddresses.Default.UnifiedMarginPrivateSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Unified margin streams options
        /// </summary>
        public BybitSocketApiClientOptions UnifiedMarginStreamsOptions
        {
            get => _unifiedMarginStreamsOptions;
            set => _unifiedMarginStreamsOptions = new BybitSocketApiClientOptions(_unifiedMarginStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _contractStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.ContractPrivateSocketClientAddress, BybitApiAddresses.Default.ContractPrivateSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Contract streams options
        /// </summary>
        public BybitSocketApiClientOptions ContractStreamsOptions
        {
            get => _contractStreamsOptions;
            set => _contractStreamsOptions = new BybitSocketApiClientOptions(_contractStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _v5StreamOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.V5PublicSocketClientAddress, BybitApiAddresses.Default.V5PrivateSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// V5 streams options
        /// </summary>
        public BybitSocketApiClientOptions V5StreamsOptions
        {
            get => _v5StreamOptions;
            set => _v5StreamOptions = new BybitSocketApiClientOptions(_v5StreamOptions, value);
        }


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

            InverseFuturesStreamsOptions = new BybitSocketApiClientOptions(baseOn.InverseFuturesStreamsOptions, null);
            InversePerpetualStreamsOptions = new BybitSocketApiClientOptions(baseOn.InversePerpetualStreamsOptions, null);
            SpotStreamsV1Options = new BybitSocketApiClientOptions(baseOn.SpotStreamsV1Options, null);
            SpotStreamsV2Options = new BybitSocketApiClientOptions(baseOn.SpotStreamsV2Options, null);
            UsdPerpetualStreamsOptions = new BybitSocketApiClientOptions(baseOn.UsdPerpetualStreamsOptions, null);
            DerivativesPublicStreamsOptions = new BybitDerivativesSocketApiClientOptions(baseOn.DerivativesPublicStreamsOptions, null);
            UnifiedMarginStreamsOptions = new BybitSocketApiClientOptions(baseOn.UnifiedMarginStreamsOptions, null);
            ContractStreamsOptions = new BybitSocketApiClientOptions(baseOn.ContractStreamsOptions, null);
            V5StreamsOptions = new BybitSocketApiClientOptions(baseOn.V5StreamsOptions, null);
        }
    }

    /// <summary>
    /// Bybit socket API client options
    /// </summary>
    public class BybitSocketApiClientOptions : SocketApiClientOptions
    {
        /// <summary>
        /// The base address for the authenticated websocket
        /// </summary>
        public string BaseAddressAuthenticated { get; set; }

        /// <summary>
        /// Interval at which to send a ping to the server
        /// </summary>
        public TimeSpan PingInterval { get; set; }

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
            PingInterval = newValues?.PingInterval ?? baseOn.PingInterval;
            BaseAddressAuthenticated = newValues?.BaseAddressAuthenticated ?? baseOn.BaseAddressAuthenticated;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="baseAddressAuthenticated"></param>
        internal BybitSocketApiClientOptions(string baseAddress, string baseAddressAuthenticated) : base(baseAddress)
        {
            BaseAddressAuthenticated = baseAddressAuthenticated;
        }
    }

    /// <summary>
    /// Socket options for UnifiedMargin account
    /// </summary>
    public class BybitDerivativesSocketApiClientOptions : BybitSocketApiClientOptions
    {
        private Dictionary<StreamDerivativesCategory, string> PublicBaseAddresses { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
#pragma warning disable 8618
        public BybitDerivativesSocketApiClientOptions()
        {
        }
#pragma warning restore

        internal BybitDerivativesSocketApiClientOptions(BybitDerivativesSocketApiClientOptions baseOn, BybitDerivativesSocketApiClientOptions? newValues) : base(baseOn, newValues)
        {
            PublicBaseAddresses = new Dictionary<StreamDerivativesCategory, string>();

            if (newValues != null)
            {
                foreach (var item in newValues.PublicBaseAddresses)
                {
                    PublicBaseAddresses.Add(item.Key, item.Value);
                }
            }
        }

        internal BybitDerivativesSocketApiClientOptions(string baseUsdtAddress, string baseUsdcAddress, string baseUsdcOptionAddress, string baseInverseAddress)
         : base(baseUsdtAddress, string.Empty)
        {
            PublicBaseAddresses = new Dictionary<StreamDerivativesCategory, string>
            {
                { StreamDerivativesCategory.USDTPerp, baseUsdtAddress },
                { StreamDerivativesCategory.USDCPerp, baseUsdcAddress },
                { StreamDerivativesCategory.USDCOption, baseUsdcOptionAddress },
                { StreamDerivativesCategory.Inverse, baseInverseAddress }
            };
        }

        internal string GetPublicAddress(StreamDerivativesCategory category)
        {
            if (!PublicBaseAddresses.ContainsKey(category))
            {
                throw new NotSupportedException("Public stream for this StreamCategory not found.");
            }

            return PublicBaseAddresses[category];
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
