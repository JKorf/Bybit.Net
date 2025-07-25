﻿using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System.Collections.Generic;
using System.Linq;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitRequestQuery<T> : Query<T>
    {
        public BybitRequestQuery(string op, Dictionary<string, string>? headers, params object[]? args) : 
            base(new BybitRequestQueryMessage { RequestId = ExchangeHelpers.NextId().ToString(), Header = headers, Operation = op, Args = args?.ToArray() }, true, 1)
        {
            MessageMatcher = MessageMatcher.Create<BybitRequestQueryResponse<T>>(((BybitRequestQueryMessage)Request).RequestId, HandleMessage);
        }

        public CallResult<T> HandleMessage(SocketConnection connection, DataEvent<BybitRequestQueryResponse<T>> message)
        {
            if (message.Data.ReturnCode != 0)
                return new CallResult<T>(new ServerError(message.Data.ReturnCode, message.Data.ReturnMessage), message.OriginalData);

            return message.ToCallResult(message.Data.Data!);
        }
    }
}
