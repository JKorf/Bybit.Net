using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitOptionsQuery : Query<BybitOptionsQueryResponse>
    {
        public BybitOptionsQuery(string op, params object[] args) : base(new BybitRequestMessage { RequestId = ExchangeHelpers.NextId().ToString(), Operation = op, Args = args?.ToArray() }, false, 1)
        {
            MessageMatcher = MessageMatcher.Create<BybitOptionsQueryResponse>("resp" + string.Join("-", args!.OrderBy(a => a)), HandleMessage);
            MessageRouter = MessageRouter.CreateWithoutTopicFilter<BybitOptionsQueryResponse>("resp" + string.Join("-", args!.OrderBy(a => a)), HandleMessage);
        }

        public CallResult<BybitOptionsQueryResponse> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BybitOptionsQueryResponse message)
        {
            if (!message.Success)
                return new CallResult<BybitOptionsQueryResponse>(new ServerError(ErrorInfo.Unknown with { Message = message.Message }), originalData);

            return new CallResult<BybitOptionsQueryResponse>(message, originalData, null);
        }
    }
}
