using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System.Collections.Generic;
using System.Linq;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitOptionsQuery : Query<BybitOptionsQueryResponse>
    {
        public BybitOptionsQuery(string op, params object[] args) : base(new BybitRequestMessage { RequestId = ExchangeHelpers.NextId().ToString(), Operation = op, Args = args?.ToArray() }, false, 1)
        {
            MessageMatcher = MessageMatcher.Create<BybitOptionsQueryResponse>("resp" + string.Join("-", args!.OrderBy(a => a)), HandleMessage);
        }

        public CallResult<BybitOptionsQueryResponse> HandleMessage(SocketConnection connection, DataEvent<BybitOptionsQueryResponse> message)
        {
            if (!message.Data.Success)
                return new CallResult<BybitOptionsQueryResponse>(new ServerError(ErrorInfo.Unknown with { Message = message.Data.Message }), message.OriginalData);

            return message.ToCallResult();
        }
    }
}
