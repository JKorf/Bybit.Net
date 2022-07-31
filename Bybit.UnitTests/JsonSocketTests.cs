using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Models.CopyTrading;
using Bybit.Net.Objects.Models.Socket;
using Bybit.Net.Objects.Models.Socket.Spot;
using Bybit.Net.Objects.Models.Spot;
using Bybit.Net.UnitTests;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Bybit.UnitTests
{
    internal class JsonSocketTests
    {
        [Test]
        public async Task ValidateTradeUpdateStreamJson()
        {
            await TestFileToObject<BybitSpotTradeUpdate>(@"JsonResponses/Spot/Socket/TradeUpdate.txt");
        }

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
        public async Task ValidateBookPriceUpdateStreamJson()
        {
            await TestFileToObject<BybitSpotBookPrice>(@"JsonResponses/Spot/Socket/BookPriceUpdate.txt");
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
        public async Task ValidateIPTradeUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitTradeUpdate>>(@"JsonResponses/InversePerpetual/Socket/TradeUpdate.txt");
        }

        [Test]
        public async Task ValidateIPTickerUpdateStreamJson()
        {
            await TestFileToObject<BybitTickerUpdate>(@"JsonResponses/InversePerpetual/Socket/TickerUpdate.txt", 
                new List<string>
                {
                    // Deprecated
                    "last_price_e4",
                    "prev_price_24h_e4",
                    "high_price_24h_e4",
                    "low_price_24h_e4",
                    "prev_price_1h_e4",
                    "mark_price_e4",
                    "index_price_e4",
                    "ask1_price_e4",
                    "bid1_price_e4",
                });
        }

        [Test]
        public async Task ValidateIPInsuranceUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitInsuranceUpdate>>(@"JsonResponses/InversePerpetual/Socket/InsuranceUpdate.txt");
        }

        [Test]
        public async Task ValidateIPKlineUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitKlineUpdate>>(@"JsonResponses/InversePerpetual/Socket/KlineUpdate.txt");
        }

        [Test]
        public async Task ValidateIPLiquidationUpdateStreamJson()
        {
            await TestFileToObject<BybitLiquidationUpdate>(@"JsonResponses/InversePerpetual/Socket/LiquidationUpdate.txt");
        }

        [Test]
        public async Task ValidateIPPositionUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitPositionUpdate>>(@"JsonResponses/InversePerpetual/Socket/PositionUpdate.txt");
        }

        [Test]
        public async Task ValidateIPUserTradeUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitUserTradeUpdate>>(@"JsonResponses/InversePerpetual/Socket/UserTradeUpdate.txt");
        }

        [Test]
        public async Task ValidateIPOrderUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitInverseOrderUpdate>>(@"JsonResponses/InversePerpetual/Socket/OrderUpdate.txt");
        }

        [Test]
        public async Task ValidateIPStopOrderUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitStopOrderUpdate>>(@"JsonResponses/InversePerpetual/Socket/StopOrderUpdate.txt");
        }

        [Test]
        public async Task ValidateIPBalanceUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitBalanceUpdate>>(@"JsonResponses/InversePerpetual/Socket/BalanceUpdate.txt");
        }

        [Test]
        public async Task ValidateUPTradeUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitTradeUpdate>>(@"JsonResponses/UsdPerpetual/Socket/TradeUpdate.txt");
        }

        [Test]
        public async Task ValidateUPTickerUpdateStreamJson()
        {
            await TestFileToObject<BybitTickerUpdate>(@"JsonResponses/UsdPerpetual/Socket/TickerUpdate.txt",
                new List<string>
                {
                    // Deprecated
                    "last_price_e4",
                    "prev_price_24h_e4",
                    "high_price_24h_e4",
                    "low_price_24h_e4",
                    "prev_price_1h_e4",
                    "mark_price_e4",
                    "index_price_e4",
                    "ask1_price_e4",
                    "bid1_price_e4",
                });
        }

        [Test]
        public async Task ValidateUPKlineUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitKlineUpdate>>(@"JsonResponses/UsdPerpetual/Socket/KlineUpdate.txt");
        }

        [Test]
        public async Task ValidateUPLiquidationUpdateStreamJson()
        {
            await TestFileToObject<BybitLiquidationUpdate>(@"JsonResponses/UsdPerpetual/Socket/LiquidationUpdate.txt");
        }

        [Test]
        public async Task ValidateUPPositionUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitPositionUsdPerpetualUpdate>>(@"JsonResponses/UsdPerpetual/Socket/PositionUpdate1.txt");
            await TestFileToObject<IEnumerable<BybitPositionUsdPerpetualUpdate>>(@"JsonResponses/UsdPerpetual/Socket/PositionUpdate2.txt");
        }

        [Test]
        public async Task ValidateUPUserTradeUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitUserTradeUpdate>>(@"JsonResponses/UsdPerpetual/Socket/UserTradeUpdate.txt");
        }

        [Test]
        public async Task ValidateUPOrderUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitUsdPerpetualOrderUpdate>>(@"JsonResponses/UsdPerpetual/Socket/OrderUpdate1.txt");
            await TestFileToObject<IEnumerable<BybitUsdPerpetualOrderUpdate>>(@"JsonResponses/UsdPerpetual/Socket/OrderUpdate2.txt");
        }

        [Test]
        public async Task ValidateUPStopOrderUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitUsdPerpetualStopOrderUpdate>>(@"JsonResponses/UsdPerpetual/Socket/StopOrderUpdate.txt");
        }

        [Test]
        public async Task ValidateUPBalanceUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BybitBalanceUpdate>>(@"JsonResponses/UsdPerpetual/Socket/BalanceUpdate.txt");
        }

        [Test]
        public async Task ValidateCopyBalanceUpdateStreamJson()
        {
            await TestFileToObject<BybitCopyTradingBalanceUpdate>(@"JsonResponses/CopyTrading/Socket/BalanceUpdate.txt");
            await TestFileToObject<IEnumerable<BybitCopyTradingPositionUpdate>>(@"JsonResponses/CopyTrading/Socket/PositionUpdate.txt");
            await TestFileToObject<IEnumerable<BybitCopyTradingOrderUpdate>>(@"JsonResponses/CopyTrading/Socket/OrderUpdate.txt");
            await TestFileToObject<IEnumerable<BybitCopyTradingUserTradeUpdate>>(@"JsonResponses/CopyTrading/Socket/TradeUpdate.txt");
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
