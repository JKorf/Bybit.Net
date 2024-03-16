using Bybit.Net.Clients;
using Bybit.Net.Objects.Internal;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
