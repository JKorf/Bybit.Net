using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitQuery : Query<BybitQueryResponse>
    {
        public override HashSet<string> ListenerIdentifiers { get; set; }

        public BybitQuery(string op, params object[]? args) : base(new BybitRequestMessage { RequestId = ExchangeHelpers.NextId().ToString(), Operation = op, Args = args?.ToList() }, false, 1)
        {
            ListenerIdentifiers = new HashSet<string>() { ((BybitRequestMessage)Request).RequestId };
        }

        public override Task<CallResult<BybitQueryResponse>> HandleMessageAsync(SocketConnection connection, DataEvent<BybitQueryResponse> message)
        {
            if (!message.Data.Success)
                return Task.FromResult(new CallResult<BybitQueryResponse>(new ServerError(message.Data.Message)));

            return Task.FromResult(new CallResult<BybitQueryResponse>(message.Data));
        }
    }
}
