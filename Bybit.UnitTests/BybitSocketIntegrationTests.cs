using Bybit.Net.Clients;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Bybit.Net.UnitTests
{
    [NonParallelizable]
    internal class BybitSocketIntegrationTests : SocketIntegrationTest<BybitSocketClient>
    {
        public override bool Run { get; set; } = false;

        public BybitSocketIntegrationTests()
        {
        }

        public override BybitSocketClient GetClient(ILoggerFactory loggerFactory, bool useUpdatedDeserialization)
        {
            var key = Environment.GetEnvironmentVariable("APIKEY");
            var sec = Environment.GetEnvironmentVariable("APISECRET");

            Authenticated = key != null && sec != null;
            return new BybitSocketClient(Options.Create(new BybitSocketOptions
            {
                OutputOriginalData = true,
                UseUpdatedDeserialization = useUpdatedDeserialization,
                ApiCredentials = Authenticated ? new CryptoExchange.Net.Authentication.ApiCredentials(key, sec) : null
            }), loggerFactory);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task TestSubscriptions(bool useUpdatedDeserialization)
        {
            await RunAndCheckUpdate<BybitSpotTickerUpdate>(useUpdatedDeserialization, (client, updateHandler) => client.V5PrivateApi.SubscribeToWalletUpdatesAsync(default , default), false, true);
            await RunAndCheckUpdate<BybitSpotTickerUpdate>(useUpdatedDeserialization, (client, updateHandler) => client.V5SpotApi.SubscribeToTickerUpdatesAsync("ETHUSDT", updateHandler, default), true, false);
            await RunAndCheckUpdate<BybitLinearTickerUpdate>(useUpdatedDeserialization, (client, updateHandler) => client.V5LinearApi.SubscribeToTickerUpdatesAsync(new string[] { "ETHUSDT" }, updateHandler, default), true, false);
        } 
    }
}
