namespace Bybit.Net.Objects
{
    /// <summary>
    /// Api addresses usable for the Bybit clients
    /// </summary>
    public class BybitApiAddresses
    {
        /// <summary>
        /// The address used by the BybitClient for the Spot rest API
        /// </summary>
        public string SpotRestClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitClient for the Copy Trading rest API
        /// </summary>
        public string CopyTradingRestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public Spot socket API
        /// </summary>
        public string SpotPublicSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the private Spot socket API
        /// </summary>
        public string SpotPrivateSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitClient for the USD perpetual rest API
        /// </summary>
        public string UsdPerpetualRestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public USD perpetual socket API
        /// </summary>
        public string UsdPerpetualPublicSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketclient for the private USD perpetual socket API 
        /// </summary>
        public string UsdPerpetualPrivateSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitClient for the Inverse perpetual rest API
        /// </summary>
        public string InversePerpetualRestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the Inverse perpetual socket API
        /// </summary>
        public string InversePerpetualSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitClient for the Inverse futures rest API
        /// </summary>
        public string InverseFuturesRestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the Inverse futures socket API
        /// </summary>
        public string InverseFuturesSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the Inverse futures socket API
        /// </summary>
        public string CopyTradingSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The default addresses to connect to the Bybit.com API
        /// </summary>
        public static BybitApiAddresses Default = new BybitApiAddresses
        {
            SpotRestClientAddress = "https://api.bybit.com",
            SpotPublicSocketClientAddress = "wss://stream.bybit.com/spot/quote/ws/v2",
            SpotPrivateSocketClientAddress = "wss://stream.bybit.com/spot/ws",
            UsdPerpetualRestClientAddress = "https://api.bybit.com",
            UsdPerpetualPublicSocketClientAddress = "wss://stream.bybit.com/realtime_public",
            UsdPerpetualPrivateSocketClientAddress = "wss://stream.bybit.com/realtime_private",
            InversePerpetualRestClientAddress = "https://api.bybit.com",
            InversePerpetualSocketClientAddress = "wss://stream.bybit.com/realtime",
            InverseFuturesRestClientAddress = "https://api.bybit.com",
            InverseFuturesSocketClientAddress = "wss://stream.bybit.com/realtime",
            CopyTradingRestClientAddress = "https://api.bybit.com",
            CopyTradingSocketClientAddress = "wss://stream.bybit.com/realtime_private",
        };

        /// <summary>
        /// The addresses to connect to the Bybit testnet
        /// </summary>
        public static BybitApiAddresses TestNet = new BybitApiAddresses
        {
            SpotRestClientAddress = "https://api-testnet.bybit.com",
            SpotPublicSocketClientAddress = "wss://stream-testnet.bybit.com/spot/quote/ws/v2",
            SpotPrivateSocketClientAddress = "wss://stream-testnet.bybit.com/spot/ws",
            UsdPerpetualRestClientAddress = "https://api-testnet.bybit.com",
            UsdPerpetualPublicSocketClientAddress = "wss://stream-testnet.bybit.com/realtime_public",
            UsdPerpetualPrivateSocketClientAddress = "wss://stream-testnet.bybit.com/realtime_private",
            InversePerpetualRestClientAddress = "https://api-testnet.bybit.com",
            InversePerpetualSocketClientAddress = "wss://stream-testnet.bybit.com/realtime",
            InverseFuturesRestClientAddress = "https://api-testnet.bybit.com",
            InverseFuturesSocketClientAddress = "wss://stream-testnet.bybit.com/realtime",
        };
    }
}
