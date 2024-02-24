using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitUnifiedQuery : Query<BybitOptionsQueryResponse>
    {
        public override HashSet<string> ListenerIdentifiers { get; set; }

        public BybitUnifiedQuery(string op, params object[] args) : base(new BybitRequestMessage { RequestId = ExchangeHelpers.NextId().ToString(), Operation = op, Args = args?.ToList() }, false, 1)
        {
            if (op == "auth")
                ListenerIdentifiers = new HashSet<string>() { "AUTH_RESP" };
            else
                ListenerIdentifiers = new HashSet<string>() { "COMMAND_RESP" };
        }

        public override Task<CallResult<BybitOptionsQueryResponse>> HandleMessageAsync(SocketConnection connection, DataEvent<BybitOptionsQueryResponse> message)
        {
            if (!message.Data.Success)
                return Task.FromResult(new CallResult<BybitOptionsQueryResponse>(new ServerError(message.Data.Message)));

            return Task.FromResult(new CallResult<BybitOptionsQueryResponse>(message.Data));
        }
    }
}
