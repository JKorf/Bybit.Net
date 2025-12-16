using Bybit.Net.Clients;
using Bybit.Net.Interfaces;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bybit.Net.UnitTests
{
    [TestFixture]
    public class SocketRequestTests
    {
        private BybitSocketClient CreateClient(bool newDeserialization)
        {
            var fact = new LoggerFactory();
            fact.AddProvider(new TraceLoggerProvider());
            var client = new BybitSocketClient(Options.Create(new BybitSocketOptions
            {
                RequestTimeout = TimeSpan.FromSeconds(1),
                UseUpdatedDeserialization = newDeserialization,
                ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials("123", "456")
            }), fact);
            return client;
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ValidateV5PrivateCalls(bool newDeserialization)
        {
            var tester = new SocketRequestValidator<BybitSocketClient>("Socket/V5Api/Private");

            await tester.ValidateAsync(CreateClient(newDeserialization), client => client.V5PrivateApi.PlaceOrderAsync(Enums.Category.Spot, "ETHUSDT", Enums.OrderSide.Buy, Enums.NewOrderType.Limit, 1), "PlaceOrder", nestedJsonProperty: "data");
            await tester.ValidateAsync(CreateClient(newDeserialization), client => client.V5PrivateApi.EditOrderAsync(Enums.Category.Spot, "ETHUSDT", "1"), "EditOrder", nestedJsonProperty: "data");
            await tester.ValidateAsync(CreateClient(newDeserialization), client => client.V5PrivateApi.CancelOrderAsync(Enums.Category.Spot, "ETHUSDT", "1"), "CancelOrder", nestedJsonProperty: "data");
        }
    }
}
