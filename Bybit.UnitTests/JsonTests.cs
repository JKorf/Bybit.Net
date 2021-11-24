using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoExchange.Net.Interfaces;
using Bybit.Net.UnitTests;
using Bybit.Net.Testing;
using Bybit.Net.Objects;
using Bybit.Net.Clients.Rest.Futures;

namespace CoinEx.Net.UnitTests
{
    [TestFixture]
    public class JsonTests
    {
        private JsonToObjectComparer<BybitClientUsdFutures> _comparer = new JsonToObjectComparer<BybitClientUsdFutures>((json) => TestHelpers.CreateResponseClient(json, new BybitClientFuturesOptions()
        { ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "123"), OutputOriginalData = true, RateLimiters = new List<IRateLimiter>() }, System.Net.HttpStatusCode.OK));

        private JsonToObjectComparer<BybitClientCoinFutures> _comparerCoin = new JsonToObjectComparer<BybitClientCoinFutures>((json) => TestHelpers.CreateResponseClientCoin(json, new BybitClientFuturesOptions()
        { ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "123"), OutputOriginalData = true, RateLimiters = new List<IRateLimiter>() }, System.Net.HttpStatusCode.OK));

        [Test]
        public async Task ValidateFuturesAccountCalls()
        {   
            await _comparer.ProcessSubject("InversePerpetual/Account", c => c.Account,
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
            await _comparer.ProcessSubject("InversePerpetual/ExchangeData", c => c.ExchangeData,
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
            await _comparer.ProcessSubject("InversePerpetual/Trading", c => c.Trading,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetUserTradesAsync", "trade_list" }
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                    { "GetOpenOrderRealTimeAsync", new List<string> { "ext_fields" } },
                    { "GetOpenOrdersRealTimeAsync", new List<string> { "ext_fields" } },
                    { "GetOpenConditionalOrderRealTimeAsync", new List<string> { "ext_fields" } },
                    { "GetOpenConditionalOrdersRealTimeAsync", new List<string> { "ext_fields" } }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" },
                parametersToSetNull: new string[] { "clientOrderId" }
                );
        }
    }
}
