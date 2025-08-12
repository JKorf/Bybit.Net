using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Objects.Internal;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CryptoExchange.Net.Objects;
using Bybit.Net.Interfaces.Clients;
using System.Text.Json;
using CryptoExchange.Net.Converters.SystemTextJson;

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
                ReturnMessage = "Error occurred"
            };

            TestHelpers.SetResponse(client, JsonSerializer.Serialize(resultObj));

            // act
            var result = await client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
            Assert.That(result.Error!.ErrorCode == "400001");
            Assert.That(result.Error.Message == "Error occurred");
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
                ReturnMessage = "Error occurred"
            };

            TestHelpers.SetResponse(client, JsonSerializer.Serialize(resultObj), System.Net.HttpStatusCode.BadRequest);

            // act
            var result = await client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
            Assert.That(result.Error!.ErrorCode == "400001");
            Assert.That(result.Error.Message == "Error occurred");
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
                DateTimeConverter.ParseFromDouble(1658384314791),
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
                DateTimeConverter.ParseFromDouble(1658385579423),
                true,
                false);
        }

        [Test]
        [TestCase(TradeEnvironmentNames.Live, "https://api.bybit.com")]
        [TestCase("", "https://api.bybit.com")]
        public void TestConstructorEnvironments(string environmentName, string expected)
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "Bybit:Environment:Name", environmentName },
                }).Build();

            var collection = new ServiceCollection();
            collection.AddBybit(configuration.GetSection("Bybit"));
            var provider = collection.BuildServiceProvider();

            var client = provider.GetRequiredService<IBybitRestClient>();

            var address = client.V5Api.BaseAddress;

            Assert.That(address, Is.EqualTo(expected));
        }

        [Test]
        public void TestConstructorNullEnvironment()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "Bybit", null },
                }).Build();

            var collection = new ServiceCollection();
            collection.AddBybit(configuration.GetSection("Bybit"));
            var provider = collection.BuildServiceProvider();

            var client = provider.GetRequiredService<IBybitRestClient>();

            var address = client.V5Api.BaseAddress;

            Assert.That(address, Is.EqualTo("https://api.bybit.com"));
        }

        [Test]
        public void TestConstructorApiOverwriteEnvironment()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "Bybit:Environment:Name", "test" },
                    { "Bybit:Rest:Environment:Name", "live" },
                }).Build();

            var collection = new ServiceCollection();
            collection.AddBybit(configuration.GetSection("Bybit"));
            var provider = collection.BuildServiceProvider();

            var client = provider.GetRequiredService<IBybitRestClient>();

            var address = client.V5Api.BaseAddress;

            Assert.That(address, Is.EqualTo("https://api.bybit.com"));
        }

        [Test]
        public void TestConstructorConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "ApiCredentials:Key", "123" },
                    { "ApiCredentials:Secret", "456" },
                    { "ApiCredentials:Memo", "000" },
                    { "Socket:ApiCredentials:Key", "456" },
                    { "Socket:ApiCredentials:Secret", "789" },
                    { "Socket:ApiCredentials:Memo", "xxx" },
                    { "Rest:OutputOriginalData", "true" },
                    { "Socket:OutputOriginalData", "false" },
                    { "Rest:Proxy:Host", "host" },
                    { "Rest:Proxy:Port", "80" },
                    { "Socket:Proxy:Host", "host2" },
                    { "Socket:Proxy:Port", "81" },
                }).Build();

            var collection = new ServiceCollection();
            collection.AddBybit(configuration);
            var provider = collection.BuildServiceProvider();

            var restClient = provider.GetRequiredService<IBybitRestClient>();
            var socketClient = provider.GetRequiredService<IBybitSocketClient>();

            Assert.That(((BaseApiClient)restClient.V5Api).OutputOriginalData, Is.True);
            Assert.That(((BaseApiClient)socketClient.V5SpotApi).OutputOriginalData, Is.False);
            Assert.That(((BaseApiClient)restClient.V5Api).AuthenticationProvider.ApiKey, Is.EqualTo("123"));
            Assert.That(((BaseApiClient)socketClient.V5SpotApi).AuthenticationProvider.ApiKey, Is.EqualTo("456"));
            Assert.That(((BaseApiClient)restClient.V5Api).ClientOptions.Proxy.Host, Is.EqualTo("host"));
            Assert.That(((BaseApiClient)restClient.V5Api).ClientOptions.Proxy.Port, Is.EqualTo(80));
            Assert.That(((BaseApiClient)socketClient.V5SpotApi).ClientOptions.Proxy.Host, Is.EqualTo("host2"));
            Assert.That(((BaseApiClient)socketClient.V5SpotApi).ClientOptions.Proxy.Port, Is.EqualTo(81));
        }
    }
}
