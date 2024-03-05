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
        private JsonToObjectComparer<BybitRestClient> _comparer = new JsonToObjectComparer<BybitRestClient>((json) => TestHelpers.CreateResponseClient(json, x =>
        {
            x.ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "123");
            x.SpotOptions.RateLimiters = new List<IRateLimiter>();
            x.SpotOptions.OutputOriginalData = true;
            x.DerivativesOptions.RateLimiters = new List<IRateLimiter>();
            x.DerivativesOptions.OutputOriginalData = true;
            x.V5Options.RateLimiters = new List<IRateLimiter>();
            x.V5Options.OutputOriginalData = true;
        },
            System.Net.HttpStatusCode.OK));

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

        [Test]
        public async Task ValidateDerivativesExchangeDataCalls()
        {
            await _comparer.ProcessSubject("Derivatives/ExchangeData", c => c.DerivativesApi.ExchangeData,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetTickerAsync", "list" },
                    { "GetOpenInterestAsync", "list" },
                    { "GetFundingRateAsync", "list" },
                    { "GetRiskLimitAsync", "list" },
                    { "GetTradeHistoryAsync", "list" },

                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" },
                ignoredMethods: new List<string>
                {
                    "GetKlinesAsync", "GetIndexPriceKlinesAsync", "GetMarkPriceKlinesAsync"
                }
                );
        }

        [Test]
        public async Task ValidateUnifiedMarginTradingCalls()
        {
            await _comparer.ProcessSubject("Derivatives/UnifiedMargin/Trading", c => c.DerivativesApi.UnifiedMarginApi.Trading,
                parametersToSetNull: new[] { "clientOrderId" },
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "CancelAllOrdersAsync", "list" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }

        [Test]
        public async Task ValidateUnifiedMarginAccountCalls()
        {
            await _comparer.ProcessSubject("Derivatives/UnifiedMargin/Account", c => c.DerivativesApi.UnifiedMarginApi.Account,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetBorrowRateAsync", "list" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }

        [Test]
        public async Task ValidateContractTradingCalls()
        {
            await _comparer.ProcessSubject("Derivatives/Contract/Trading", c => c.DerivativesApi.ContractApi.Trading,
                parametersToSetNull: new[] { "clientOrderId" },
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                     { "CancelAllOrdersAsync", "list" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }

        [Test]
        public async Task ValidateContractAccountCalls()
        {
            await _comparer.ProcessSubject("Derivatives/Contract/Account", c => c.DerivativesApi.ContractApi.Account,
                parametersToSetNull: new[] { "settleAsset" },
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                      { "GetBalancesAsync", "list" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }

        [Test]
        public async Task ValidateV5TradingCalls()
        {
            await _comparer.ProcessSubject("V5/Trading", c => c.V5Api.Trading,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetLeverageTokenOrderHistoryAsync", "list" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }

        [Test]
        public async Task ValidateV5AccountCalls()
        {
            await _comparer.ProcessSubject("V5/Account", c => c.V5Api.Account,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetAccountTypesAsync", "accounts" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                    { "AddOrReduceMarginAsync", new List<string>{ "category" } }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }

        [Test]
        public async Task ValidateV5SubAccountCalls()
        {
            await _comparer.ProcessSubject("V5/SubAccount", c => c.V5Api.SubAccount,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetSubAccountsAsync", "subMembers" }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }

        [Test]
        public async Task ValidateV5ExchangeDataCalls()
        {
            await _comparer.ProcessSubject("V5/ExchangeData", c => c.V5Api.ExchangeData,
                useNestedJsonPropertyForCompare: new Dictionary<string, string> {
                },
                ignoreProperties: new Dictionary<string, List<string>> { },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" }
                );
        }
    }
}
