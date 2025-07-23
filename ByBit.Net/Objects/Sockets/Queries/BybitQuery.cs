using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System.Collections.Generic;
using System.Linq;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitQuery : Query<BybitQueryResponse>
    {
        public BybitQuery(string op, params object[]? args) : base(new BybitRequestMessage { RequestId = ExchangeHelpers.NextId().ToString(), Operation = op, Args = args?.ToArray() }, false, 1)
        {
            MessageMatcher = MessageMatcher.Create<BybitQueryResponse>(((BybitRequestMessage)Request).RequestId, HandleMessage);
        }

        public CallResult<BybitQueryResponse> HandleMessage(SocketConnection connection, DataEvent<BybitQueryResponse> message)
        {
            if (!message.Data.Success)
                return new CallResult<BybitQueryResponse>(new ServerError(message.Data.Message), message.OriginalData);

            return message.ToCallResult();
        }
    }
}
