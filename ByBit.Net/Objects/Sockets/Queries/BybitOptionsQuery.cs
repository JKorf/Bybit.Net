using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using System;
using System.Linq;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitOptionsQuery : Query<BybitOptionsQueryResponse>
    {
        public BybitOptionsQuery(string op, params object[] args) : base(new BybitRequestMessage { RequestId = ExchangeHelpers.NextId().ToString(), Operation = op, Args = args?.ToArray() }, false, 1)
        {
            MessageRouter = MessageRouter.CreateForQuery<BybitOptionsQueryResponse>("resp" + string.Join("-", args!.OrderBy(a => a)), HandleMessage);
        }

        public CallResult<BybitOptionsQueryResponse> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BybitOptionsQueryResponse message)
        {
            if (!message.Success)
                return CallResult<BybitOptionsQueryResponse>.Fail(new ServerError(ErrorInfo.Unknown with { Message = message.Message }), originalData);

            return CallResult<BybitOptionsQueryResponse>.Ok(message, originalData);
        }
    }
}
