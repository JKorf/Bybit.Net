using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using Bybit.Net.Clients;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Options;

namespace Bybit.Net.Benchmark.Client
{
    [MemoryDiagnoser]
    [Config(typeof(Config))]
    public class LibraryBenchmarksSocket
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                var baseJob = Job.Default;

                AddJob(
                    baseJob
                        .WithId("NET10_0")
                        .WithIterationCount(20)
                        .WithRuntime(CoreRuntime.Core10_0));
                AddJob(
                    baseJob
                        .WithId("NET481")
                        .WithIterationCount(20)
                        .WithRuntime(ClrRuntime.Net48));
            }
        }

        public BybitSocketClient SocketClient;

        private const int _socketUpdateReceiveTarget = 1_000_000;

        [GlobalSetup]
        public void Setup()
        {
            CreateClient();
        }

        [IterationSetup(Target = nameof(Socket100Topics))]
        public void IterationSetupMultiTopic()
        {
            Task.Run(async () =>
            {
                for (var i = 0; i < 10; i++)
                {
                    var subTopics = new string[10];
                    for (var j = 0; j < 10; j++)
                        subTopics[j] = "DUMMY" + i;

                    _ = await SocketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(subTopics, x => { }, CancellationToken.None);
                    _ = await SocketClient.V5SpotApi.SubscribeToOrderbookUpdatesAsync(subTopics, 1, x => { }, CancellationToken.None);
                }
            }).Wait();
        }

        [IterationCleanup(Target = nameof(Socket100Topics))]
        public void IterationCleanUpMultiTopic()
        {
            SocketClient.V5SpotApi.UnsubscribeAllAsync().Wait();
        }

        [Benchmark]
        public async Task Socket1Topic()
        {
            var waitEvent = new AsyncResetEvent(false, false);
            var received = 0;
            var result = await SocketClient.V5SpotApi.SubscribeToTradeUpdatesAsync("ETHUSDT", x =>
            {
                received += x.Data.Length;
                if (received >= _socketUpdateReceiveTarget)
                    waitEvent.Set();
            }, CancellationToken.None);

            await waitEvent.WaitAsync();
            await result.Data.CloseAsync();
        }

        [Benchmark]
        public async Task Socket100Topics()
        {
            var waitEvent = new AsyncResetEvent(false, false);
            var received = 0;
            var topics = new string[100];
            for (var i = 0; i < 100; i++)
                topics[i] = "DUMMY";

            topics[50] = "ETHUSDT";

            var result = await SocketClient.V5SpotApi.SubscribeToTradeUpdatesAsync(topics, x =>
            {
                received += x.Data.Length;
                if (received >= _socketUpdateReceiveTarget)
                    waitEvent.Set();
            }, CancellationToken.None);

            await waitEvent.WaitAsync();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            SocketClient?.Dispose();
        }

        private void CreateClient()
        {
            var env = BybitEnvironment.CreateCustom("Benchmark", "http://localhost:" + Program.ServerPort, "ws://localhost:" + Program.ServerPort);
            SocketClient = new BybitSocketClient(Options.Create(new BybitSocketOptions
            {
                ReconnectPolicy = ReconnectPolicy.Disabled,
                RateLimiterEnabled = false,
                Environment = env
            }));
        }
    }
}
