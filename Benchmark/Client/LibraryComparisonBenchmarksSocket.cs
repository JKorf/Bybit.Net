using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Bybit.Api;
using Bybit.Net.Clients;
using Bybit.Net.Objects.Options;
using ccxt.pro;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Options;

namespace Bybit.Net.Benchmark.Client
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [SimpleJob(RuntimeMoniker.Net48)]
    [SimpleJob(RuntimeMoniker.Net10_0)]
    public class LibraryComparisonBenchmarksSocket
    {
        private static readonly int _socketUpdateReceiveTarget = 100_000;

        private BybitSocketClient _bybitNetClient;
        private ccxt.pro.bybit _ccxtClient;
        private BybitWebSocketClient _bybitApiClient;

        [GlobalSetup]
        public void Setup()
        {
            var env = BybitEnvironment.CreateCustom(
                "Benchmark",
                "http://localhost:" + Program.ServerPort,
                "ws://localhost:" + Program.ServerPort);

            _bybitNetClient = new BybitSocketClient(Options.Create(new BybitSocketOptions
            {
                ReconnectPolicy = ReconnectPolicy.Disabled,
                RateLimiterEnabled = false,
                Environment = env
            }), null);

            _bybitApiClient = new BybitWebSocketClient(new BybitWebSocketClientOptions
            {
                AutoReconnect = false,
                WebSocketSpotAddress = "ws://localhost:" + Program.ServerPort + "/v5/public/spot",
                BaseAddress = "ws://localhost:" + Program.ServerPort
            });
            BybitAddress.MainNet.WebSocketSpotAddress = "ws://localhost:" + Program.ServerPort;

            _ccxtClient = new bybit(new Dictionary<string, object>
            {
                ["urls"] = new Dictionary<string, object>
                {
                    ["api"] = new Dictionary<string, object>
                    {
                        ["ws"] = new Dictionary<string, object>
                        {
                            ["public"] = new Dictionary<string, object>
                            {
                                ["spot"] = "ws://localhost:" + Program.ServerPort + "/v5/public/spot"
                            }
                        }
                    }
                }
            });
            _ccxtClient.enableRateLimit = false;
        }

        [Benchmark(Baseline = true), IterationCount(25)]
        public async Task BybitNet_Trades()
        {
            var waitEvent = new AsyncResetEvent(false, false);
            var received = 0;
            var result = await _bybitNetClient.V5SpotApi.SubscribeToTradeUpdatesAsync("ETHUSDT", x =>
            {
                received += x.Data.Length;
                if (received >= _socketUpdateReceiveTarget)
                    waitEvent.Set();
            }, CancellationToken.None);

            await waitEvent.WaitAsync();
            await result.Data.CloseAsync();
        }

        [Benchmark(), IterationCount(25)]
        public async Task BybitApi_Trades()
        {
            var waitEvent = new AsyncResetEvent(false, false);
            var received = 0;
            var result = await _bybitApiClient.SubscribeToTradesAsync(Api.Enums.BybitCategory.Spot, "ETHUSDT", x =>
            {
                received ++;
                if (received >= _socketUpdateReceiveTarget)
                    waitEvent.Set();
            }, CancellationToken.None);

            await waitEvent.WaitAsync();
            await result.Data.CloseAsync();
        }

        [Benchmark, IterationCount(25)]
        public async Task CCXT_Trades()
        {
            var waitEvent = new AsyncResetEvent(false, false);
            var received = 0;
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    var trades = await _ccxtClient.WatchTrades("ETH/USDT");
                    received += trades.Count;

                    if (received >= _socketUpdateReceiveTarget)
                        break;
                }

                waitEvent.Set();
            });

            await waitEvent.WaitAsync();
            await _ccxtClient.Close();
        }

        [Benchmark, IterationCount(25)]
        public async Task BybitNetShared_Trades()
        {
            var waitEvent = new AsyncResetEvent(false, false);
            var received = 0;
            var request = new SubscribeTradeRequest(new SharedSymbol(TradingMode.Spot, "ETH", "USDT"));
            var result = await _bybitNetClient.V5SpotApi.SharedClient.SubscribeToTradeUpdatesAsync(request, x =>
            {
                received += x.Data.Length;
                if (received >= _socketUpdateReceiveTarget)
                    waitEvent.Set();
            }, CancellationToken.None);

            await waitEvent.WaitAsync();
            await result.Data.CloseAsync();
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _bybitNetClient?.Dispose();
        }
    }
}
