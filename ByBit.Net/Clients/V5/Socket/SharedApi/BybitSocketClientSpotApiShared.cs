using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitSocketClientSpotSharedApi :
        SharedApiBase,
        IBybitSocketClientSpotApiShared,
        IBybitSocketClientSpotSharedApi
    {
        private readonly BybitSocketClientSpotApi _api;

        private const string _topicId = "BybitSpot";

        private const string _exchangeName = "Bybit";

        public override SharedClientInfo Discover() => SharedUtils.GetClientInfo(BybitExchange.Metadata, this);

        public BybitSocketClientSpotSharedApi(BybitSocketClientSpotApi api)
            : base(
                  SharedTransport.Socket,
                  api.Exchange,
                  [TradingMode.Spot],
                  () => api.Authenticated,
                  api.FormatSymbol)
        {
            _api = api;

            SetCapabilities(
                SubscribeTickerOptions,
                SubscribeTradeOptions,
                SubscribeBookTickerOptions,
                SubscribeKlineOptions
                );
        }
    }
}
