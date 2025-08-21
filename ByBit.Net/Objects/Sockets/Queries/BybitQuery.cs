using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System.Collections.Generic;
using System.Linq;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitQuery : Query<BybitQueryResponse>
    {
        private readonly SocketApiClient _client;

        public BybitQuery(SocketApiClient client, string op, params object[]? args) : base(new BybitRequestMessage { RequestId = ExchangeHelpers.NextId().ToString(), Operation = op, Args = args?.ToArray() }, false, 1)
        {
            _client = client;
            MessageMatcher = MessageMatcher.Create<BybitQueryResponse>(((BybitRequestMessage)Request).RequestId, HandleMessage);
        }

        public CallResult<BybitQueryResponse> HandleMessage(SocketConnection connection, DataEvent<BybitQueryResponse> message)
        {
            if (!message.Data.Success)
                return new CallResult<BybitQueryResponse>(new ServerError(_client.GetErrorInfo("err", message.Data.Message)), message.OriginalData);

            return message.ToCallResult();
        }
    }
}
