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
    }
}
