﻿using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitUnifiedQuery : Query<BybitOptionsQueryResponse>
    {
        public override HashSet<string> ListenerIdentifiers { get; set; }

        public BybitUnifiedQuery(string op, params object[] args) : base(new BybitRequestMessage { RequestId = ExchangeHelpers.NextId().ToString(), Operation = op, Args = args?.ToList() }, false, 1)
        {
            if (string.Equals(op, "auth", StringComparison.Ordinal))
                ListenerIdentifiers = new HashSet<string>() { "AUTH_RESP" };
            else
                ListenerIdentifiers = new HashSet<string>() { "COMMAND_RESP" };
        }

        public override CallResult<BybitOptionsQueryResponse> HandleMessage(SocketConnection connection, DataEvent<BybitOptionsQueryResponse> message)
        {
            if (!message.Data.Success)
                return new CallResult<BybitOptionsQueryResponse>(new ServerError(message.Data.Message));

            return new CallResult<BybitOptionsQueryResponse>(message.Data);
        }
    }
}
