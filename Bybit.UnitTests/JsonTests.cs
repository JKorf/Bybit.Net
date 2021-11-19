using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoExchange.Net.Interfaces;
using ByBit.Net.Clients.Rest.InversePerptual;
using Bybit.Net.UnitTests;
using Bybit.Net.Testing;
using ByBit.Net.Objects;

namespace CoinEx.Net.UnitTests
{
    [TestFixture]
    public class JsonTests
    {
        private JsonToObjectComparer<BybitClientInversePerpetual> _comparer = new JsonToObjectComparer<BybitClientInversePerpetual>((json) => TestHelpers.CreateResponseClient(json, new BybitClientInversePerpetualOptions()
        { ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "123"), OutputOriginalData = true, RateLimiters = new List<IRateLimiter>() }, System.Net.HttpStatusCode.OK));

        [Test]
        public async Task ValidateInversePerpetualAccountCalls()
        {   
            await _comparer.ProcessSubject("InversePerpetual/Account", c => c.Account,
                useNestedJsonPropertyForCompare: new Dictionary<string, string> 
                {
                    { "GetWalletFundHistoryAsync", "data" },
                    { "GetWithdrawalHistoryAsync", "data" },
                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                    { "GetWithdrawalHistoryAsync", new List<string> { "current_page", "last_page" } }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" },
                parametersToSetNull: new string[] {  }
                );
        }

        [Test]
        public async Task ValidateInversePerpetualExchangeDataCalls()
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
        public async Task ValidateInversePerpetualTradingCalls()
        {
            await _comparer.ProcessSubject("InversePerpetual/Trading", c => c.Trading,
                useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {

                },
                ignoreProperties: new Dictionary<string, List<string>>
                {
                    { "GetOpenOrderRealTimeAsync", new List<string> { "ext_fields" } },
                    { "GetOpenOrdersRealTimeAsync", new List<string> { "ext_fields" } }
                },
                useNestedJsonPropertyForAllCompare: new List<string> { "result" },
                parametersToSetNull: new string[] { "clientOrderId" }
                );
        }
    }
}
