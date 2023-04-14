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
        /// The address used by the BybitSocketClient for the public Spot socket API v1
        /// </summary>
        public string SpotPublicSocketV1ClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public Spot socket API v2
        /// </summary>
        public string SpotPublicSocketV2ClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public Spot socket API v3
        /// </summary>
        public string SpotPublicSocketV3ClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the private Spot socket API v1
        /// </summary>
        public string SpotPrivateSocketV1ClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the private Spot socket API v3
        /// </summary>
        public string SpotPrivateSocketV3ClientAddress { get; set; } = "";

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
        /// The address used by the BybitClient for the Copy Trading rest API
        /// </summary>
        public string CopyTradingRestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the Inverse futures socket API
        /// </summary>
        public string CopyTradingSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybiClient for the Derivatives rest API
        /// </summary>
        public string DerivativesRestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public USDT contract Derivatives socket API
        /// </summary>
        public string DerivativesPublicUSDTContractSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public USDC contract Derivatives socket API
        /// </summary>
        public string DerivativesPublicUSDCContractSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public USDC option Derivatives socket API
        /// </summary>
        public string DerivativesPublicUSDCOptionSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public Inverse Derivatives socket API
        /// </summary>
        /// <remarks> Now only for Contract </remarks>
        public string DerivativesPublicInverseSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the private Contract socket API
        /// </summary>
        public string ContractPrivateSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the private Unified margin socket API
        /// </summary>
        public string UnifiedMarginPrivateSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitSocketClient for the V5 socket API
        /// </summary>
        public string V5PrivateSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the V5 socket API
        /// </summary>
        public string V5PublicSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The default addresses to connect to the Bybit.com API
        /// </summary>
        public static BybitApiAddresses Default = new BybitApiAddresses
        {
            SpotRestClientAddress = "https://api.bybit.com",
            SpotPublicSocketV1ClientAddress = "wss://stream.bybit.com/spot/quote/ws/v1",
            SpotPublicSocketV2ClientAddress = "wss://stream.bybit.com/spot/quote/ws/v2",
            SpotPublicSocketV3ClientAddress = "wss://stream.bybit.com/spot/public/v3",
            SpotPrivateSocketV1ClientAddress = "wss://stream.bybit.com/spot/ws",
            SpotPrivateSocketV3ClientAddress = "wss://stream.bybit.com/spot/private/v3",
            UsdPerpetualRestClientAddress = "https://api.bybit.com",
            UsdPerpetualPublicSocketClientAddress = "wss://stream.bybit.com/realtime_public",
            UsdPerpetualPrivateSocketClientAddress = "wss://stream.bybit.com/realtime_private",
            InversePerpetualRestClientAddress = "https://api.bybit.com",
            InversePerpetualSocketClientAddress = "wss://stream.bybit.com/realtime",
            InverseFuturesRestClientAddress = "https://api.bybit.com",
            InverseFuturesSocketClientAddress = "wss://stream.bybit.com/realtime",
            CopyTradingRestClientAddress = "https://api.bybit.com",
            CopyTradingSocketClientAddress = "wss://stream.bybit.com/realtime_private",
            DerivativesRestClientAddress = "https://api.bybit.com",
            DerivativesPublicUSDTContractSocketClientAddress = "wss://stream.bybit.com/contract/usdt/public/v3",
            DerivativesPublicUSDCContractSocketClientAddress = "wss://stream.bybit.com/contract/usdc/public/v3",
            DerivativesPublicUSDCOptionSocketClientAddress = "wss://stream.bybit.com/option/usdc/public/v3",
            DerivativesPublicInverseSocketClientAddress = "wss://stream.bybit.com/contract/inverse/public/v3",
            UnifiedMarginPrivateSocketClientAddress = "wss://stream.bybit.com/unified/private/v3",
            ContractPrivateSocketClientAddress = "wss://stream.bybit.com/contract/private/v3",

            V5PublicSocketClientAddress = "wss://stream.bybit.com/v5/public",
            V5PrivateSocketClientAddress = "wss://stream.bybit.com/v5/private"
        };

        /// <summary>
        /// The addresses to connect to the Bybit testnet
        /// </summary>
        public static BybitApiAddresses TestNet = new BybitApiAddresses
        {
            SpotRestClientAddress = "https://api-testnet.bybit.com",
            SpotPublicSocketV1ClientAddress = "wss://stream-testnet.bybit.com/spot/quote/ws/v1",
            SpotPublicSocketV2ClientAddress = "wss://stream-testnet.bybit.com/spot/quote/ws/v2",
            SpotPublicSocketV3ClientAddress = "wss://stream-testnet.bybit.com/spot/public/v3",
            SpotPrivateSocketV1ClientAddress = "wss://stream-testnet.bybit.com/spot/ws",
            SpotPrivateSocketV3ClientAddress = "wss://stream-testnet.bybit.com/spot/private/v3",
            UsdPerpetualRestClientAddress = "https://api-testnet.bybit.com",
            UsdPerpetualPublicSocketClientAddress = "wss://stream-testnet.bybit.com/realtime_public",
            UsdPerpetualPrivateSocketClientAddress = "wss://stream-testnet.bybit.com/realtime_private",
            InversePerpetualRestClientAddress = "https://api-testnet.bybit.com",
            InversePerpetualSocketClientAddress = "wss://stream-testnet.bybit.com/realtime",
            InverseFuturesRestClientAddress = "https://api-testnet.bybit.com",
            InverseFuturesSocketClientAddress = "wss://stream-testnet.bybit.com/realtime",
            DerivativesRestClientAddress = "https://api-testnet.bybit.com",
            DerivativesPublicUSDTContractSocketClientAddress = "wss://stream-testnet.bybit.com/contract/usdt/public/v3",
            DerivativesPublicUSDCContractSocketClientAddress = "wss://stream-testnet.bybit.com/contract/usdc/public/v3",
            DerivativesPublicUSDCOptionSocketClientAddress = "wss://stream-testnet.bybit.com/option/usdc/public/v3",
            DerivativesPublicInverseSocketClientAddress = "wss://stream-testnet.bybit.com/contract/inverse/public/v3",
            UnifiedMarginPrivateSocketClientAddress = "wss://stream-testnet.bybit.com/unified/private/v3",
            ContractPrivateSocketClientAddress = "wss://stream-testnet.bybit.com/contract/private/v3",

            V5PublicSocketClientAddress = "wss://stream-testnet.bybit.com/v5/public",
            V5PrivateSocketClientAddress = "wss://stream-testnet.bybit.com/v5/private"
        };
    }
}
