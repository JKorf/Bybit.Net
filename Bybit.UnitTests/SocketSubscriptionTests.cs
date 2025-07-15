using Bybit.Net.Clients;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bybit.Net.UnitTests
{
    [TestFixture]
    public class SocketSubscriptionTests
    {
        [Test]
        public async Task ValidateSpotSubscriptions()
        {
            var client = new BybitSocketClient(opts =>
            {
                opts.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "456");
            });
            var tester = new SocketSubscriptionValidator<BybitSocketClient>(client, "Subscriptions/V5/Spot", "https://api.binance.com", "data");
            await tester.ValidateAsync<BybitSpotTickerUpdate>((client, handler) => client.V5SpotApi.SubscribeToTickerUpdatesAsync("BTCUSDT", handler), "Ticker");
            await tester.ValidateAsync<BybitKlineUpdate[]>((client, handler) => client.V5SpotApi.SubscribeToLeveragedTokenKlineUpdatesAsync("BTCUSDT", Enums.KlineInterval.OneMonth, handler), "LeveragedKline");
            await tester.ValidateAsync<BybitLeveragedTokenTicker>((client, handler) => client.V5SpotApi.SubscribeToLeveragedTokenTickerUpdatesAsync("BTCUSDT", handler), "LeveragedTicker");
            await tester.ValidateAsync<BybitLeveragedTokenNav>((client, handler) => client.V5SpotApi.SubscribeToLeveragedTokenNavUpdatesAsync("BTCUSDT", handler), "LeveragedNav");
            await tester.ValidateAsync<BybitTrade[]>((client, handler) => client.V5SpotApi.SubscribeToTradeUpdatesAsync("BTCUSDT", handler), "Trades");
            await tester.ValidateAsync<BybitOrderPriceLimit>((client, handler) => client.V5SpotApi.SubscribeToPriceLimitUpdatesAsync("BTCUSDT", handler), "PriceLimit");
            await tester.ValidateAsync<BybitSystemStatus[]>((client, handler) => client.V5SpotApi.SubscribeToSystemStatusUpdatesAsync(handler), "SystemStatus");
        }

        [Test]
        public async Task ValidateOptionSubscriptions()
        {
            var client = new BybitSocketClient(opts =>
            {
                opts.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "456");
            });
            var tester = new SocketSubscriptionValidator<BybitSocketClient>(client, "Subscriptions/V5/Option", "https://api.binance.com", "data");
            await tester.ValidateAsync<BybitOptionTickerUpdate>((client, handler) => client.V5OptionsApi.SubscribeToTickerUpdatesAsync("BTC", handler), "Ticker");
            await tester.ValidateAsync<BybitOptionTrade[]>((client, handler) => client.V5OptionsApi.SubscribeToTradeUpdatesAsync("BTC", handler), "Trades");
            await tester.ValidateAsync<BybitOrderbook>((client, handler) => client.V5OptionsApi.SubscribeToOrderbookUpdatesAsync("BTCUSDT", 25, handler), "Book");
            await tester.ValidateAsync<BybitKlineUpdate[]>((client, handler) => client.V5OptionsApi.SubscribeToKlineUpdatesAsync("BTCUSDT", Enums.KlineInterval.OneMonth, handler), "Klines");
        }

        [Test]
        public async Task ValidateLinearSubscriptions()
        {
            var client = new BybitSocketClient(opts =>
            {
                opts.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "456");
            });
            var tester = new SocketSubscriptionValidator<BybitSocketClient>(client, "Subscriptions/V5/Linear", "https://api.bybit.com", "data");
            await tester.ValidateAsync<BybitLinearTickerUpdate>((client, handler) => client.V5LinearApi.SubscribeToTickerUpdatesAsync("BTCUSDT", handler), "Ticker");
            await tester.ValidateAsync<BybitTrade[]>((client, handler) => client.V5LinearApi.SubscribeToTradeUpdatesAsync("BTCUSDT", handler), "Trades");
            await tester.ValidateAsync<BybitLiquidationUpdate[]>((client, handler) => client.V5LinearApi.SubscribeToAllLiquidationUpdatesAsync("ETHUSDT", handler), "Liquidations");
        }

        [Test]
        public async Task ValidatePrivateSubscriptions()
        {
            var logger = new LoggerFactory();
            logger.AddProvider(new TraceLoggerProvider());

            var client = new BybitSocketClient(Options.Create(new BybitSocketOptions
            {
                ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "456")
            }), logger);
            var tester = new SocketSubscriptionValidator<BybitSocketClient>(client, "Subscriptions/V5/Private", "https://api.bybit.com", "data");
            //await tester.ValidateAsync<BybitPositionUpdate[]>((client, handler) => client.V5PrivateApi.SubscribeToPositionUpdatesAsync(handler), "Position", ignoreProperties: new List<string> { "entryPrice" }, addressPath: "/v5/private");
            //await tester.ValidateAsync<BybitUserTradeUpdate[]>((client, handler) => client.V5PrivateApi.SubscribeToUserTradeUpdatesAsync(handler), "UserTrades", addressPath: "/v5/private");
            //await tester.ValidateAsync<BybitMinimalUserTradeUpdate[]>((client, handler) => client.V5PrivateApi.SubscribeToMinimalUserTradeUpdatesAsync(handler), "MinimalUserTrades", addressPath: "/v5/private");
            //await tester.ValidateAsync<BybitOrderUpdate[]>((client, handler) => client.V5PrivateApi.SubscribeToOrderUpdatesAsync(handler), "Order", addressPath: "/v5/private");
            //await tester.ValidateAsync<BybitBalance[]>((client, handler) => client.V5PrivateApi.SubscribeToWalletUpdatesAsync(handler), "Balance", addressPath: "/v5/private");
            //await tester.ValidateAsync<BybitGreeks[]>((client, handler) => client.V5PrivateApi.SubscribeToGreekUpdatesAsync(handler), "Greeks", addressPath: "/v5/private");
            await tester.ValidateAsync<BybitSpreadUserTradeUpdate[]>((client, handler) => client.V5PrivateApi.SubscribeToSpreadUserTradeUpdatesAsync(handler), "SpreadUserTrade", addressPath: "/v5/private");
        }
    }
}
