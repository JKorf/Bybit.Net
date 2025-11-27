using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitRequestQuery<T> : Query<T>
    {
        private readonly SocketApiClient _client;

        public BybitRequestQuery(SocketApiClient client, string op, Dictionary<string, string>? headers, params object[]? args) : 
            base(new BybitRequestQueryMessage { RequestId = ExchangeHelpers.NextId().ToString(), Header = headers, Operation = op, Args = args?.ToArray() }, true, 1)
        {
            _client = client;

            MessageMatcher = MessageMatcher.Create<BybitRequestQueryResponse<T>>(((BybitRequestQueryMessage)Request).RequestId, HandleMessage);
            MessageRouter = MessageRouter.Create<BybitRequestQueryResponse<T>>(((BybitRequestQueryMessage)Request).RequestId, HandleMessage);
        }

        public CallResult<T> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BybitRequestQueryResponse<T> message)
        {
            if (message.ReturnCode != 0)
                return new CallResult<T>(new ServerError(message.ReturnCode, _client.GetErrorInfo(message.ReturnCode, message.ReturnMessage)), originalData);

            return new CallResult<T>(message.Data, originalData, null);
        }
    }
}
