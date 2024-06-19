using Bybit.Net.Clients;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Testing;
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
            var tester = new SocketSubscriptionValidator<BybitSocketClient>(client, "Subscriptions/V5/Spot", "https://api.binance.com", "data", stjCompare: false);
            await tester.ValidateAsync<BybitSpotTickerUpdate>((client, handler) => client.V5SpotApi.SubscribeToTickerUpdatesAsync("BTCUSDT", handler), "Ticker");
            await tester.ValidateAsync<IEnumerable<BybitKlineUpdate>>((client, handler) => client.V5SpotApi.SubscribeToLeveragedTokenKlineUpdatesAsync("BTCUSDT", Enums.KlineInterval.OneMonth, handler), "LeveragedKline");
            await tester.ValidateAsync<BybitLeveragedTokenTicker>((client, handler) => client.V5SpotApi.SubscribeToLeveragedTokenTickerUpdatesAsync("BTCUSDT", handler), "LeveragedTicker");
            await tester.ValidateAsync<BybitLeveragedTokenNav>((client, handler) => client.V5SpotApi.SubscribeToLeveragedTokenNavUpdatesAsync("BTCUSDT", handler), "LeveragedNav");
            await tester.ValidateAsync<IEnumerable<BybitTrade>>((client, handler) => client.V5SpotApi.SubscribeToTradeUpdatesAsync("BTCUSDT", handler), "Trades");
        }

        [Test]
        public async Task ValidateOptionSubscriptions()
        {
            var client = new BybitSocketClient(opts =>
            {
                opts.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "456");
            });
            var tester = new SocketSubscriptionValidator<BybitSocketClient>(client, "Subscriptions/V5/Option", "https://api.binance.com", "data", stjCompare: false);
            await tester.ValidateAsync<BybitOptionTickerUpdate>((client, handler) => client.V5OptionsApi.SubscribeToTickerUpdatesAsync("BTC", handler), "Ticker");
            await tester.ValidateAsync<IEnumerable<BybitOptionTrade>>((client, handler) => client.V5OptionsApi.SubscribeToTradeUpdatesAsync("BTC", handler), "Trades");
            await tester.ValidateAsync<BybitOrderbook>((client, handler) => client.V5OptionsApi.SubscribeToOrderbookUpdatesAsync("BTCUSDT", 25, handler), "Book");
            await tester.ValidateAsync<IEnumerable<BybitKlineUpdate>>((client, handler) => client.V5OptionsApi.SubscribeToKlineUpdatesAsync("BTCUSDT", Enums.KlineInterval.OneMonth, handler), "Klines");
            await tester.ValidateAsync<BybitLiquidation>((client, handler) => client.V5OptionsApi.SubscribeToLiquidationUpdatesAsync("BTCUSDT", handler), "Liquidations");
        }

        [Test]
        public async Task ValidateLinearSubscriptions()
        {
            var client = new BybitSocketClient(opts =>
            {
                opts.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "456");
            });
            var tester = new SocketSubscriptionValidator<BybitSocketClient>(client, "Subscriptions/V5/Linear", "https://api.bybit.com", "data", stjCompare: false);
            await tester.ValidateAsync<BybitLinearTickerUpdate>((client, handler) => client.V5LinearApi.SubscribeToTickerUpdatesAsync("BTCUSDT", handler), "Ticker");
            await tester.ValidateAsync<IEnumerable<BybitTrade>>((client, handler) => client.V5LinearApi.SubscribeToTradeUpdatesAsync("BTCUSDT", handler), "Trades");
        }

        [Test]
        public async Task ValidatePrivateSubscriptions()
        {
            var client = new BybitSocketClient(opts =>
            {
                opts.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "456");
            });
            var tester = new SocketSubscriptionValidator<BybitSocketClient>(client, "Subscriptions/V5/Private", "https://api.bybit.com", "data", stjCompare: false);
            await tester.ValidateAsync<IEnumerable<BybitPositionUpdate>>((client, handler) => client.V5PrivateApi.SubscribeToPositionUpdatesAsync(handler), "Position", ignoreProperties: new List<string> { "entryPrice" }, addressPath: "/v5/private");
            await tester.ValidateAsync<IEnumerable<BybitUserTradeUpdate>>((client, handler) => client.V5PrivateApi.SubscribeToUserTradeUpdatesAsync(handler), "UserTrades", addressPath: "/v5/private");
            await tester.ValidateAsync<IEnumerable<BybitMinimalUserTradeUpdate>>((client, handler) => client.V5PrivateApi.SubscribeToMinimalUserTradeUpdatesAsync(handler), "MinimalUserTrades", addressPath: "/v5/private");
            await tester.ValidateAsync<IEnumerable<BybitOrderUpdate>>((client, handler) => client.V5PrivateApi.SubscribeToOrderUpdatesAsync(handler), "Order", addressPath: "/v5/private");
            await tester.ValidateAsync<IEnumerable<BybitBalance>>((client, handler) => client.V5PrivateApi.SubscribeToWalletUpdatesAsync(handler), "Balance", addressPath: "/v5/private");
            await tester.ValidateAsync<IEnumerable<BybitGreeks>>((client, handler) => client.V5PrivateApi.SubscribeToGreekUpdatesAsync(handler), "Greeks", addressPath: "/v5/private");
        }
    }
}
