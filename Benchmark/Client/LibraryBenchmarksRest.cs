using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Options;
using Microsoft.Extensions.Options;

namespace Bybit.Net.Benchmark.Client
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net48)]
    [SimpleJob(RuntimeMoniker.Net10_0)]
    public class LibraryBenchmarksRest
    {
        public BybitRestClient RestClient;

        [GlobalSetup(Targets = [nameof(RestServerTime), nameof(RestTicker)])]
        public void Setup()
        {
            CreateClient();
        }

        [Benchmark, IterationCount(25)]
        public async Task RestServerTime()
        {
            for (var i = 0; i < 1000; i++)
                _ = await RestClient.V5Api.ExchangeData.GetServerTimeAsync();
        }

        [Benchmark, IterationCount(25)]
        public async Task RestTicker()
        {
            for (var i = 0; i < 1000; i++)
                _ = await RestClient.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            RestClient?.Dispose();
        }

        private void CreateClient()
        {
            var env = BybitEnvironment.CreateCustom("Benchmark", "http://localhost:" + Program.ServerPort, "ws://localhost:" + Program.ServerPort);
            RestClient = new BybitRestClient(null, null, Options.Create(new BybitRestOptions
            {
                RateLimiterEnabled = false,
                Environment = env
            }));
        }
    }
}
