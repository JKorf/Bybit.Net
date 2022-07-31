using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoExchange.Net.Interfaces;
using Bybit.Net.UnitTests;
using Bybit.Net.Testing;
using Bybit.Net.Objects;
using Bybit.Net.Clients;

namespace Bybit.Net.UnitTests
{
    [TestFixture]
    public class JsonTests
    {
        private JsonToObjectComparer<BybitClient> _comparer = new JsonToObjectComparer<BybitClient>((json) => TestHelpers.CreateResponseClient(json, new BybitClientOptions()
        { 
            ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "123"), 
            OutputOriginalData = true, 
            SpotApiOptions = new CryptoExchange.Net.Objects.RestApiClientOptions
            {
                RateLimiters = new List<IRateLimiter>()
            },
            InverseFuturesApiOptions = new CryptoExchange.Net.Objects.RestApiClientOptions
            {
                RateLimiters = new List<IRateLimiter>()
            },
            InversePerpetualApiOptions = new CryptoExchange.Net.Objects.RestApiClientOptions
            {
                RateLimiters = new List<IRateLimiter>()
            },
            UsdPerpetualApiOptions = new CryptoExchange.Net.Objects.RestApiClientOptions
            {
                RateLimiters = new List<IRateLimiter>()
            }
        },
            System.Net.HttpStatusCode.OK));

        [Test]
        public async Task ValidateFuturesAccountCalls()
        {   
            await _comparer.ProcessSubject("InversePerpetual/Account", c => c.InversePerpetualApi.Account,
                useNestedJsonPropertyForCompare: new Dictionary<string, string> 
                {
                    { "GetWalletFundHistoryAsync", "data" },
                    { "GetWithdrawalHistoryAsync", "data" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                    { "GetWithdrawalHistoryAsync", new List<string> { "current_page", "last_page" } },
                    { "GetPositionAsync", new List<string> { "oc_calc_data" } }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" },
                parametersToSetNull: new string[] {  }
                );
        }

        [Test]
        public async Task ValidateFuturesExchangeDataCalls()
        {
            await _comparer.ProcessSubject("InversePerpetual/ExchangeData", c => c.InversePerpetualApi.ExchangeData,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {

                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" },
                parametersToSetNull: new string[] { }
                );
        }


        [Test]
        public async Task ValidateFuturesTradingCalls()
        {
            await _comparer.ProcessSubject("InversePerpetual/Trading", c => c.InversePerpetualApi.Trading,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetUserTradesAsync", "trade_list" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                    { "GetOpenOrderRealTimeAsync", new List<string> { "ext_fields" } },
                    { "GetOpenOrdersRealTimeAsync", new List<string> { "ext_fields" } },
                    { "GetOpenConditionalOrderRealTimeAsync", new List<string> { "ext_fields" } },
                    { "GetOpenConditionalOrdersRealTimeAsync", new List<string> { "ext_fields" } },
                    { "SetTradingStopAsync", new List<string> { "oc_calc_data", "ext_fields" } }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" },
                parametersToSetNull: new string[] { "clientOrderId" }
                );
        }

        [Test]
        public async Task ValidateSpotAccountCalls()
        {
            await _comparer.ProcessSubject("Spot/Account", c => c.SpotApi.Account,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetBalancesAsync", "balances" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" },
                parametersToSetNull: new string[] { }
                );
        }

        [Test]
        public async Task ValidateSpotTradingCalls()
        {
            await _comparer.ProcessSubject("Spot/Trading", c => c.SpotApi.Trading,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                    { "PlaceOrderAsync", new List<string>{ "executedQty" } },
                    { "CancelOrderAsync", new List<string>{ "executedQty" } }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" },
                parametersToSetNull: new string[] { "clientOrderId" }

                );
        }

        [Test]
        public async Task ValidateSpotExchangeDataCalls()
        {
            await _comparer.ProcessSubject("Spot/ExchangeData", c => c.SpotApi.ExchangeData,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                    { "GetKlinesAsync", new List<string>() { "CloseTime" } }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }

                );
        }

        [Test]
        public async Task ValidateGeneralTransferCalls()
        {
            await _comparer.ProcessSubject("General/Transfer", c => c.GeneralApi.Transfer,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }

                );
        }

        [Test]
        public async Task ValidateGeneralDepositWithdrawalCalls()
        {
            await _comparer.ProcessSubject("General/DepositWithdraw", c => c.GeneralApi.WithdrawDeposit,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetSupportedDepositMethodsAsync", "config_list" },
                    { "GetAssetInfoAsync", "rows" },
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }

                );
        }

        [Test]
        public async Task ValidateUsdPerpetualAccountCalls()
        {
            await _comparer.ProcessSubject("UsdPerpetual/Account", c => c.UsdPerpetualApi.Account,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }

                );
        }

        [Test]
        public async Task ValidateUsdPerpetualExchangeDataCalls()
        {
            await _comparer.ProcessSubject("UsdPerpetual/ExchangeData", c => c.UsdPerpetualApi.ExchangeData,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                    { "GetKlinesAsync", new List<string>{ "id", "period", "start_at" } }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }

                );
        }

        [Test]
        public async Task ValidateUsdPerpetualTradingCalls()
        {
            await _comparer.ProcessSubject("UsdPerpetual/Trading", c => c.UsdPerpetualApi.Trading,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                    { "GetUserTradesAsync", new List<string> { "trade_time" } }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }

        [Test]
        public async Task ValidateCopyTradingAccountCalls()
        {
            await _comparer.ProcessSubject("CopyTrading/Account", c => c.CopyTradingApi.Account,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }

        [Test]
        public async Task ValidateCopyTradingExchangeDataCalls()
        {
            await _comparer.ProcessSubject("CopyTrading/ExchangeData", c => c.CopyTradingApi.ExchangeData,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetSymbolsAsync", "list" },
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }

        [Test]
        public async Task ValidateCopyTradingTradingCalls()
        {
            await _comparer.ProcessSubject("CopyTrading/Trading", c => c.CopyTradingApi.Trading,
                parametersToSetNull: new[] { "clientOrderId" }, 
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetPositionsAsync", "list" },
                    { "GetOrdersAsync", "list" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }
    }
}
