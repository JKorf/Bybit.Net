using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitRequestQuery<T> : Query<BybitRequestQueryResponse<T>, T>
    {
        public override HashSet<string> ListenerIdentifiers { get; set; }

        public BybitRequestQuery(string op, Dictionary<string, string>? headers, params object[]? args) : 
            base(new BybitRequestQueryMessage { RequestId = ExchangeHelpers.NextId().ToString(), Header = headers, Operation = op, Args = args?.ToList() }, true, 1)
        {
            ListenerIdentifiers = new HashSet<string>() { ((BybitRequestQueryMessage)Request).RequestId };
        }

        public override CallResult<T> HandleMessage(SocketConnection connection, DataEvent<BybitRequestQueryResponse<T>> message)
        {
            if (message.Data.ReturnCode != 0)
                return new CallResult<T>(new ServerError(message.Data.ReturnCode, message.Data.ReturnMessage));

            return new CallResult<T>(message.Data.Data!);
        }
    }
}
