using Bybit.Net.Objects;
using CryptoExchange.Net.Objects;
using System;

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
        /// ctor for DI, use <see cref="CreateCustom"/> for creating a custom environment
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BybitEnvironment() : base(TradeEnvironmentNames.Live)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        { }

        /// <summary>
        /// Get the Bybit environment by name
        /// </summary>
        public static BybitEnvironment? GetEnvironmentByName(string? name)
         => name switch
         {
             TradeEnvironmentNames.Live => Live,
             TradeEnvironmentNames.Testnet => Testnet,
             "Eu" => Eu,
             "HongKong" => HongKong,
             "Turkey" => Turkey,
             "Kazakhstan" => Kazakhstan,
             "Georgia" => Georgia,
             "UnitedArabEmirates" => UnitedArabEmirates,
             "Indonesia" => Indonesia,
             "Japan" => Japan,
             "demo" => DemoTrading,
             "" => Live,
             null => Live,
             _ => default
         };

        /// <summary>
        /// Available environment names
        /// </summary>
        /// <returns></returns>
        public static string[] All => [
            Live.Name, 
            Testnet.Name, 
            Eu.Name,
            HongKong.Name,
            Turkey.Name, 
            Kazakhstan.Name, 
            Georgia.Name,
            UnitedArabEmirates.Name,
            Indonesia.Name,
            Japan.Name,
            DemoTrading.Name];

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
        /// Live environment for users from the European Union
        /// </summary>
        public static BybitEnvironment Eu { get; }
            = new BybitEnvironment("Eu",
                                     BybitApiAddresses.Eu.RestBaseAddress,
                                     BybitApiAddresses.Eu.SocketBaseAddress);

        /// <summary>
        /// Live environment for users from HongKong
        /// </summary>
        public static BybitEnvironment HongKong { get; }
            = new BybitEnvironment("HongKong",
                                     BybitApiAddresses.HongKong.RestBaseAddress,
                                     BybitApiAddresses.HongKong.SocketBaseAddress);

        /// <summary>
        /// Live environment for users from Turkey
        /// </summary>
        public static BybitEnvironment Turkey { get; }
            = new BybitEnvironment("Turkey",
                                     BybitApiAddresses.Turkey.RestBaseAddress,
                                     BybitApiAddresses.Turkey.SocketBaseAddress);

        /// <summary>
        /// Live environment for users from Kazakhstan
        /// </summary>
        public static BybitEnvironment Kazakhstan { get; }
            = new BybitEnvironment("Kazakhstan",
                                     BybitApiAddresses.Kazakhstan.RestBaseAddress,
                                     BybitApiAddresses.Kazakhstan.SocketBaseAddress);

        /// <summary>
        /// Live environment for users from Georgia
        /// </summary>
        public static BybitEnvironment Georgia { get; }
            = new BybitEnvironment("Georgia",
                                     BybitApiAddresses.Georgia.RestBaseAddress,
                                     BybitApiAddresses.Georgia.SocketBaseAddress);

        /// <summary>
        /// Live environment for users from United Arab Emirates
        /// </summary>
        public static BybitEnvironment UnitedArabEmirates { get; }
            = new BybitEnvironment("UnitedArabEmirates",
                                     BybitApiAddresses.UnitedArabEmirates.RestBaseAddress,
                                     BybitApiAddresses.UnitedArabEmirates.SocketBaseAddress);
        /// <summary>
        /// Live environment for users from Indonesia
        /// </summary>
        public static BybitEnvironment Indonesia { get; }
            = new BybitEnvironment("Indonesia",
                                     BybitApiAddresses.Indonesia.RestBaseAddress,
                                     BybitApiAddresses.Indonesia.SocketBaseAddress);
        /// <summary>
        /// Live environment for users from Japan
        /// </summary>
        public static BybitEnvironment Japan { get; }
            = new BybitEnvironment("Japan",
                                     BybitApiAddresses.Japan.RestBaseAddress,
                                     BybitApiAddresses.Japan.SocketBaseAddress);
        /// <summary>
        /// Demo trading environment, needs separate API key. See https://bybit-exchange.github.io/docs/v5/demo
        /// </summary>
        public static BybitEnvironment DemoTrading { get; }
            = new BybitEnvironment("demo",
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
