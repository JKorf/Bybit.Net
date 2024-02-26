using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Models.CopyTrading;
using Bybit.Net.Objects.Models.Derivatives.UnifiedMargin;
using Bybit.Net.Objects.Models.Socket;
using Bybit.Net.Objects.Models.Socket.Derivatives;
using Bybit.Net.Objects.Models.Socket.Derivatives.Contract;
using Bybit.Net.Objects.Models.Socket.Derivatives.UnifiedMargin;
using Bybit.Net.Objects.Models.Socket.Spot;
using Bybit.Net.Objects.Models.Spot.v3;
using Bybit.Net.UnitTests;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Bybit.UnitTests
{
    internal class JsonSocketTests
    {
        [Test]
        public async Task ValidateKlineUpdateStreamJson()
        {
            await TestFileToObject<BybitSpotKlineUpdate>(@"JsonResponses/Spot/Socket/KlineUpdate.txt");
        }

        [Test]
        public async Task ValidateOrderBookUpdateStreamJson()
        {
            await TestFileToObject<BybitSpotOrderBookUpdate>(@"JsonResponses/Spot/Socket/OrderBookUpdate.txt", new List<string> { "v" });
        }

        [Test]
        public async Task ValidateBookPriceV3UpdateStreamJson()
        {
            await TestFileToObject<BybitSpotBookPriceV3>(@"JsonResponses/Spot/Socket/BookPriceUpdateV3.txt");
        }

        [Test]
        public async Task ValidateTickerUpdateStreamJson()
        {
            await TestFileToObject<BybitSpotTickerUpdate>(@"JsonResponses/Spot/Socket/TickerUpdate.txt", new List<string> { "m" });
        }

        [Test]
        public async Task ValidateAccountInfoUpdateStreamJson()
        {
            await TestFileToObject<BybitSpotAccountUpdate>(@"JsonResponses/Spot/Socket/AccountInfoUpdate.txt");
        }

        [Test]
        public async Task ValidateOrderUpdateStreamJson()
        {
            await TestFileToObject<BybitSpotOrderUpdate>(@"JsonResponses/Spot/Socket/OrderUpdate.txt");
        }

        [Test]
        public async Task ValidateUserTradeUpdateStreamJson()
        {
            await TestFileToObject<BybitSpotUserTradeUpdate>(@"JsonResponses/Spot/Socket/UserTradeUpdate.txt");
        }

        [Test]
        public async Task ValidateCopyBalanceUpdateStreamJson()
        {
            await TestFileToObject<BybitCopyTradingBalanceUpdate>(@"JsonResponses/CopyTrading/Socket/BalanceUpdate.txt");
            await TestFileToObject<IEnumerable<BybitCopyTradingPositionUpdate>>(@"JsonResponses/CopyTrading/Socket/PositionUpdate.txt");
            await TestFileToObject<IEnumerable<BybitCopyTradingOrderUpdate>>(@"JsonResponses/CopyTrading/Socket/OrderUpdate.txt");
            await TestFileToObject<IEnumerable<BybitCopyTradingUserTradeUpdate>>(@"JsonResponses/CopyTrading/Socket/TradeUpdate.txt");
        }

        [Test]
        public async Task ValidateDerivativesKlineUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitDerivativesKlineUpdate>>(@"JsonResponses/Derivatives/PublicSocket/KlineUpdate.txt");
        }

        [Test]
        public async Task ValidateDerivativesTradeUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitDerivativesTradeUpdate>>(@"JsonResponses/Derivatives/PublicSocket/TradeUpdate.txt");
        }

        [Test]
        public async Task ValidateContractBalanceUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitContractBalanceUpdate>>(@"JsonResponses/Derivatives/Contract/Socket/BalanceUpdate.txt");
        }

        [Test]
        public async Task ValidateContractPositionUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitContractPositionUpdate>>(@"JsonResponses/Derivatives/Contract/Socket/PositionUpdate.txt");
        }

        [Test]
        public async Task ValidateContractUserTradeUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitContractUserTradeUpdate>>(@"JsonResponses/Derivatives/Contract/Socket/UserTradeUpdate.txt");
        }

        [Test]
        public async Task ValidateContractOrderUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitContractOrderUpdate>>(@"JsonResponses/Derivatives/Contract/Socket/OrderUpdate.txt");
        }

        [Test]
        public async Task ValidateUMBalanceUpdateStreamJson()
        {
            await TestFileToObject<BybitUnifiedMarginBalance>(@"JsonResponses/Derivatives/UnifiedMargin/Socket/BalanceUpdate.txt");
        }

        [Test]
        public async Task ValidateUMPositionUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitUnifiedMarginPositionUpdate>>(@"JsonResponses/Derivatives/UnifiedMargin/Socket/PositionUpdate.txt");
        }

        [Test]
        public async Task ValidateUMUserTradeUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitDerivativesUserTradeUpdate>>(@"JsonResponses/Derivatives/UnifiedMargin/Socket/UserTradeUpdate.txt");
        }

        [Test]
        public async Task ValidateUMOrderUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitUnifiedMarginOrderUpdate>>(@"JsonResponses/Derivatives/UnifiedMargin/Socket/OrderUpdate.txt");
        }

        [Test]
        public async Task ValidateUMGreeksUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitGreeksUpdate>>(@"JsonResponses/Derivatives/UnifiedMargin/Socket/GreeksUpdate.txt");
        }

        private static async Task TestFileToObject<T>(string filePath, List<string> ignoreProperties = null)
        {
            var listener = new EnumValueTraceListener();
            Trace.Listeners.Add(listener);
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string json;
            try
            {
                var file = File.OpenRead(Path.Combine(path, filePath));
                using var reader = new StreamReader(file);
                json = await reader.ReadToEndAsync();
            }
            catch (FileNotFoundException)
            {
                throw;
            }

            var result = JsonConvert.DeserializeObject<T>(json);
            JsonToObjectComparer<IBybitSocketClient>.ProcessData("", result, json, ignoreProperties: new Dictionary<string, List<string>>
            {
                { "", ignoreProperties ?? new List<string>() }
            });
            Trace.Listeners.Remove(listener);
        }
    }

    internal class EnumValueTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            if (message.Contains("Cannot map"))
                throw new Exception("Enum value error: " + message);
        }

        public override void WriteLine(string message)
        {
            if (message.Contains("Cannot map"))
                throw new Exception("Enum value error: " + message);
        }
    }
}
