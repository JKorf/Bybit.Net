using Bybit.Net.Clients;
using Bybit.Net.Objects;
using Bybit.Net.SymbolOrderBooks;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bybit.Net.UnitTests
{
    [NonParallelizable]
    internal class BybitRestIntegrationTests : RestIntegrationTest<BybitRestClient>
    {
        public override bool Run { get; set; }

        public BybitRestIntegrationTests()
        {
        }

        public override BybitRestClient GetClient(ILoggerFactory loggerFactory)
        {
            var key = Environment.GetEnvironmentVariable("APIKEY");
            var sec = Environment.GetEnvironmentVariable("APISECRET");

            Authenticated = key != null && sec != null;
            return new BybitRestClient(null, loggerFactory, Options.Create(new Objects.Options.BybitRestOptions
            {
                OutputOriginalData = true,
                ApiCredentials = Authenticated ? new ApiCredentials(key, sec) : null
            }));
        }

        [Test]
        public async Task TestErrorResponseParsing()
        {
            if (!ShouldRun())
                return;

            var result = await CreateClient().V5Api.ExchangeData.GetSpotTickersAsync("TST_TST", default);

            Assert.That(result.Success, Is.False);
            Assert.That(result.Error.ErrorCode, Is.EqualTo("10001"));
            Assert.That(result.Error.ErrorType, Is.EqualTo(ErrorType.UnknownSymbol));
        }

        [Test]
        public async Task TestV5Account()
        {
            await RunAndCheckResult(client => client.V5Api.Account.GetBalancesAsync(Enums.AccountType.Unified, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetBorrowHistoryAsync(default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetCollateralInfoAsync(default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetAssetGreeksAsync(default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetFeeRateAsync(Enums.Category.Spot, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetMarginAccountInfoAsync(default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetTransactionHistoryAsync(default, default, default, default, default, default, default, default, default,  default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetAssetInfoAsync(default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetWithdrawalsAsync(default, default, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetDelayedWithdrawQuantityAsync("ETH", default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetApiKeyInfoAsync(default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetAccountTypesAsync(default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetSpotMarginStatusAndLeverageAsync(default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetSpotMarginDataAsync(default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetSpotMarginInterestRateHistoryAsync("ETH", default, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetConvertAssetsAsync(Enums.ConvertAccountType.ConvertUta, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Account.GetConvertHistoryAsync(Enums.ConvertAccountType.ConvertUta, default, default, default), true);

            // Only available to broker account
            //await RunAndCheckResult(client => client.V5Api.Account.GetBrokerAccountInfoAsync(default), true);
            //await RunAndCheckResult(client => client.V5Api.Account.GetBrokerEarningsAsync(default, default, default, default, default, default, default), true);
        }

        [Test]
        public async Task TestV5ExchangeData()
        {
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetServerTimeAsync(default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetKlinesAsync(Enums.Category.Spot, "ETHUSDT", Enums.KlineInterval.OneDay, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetMarkPriceKlinesAsync(Enums.Category.Linear, "ETHUSDT", Enums.KlineInterval.OneDay, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetIndexPriceKlinesAsync(Enums.Category.Linear, "ETHUSDT", Enums.KlineInterval.OneDay, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetPremiumIndexPriceKlinesAsync(Enums.Category.Linear, "ETHUSDT", Enums.KlineInterval.OneDay, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetSpotSymbolsAsync(default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetOptionSymbolsAsync(default, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetLinearInverseSymbolsAsync(default, default, default, default, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetOrderbookAsync(Enums.Category.Spot, "ETHUSDT", default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetSpotTickersAsync(default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetOptionTickersAsync(default, "BTC", default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetLinearInverseTickersAsync(Enums.Category.Linear, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetFundingRateHistoryAsync(Enums.Category.Linear, "ETHUSDT", default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetTradeHistoryAsync(Enums.Category.Linear, "ETHUSDT", default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetOpenInterestAsync(Enums.Category.Linear, "ETHUSDT", Enums.OpenInterestInterval.OneDay, default, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetHistoricalVolatilityAsync(default, default, default, default, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetInsuranceAsync("ETH", default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetRiskLimitAsync(Enums.Category.Linear, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetDeliveryPriceAsync(Enums.Category.Linear, default, default, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetLongShortRatioAsync(Enums.Category.Linear, "ETHUSDT", Enums.DataPeriod.OneDay, default, default, default, default), false);
            await RunAndCheckResult(client => client.V5Api.ExchangeData.GetOrderPriceLimitAsync("ETHUSDT", default, default), false);
        }

        [Test]
        public async Task TestV5Trading()
        {
            await RunAndCheckResult(client => client.V5Api.Trading.GetOrdersAsync(Enums.Category.Spot, default, default, default, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Trading.GetOrderHistoryAsync(Enums.Category.Spot, default, default, default, default, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Trading.GetBorrowQuotaAsync("ETHUSDT", Enums.OrderSide.Buy, default), true);
            await RunAndCheckResult(client => client.V5Api.Trading.GetDisconnectCancelAllConfigAsync(default), true);
            await RunAndCheckResult(client => client.V5Api.Trading.GetUserTradesAsync(Enums.Category.Spot, default, default, default, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Trading.GetPositionsAsync(Enums.Category.Linear, default, default, "USDT", default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Trading.GetAssetExchangeHistoryAsync(default, default, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Trading.GetDeliveryHistoryAsync(Enums.Category.Linear, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Trading.GetSettlementHistoryAsync(Enums.Category.Linear, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.V5Api.Trading.GetClosedProfitLossAsync(Enums.Category.Linear, default, default, default, default, default, default), true);
        }

        [Test]
        public async Task TestOrderBooks()
        {
            await TestOrderBook(new BybitSymbolOrderBook("ETHUSDT", Enums.Category.Spot));
        }
    }
}
