using CryptoExchange.Net;
using CryptoExchange.Net.Sockets;
using System;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitPingQuery : Query<BybitPong>
    {
        public BybitPingQuery() : base(new BybitRequestMessage { RequestId = ExchangeHelpers.NextId().ToString(), Operation = "ping", Args = null }, false, 1)
        {
            RequestTimeout = TimeSpan.FromSeconds(5);
            MessageRouter = MessageRouter.CreateWithoutHandler<BybitPong>("pong");
        }
    }
}
