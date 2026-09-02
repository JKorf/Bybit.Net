using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    internal partial class BybitSocketClientPrivateSharedApi : 
        SharedApiBase,
        IBybitSocketClientPrivateApiShared,
        IBybitSocketClientPrivateSharedApi
    {
        private readonly BybitSocketClientPrivateApi _api;

        private const string _topicSpotId = "BybitSpot";
        private const string _topicFuturesId = "BybitFutures";

        private const string _exchangeName = "Bybit";

        public override SharedClientInfo Discover() => SharedUtils.GetClientInfo(BybitExchange.Metadata, this);

        public BybitSocketClientPrivateSharedApi(BybitSocketClientPrivateApi api)
            : base(
                  SharedTransport.Socket,
                  api.Exchange,
                  [TradingMode.Spot, TradingMode.PerpetualLinear, TradingMode.PerpetualInverse, TradingMode.DeliveryLinear, TradingMode.DeliveryInverse],
                  () => api.Authenticated,
                  api.FormatSymbol)
        {
            _api = api;

            SetCapabilities(
                SubscribeBalanceOptions,
                SubscribeSpotOrderOptions,
                SubscribeFuturesOrderOptions,
                SubscribeUserTradeOptions,
                SubscribePositionOptions,
                PlaceSpotOrderOptions,
                CancelSpotOrderOptions,
                PlaceFuturesOrderOptions,
                CancelFuturesOrderOptions
                );
        }
    }
}
