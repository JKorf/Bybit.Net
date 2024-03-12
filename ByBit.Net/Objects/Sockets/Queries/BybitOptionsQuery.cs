using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitOptionsQuery : Query<BybitOptionsQueryResponse>
    {
        public override HashSet<string> ListenerIdentifiers { get; set; }

        public BybitOptionsQuery(string op, params object[] args) : base(new BybitRequestMessage { RequestId = ExchangeHelpers.NextId().ToString(), Operation = op, Args = args?.ToList() }, false, 1)
        {
            ListenerIdentifiers = new HashSet<string>() { "resp" + string.Join("-", args.OrderBy(a => a)) };
        }

        public override CallResult<BybitOptionsQueryResponse> HandleMessage(SocketConnection connection, DataEvent<BybitOptionsQueryResponse> message)
        {
            if (!message.Data.Success)
                return new CallResult<BybitOptionsQueryResponse>(new ServerError(message.Data.Message));

            return new CallResult<BybitOptionsQueryResponse>(message.Data);
        }
    }
}
