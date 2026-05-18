using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Bybit.Api;
using Bybit.Net.Clients;
using ccxt;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;

namespace Bybit.Net.Benchmark.Client
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [SimpleJob(RuntimeMoniker.Net48)]
    [SimpleJob(RuntimeMoniker.Net10_0)]
    public class LibraryComparisonBenchmarksRest
    {
        private BybitRestClient _bybitNetClient;
        private BybitRestApiClient _bybitApiClient;
        private bybit _ccxtClient;

        [GlobalSetup]
        public void Setup()
        {
            var env = BybitEnvironment.CreateCustom(
                "Benchmark",
                "http://localhost:" + Program.ServerPort,
                "ws://localhost:" + Program.ServerPort);

            _bybitNetClient = new BybitRestClient(x =>
            {
                x.RateLimiterEnabled = false;
                x.Environment = env;
            });

            _bybitApiClient = new BybitRestApiClient(new BybitRestApiClientOptions
            {
                RateLimiterEnabled = false,
                RateLimiters = [],
                BaseAddress = "http://localhost:" + Program.ServerPort
            });
            BybitAddress.MainNet.RestApiAddress = "http://localhost:" + Program.ServerPort;

            _ccxtClient = new bybit(new Dictionary<string, object>
            {
                ["urls"] = new Dictionary<string, object>
                {
                    ["api"] = new Dictionary<string, object>
                    {
                        ["public"] = "http://localhost:" + Program.ServerPort
                    }
                }
            });
            _ccxtClient.enableRateLimit = false;
            //_ccxtClient.verbose = true;
        }

        [Benchmark(Baseline = true), IterationCount(25)]
        public async Task BybitNet_ServerTime()
        {
            for (var i = 0; i < 1; i++)
                _ = await _bybitNetClient.V5Api.ExchangeData.GetServerTimeAsync();
        }


        [Benchmark(), IterationCount(25)]
        public async Task BybitApi_ServerTime()
        {
            for (var i = 0; i < 1; i++)
                _ = await _bybitApiClient.Market.GetServerTimeAsync();
        }


        [Benchmark(), IterationCount(25)]
        public async Task CCXT_ServerTime()
        {
            for (var i = 0; i < 1; i++)
                _ = await _ccxtClient.publicGetV5MarketTime();
        }

        [Benchmark, IterationCount(25)]
        public async Task BybitNet_Ticker()
        {
            for (var i = 0; i < 1; i++)
                _ = await _bybitNetClient.V5Api.ExchangeData.GetSpotTickersAsync("ETHUSDT");
        }

        [Benchmark, IterationCount(25)]
        public async Task BybitApi_Ticker()
        {
            for (var i = 0; i < 1; i++)
                _ = await _bybitApiClient.Market.GetSpotTickersAsync("ETHUSDT");
        }

        [Benchmark, IterationCount(25)]
        public async Task CCXT_Ticker()
        {
            for (var i = 0; i < 1; i++)
                _ = await _ccxtClient.publicGetV5MarketTickers(new Dictionary<string, object>
                {
                    { "symbol", "ETH/USDT" }
                });
        }

        [Benchmark, IterationCount(25)]
        public async Task BybitNetShared_Ticker()
        {
            var request = new GetTickerRequest(new SharedSymbol(TradingMode.Spot, "ETH", "USDT"));
            for (var i = 0; i < 1; i++)
                _ = await _bybitNetClient.V5Api.SharedClient.GetSpotTickerAsync(request);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _bybitNetClient?.Dispose();
        }
    }
}
