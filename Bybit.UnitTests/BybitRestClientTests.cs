using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CryptoExchange.Net.Converters.JsonNet;

namespace Bybit.UnitTests
{
    public class BybitRestClientTests
    {
        [TestCase()]
        public async Task ReceivingError_Should_ReturnErrorAndNotSuccess()
        {
            // arrange
            var client = TestHelpers.CreateClient();
            var resultObj = new BybitResult<object>()
            {
                ReturnCode = 400001,
                ReturnMessage = "Error occured"
            };

            TestHelpers.SetResponse(client, JsonConvert.SerializeObject(resultObj));

            // act
            var result = await client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
            Assert.That(result.Error!.Code == 400001);
            Assert.That(result.Error.Message == "Error occured");
        }

        [TestCase()]
        public async Task ReceivingHttpErrorWithNoJson_Should_ReturnErrorAndNotSuccess()
        {
            // arrange
            var client = TestHelpers.CreateClient();
            TestHelpers.SetResponse(client, "", System.Net.HttpStatusCode.BadRequest);

            // act
            var result = await client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
        }

        [TestCase()]
        public async Task ReceivingHttpErrorWithJsonError_Should_ReturnErrorAndNotSuccess()
        {
            // arrange
            var client = TestHelpers.CreateClient();
            var resultObj = new BybitResult<object>()
            {
                ReturnCode = 400001,
                ReturnMessage = "Error occured"
            };

            TestHelpers.SetResponse(client, JsonConvert.SerializeObject(resultObj), System.Net.HttpStatusCode.BadRequest);

            // act
            var result = await client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
            Assert.That(result.Error!.Code == 400001);
            Assert.That(result.Error.Message == "Error occured");
        }

        [Test]
        public void CheckSignatureExample1()
        {
            var authProvider = new BybitAuthenticationProvider(new ApiCredentials("XXXXXXXXXX", "XXXXXXXXXX"));
            var client = (RestApiClient)new BybitRestClient().V5Api;

            CryptoExchange.Net.Testing.TestHelpers.CheckSignature(
                client,
                authProvider,
                HttpMethod.Get,
                "",
                (uriParams, bodyParams, headers) =>
                {
                    return headers["X-BAPI-SIGN"].ToString();
                },
                "B3A13CBD6F9DE0AD7ECE696645A98000281BE3558716624CFCA03DEBD2F24574",
                new Dictionary<string, object>
                {
                    { "category", "option" },
                    { "symbol", "BTC-29JUL22-25000-C" },
                },
                DateTimeConverter.ParseFromLong(1658384314791),
                true,
                false);
        }

        [Test]
        public void CheckSignatureExample2()
        {
            var authProvider = new BybitAuthenticationProvider(new ApiCredentials("XXXXXXXXXX", "XXXXXXXXXX"));
            var client = (RestApiClient)new BybitRestClient().V5Api;

            CryptoExchange.Net.Testing.TestHelpers.CheckSignature(
                client,
                authProvider,
                HttpMethod.Post,
                "",
                (uriParams, bodyParams, headers) =>
                {
                    return headers["X-BAPI-SIGN"].ToString();
                },
                "A04DEA33A62E644897B14C6FF458DB428B9C2424B5CB785C9586490CCACA24AF",
                new Dictionary<string, object>
                {
                    { "category", "option" }
                },
                DateTimeConverter.ParseFromLong(1658385579423),
                true,
                false);
        }
    }
}
