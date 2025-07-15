namespace Bybit.Net.Objects
{
    /// <summary>
    /// Api addresses usable for the Bybit clients
    /// </summary>
    public class BybitApiAddresses
    {
        /// <summary>
        /// Rest API base address
        /// </summary>
        public string RestBaseAddress { get; set; } = "";
        /// <summary>
        /// Socket API base address
        /// </summary>
        public string SocketBaseAddress { get; set; } = "";

        /// <summary>
        /// The default addresses to connect to the Bybit.com API
        /// </summary>
        public static BybitApiAddresses Default = new BybitApiAddresses
        {
            RestBaseAddress = "https://api.bybit.com",
            SocketBaseAddress = "wss://stream.bybit.com"
        };

        /// <summary>
        /// The addresses to connect to the Bybit testnet
        /// </summary>
        public static BybitApiAddresses TestNet = new BybitApiAddresses
        {
            RestBaseAddress = "https://api-testnet.bybit.com",
            SocketBaseAddress = "wss://stream-testnet.bybit.com",
        };

        /// <summary>
        /// The addresses to connect to the main net for users from The Netherlands
        /// </summary>
        public static BybitApiAddresses Netherlands = new BybitApiAddresses
        {
            RestBaseAddress = "https://api.bybit.nl",
            SocketBaseAddress = "wss://stream.bybit.com" // As per Telegram support, normal address should be used for websockets
        };

        /// <summary>
        /// The addresses to connect to the Bybit main net for users from HongKong
        /// </summary>
        public static BybitApiAddresses HongKong = new BybitApiAddresses
        {
            RestBaseAddress = "https://api.bybit.com.hk",
            SocketBaseAddress = "wss://stream.bybit.com" // As per Telegram support, normal address should be used for websockets
        };

        /// <summary>
        /// The addresses to connect to the Bybit main net for users from Turkey
        /// </summary>
        public static BybitApiAddresses Turkey = new BybitApiAddresses
        {
            RestBaseAddress = "https://api.bybit-tr.com",
            SocketBaseAddress = "wss://stream.bybit-tr.com"
        };

        /// <summary>
        /// The addresses to connect to the Bybit main net for users from Kazakhstan
        /// </summary>
        public static BybitApiAddresses Kazakhstan = new BybitApiAddresses
        {
            RestBaseAddress = "https://api.bybit.kz",
            SocketBaseAddress = "wss://stream.bybit.kz"
        };

        /// <summary>
        /// The addresses to connect to the Bybit main net for users from Georgia
        /// </summary>
        public static BybitApiAddresses Georgia = new BybitApiAddresses
        {
            RestBaseAddress = "https://api.bybitgeorgia.ge",
            SocketBaseAddress = "wss://stream.bybitgeorgia.ge"
        };

        /// <summary>
        /// The addresses to connect to the Bybit demo trading environment
        /// </summary>
        public static BybitApiAddresses DemoTrading = new BybitApiAddresses
        {
            RestBaseAddress = "https://api-demo.bybit.com",
            SocketBaseAddress = "wss://stream-demo.bybit.com"
        };
    }
}
