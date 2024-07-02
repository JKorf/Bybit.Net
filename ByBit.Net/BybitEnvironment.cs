using Bybit.Net.Objects;
using CryptoExchange.Net.Objects;

namespace Bybit.Net
{
    /// <summary>
    /// Bybit environments
    /// </summary>
    public class BybitEnvironment : TradeEnvironment
    {
        /// <summary>
        /// Spot Rest client address
        /// </summary>
        public string RestBaseAddress { get; }

        /// <summary>
        /// Spot V1 Socket client address
        /// </summary>
        public string SocketBaseAddress { get; }

        internal BybitEnvironment(string name, 
            string restBaseAddress,
            string socketBaseAddress) : base(name)
        {
            RestBaseAddress = restBaseAddress;
            SocketBaseAddress = socketBaseAddress;
        }

        /// <summary>
        /// Live environment
        /// </summary>
        public static BybitEnvironment Live { get; }
            = new BybitEnvironment(TradeEnvironmentNames.Live,
                                     BybitApiAddresses.Default.RestBaseAddress,
                                     BybitApiAddresses.Default.SocketBaseAddress);

        /// <summary>
        /// Testnet environment
        /// </summary>
        public static BybitEnvironment Testnet { get; }
            = new BybitEnvironment(TradeEnvironmentNames.Testnet,
                                     BybitApiAddresses.TestNet.RestBaseAddress,
                                     BybitApiAddresses.TestNet.SocketBaseAddress);

        /// <summary>
        /// Live environment for users from The Netherlands
        /// </summary>
        public static BybitEnvironment Netherlands { get; }
            = new BybitEnvironment(TradeEnvironmentNames.Live,
                                     BybitApiAddresses.Netherlands.RestBaseAddress,
                                     BybitApiAddresses.Netherlands.SocketBaseAddress);

        /// <summary>
        /// Live environment for users from HongKong
        /// </summary>
        public static BybitEnvironment HongKong { get; }
            = new BybitEnvironment(TradeEnvironmentNames.Live,
                                     BybitApiAddresses.HongKong.RestBaseAddress,
                                     BybitApiAddresses.HongKong.SocketBaseAddress);

        /// <summary>
        /// Live environment for users from Turkey
        /// </summary>
        public static BybitEnvironment Turkey { get; }
            = new BybitEnvironment(TradeEnvironmentNames.Live,
                                     BybitApiAddresses.Turkey.RestBaseAddress,
                                     BybitApiAddresses.Turkey.SocketBaseAddress);

        /// <summary>
        /// Demo trading environment, needs seperate API key. See https://bybit-exchange.github.io/docs/v5/demo
        /// </summary>
        public static BybitEnvironment DemoTrading { get; }
            = new BybitEnvironment(TradeEnvironmentNames.Live,
                                     BybitApiAddresses.DemoTrading.RestBaseAddress,
                                     BybitApiAddresses.DemoTrading.SocketBaseAddress);

        /// <summary>
        /// Create a custom environment
        /// </summary>
        /// <param name="name"></param>
        /// <param name="restAddress"></param>
        /// <param name="socketAddress"></param>
        /// <returns></returns>
        public static BybitEnvironment CreateCustom(
                        string name,
                        string restAddress,
                        string socketAddress)
            => new BybitEnvironment(name, restAddress, socketAddress);
    }
}
