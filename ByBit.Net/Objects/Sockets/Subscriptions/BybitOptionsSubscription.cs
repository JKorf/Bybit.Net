using Bybit.Net.Objects.Sockets.Queries;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.MessageParsing.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Sockets.Subscriptions
{
    internal class BybitOptionsSubscription<T> : Subscription<BybitOptionsQueryResponse, BybitOptionsQueryResponse>
    {
        private string[] _topics;
        private Action<DataEvent<T>> _handler;
        public override HashSet<string> ListenerIdentifiers { get; set; }

        public BybitOptionsSubscription(ILogger logger, string[] topics, Action<DataEvent<T>> handler, bool auth = false) : base(logger, auth)
        {
            _topics = topics;
            _handler = handler;
            ListenerIdentifiers = new HashSet<string>(topics);
        }

        public override Task<CallResult> DoHandleMessageAsync(SocketConnection connection, DataEvent<object> message)
        {
            var data = (BybitSpotSocketEvent<T>)message.Data;
            _handler?.Invoke(message.As(data.Data, data.Topic, data.Type == "snapshot" ? SocketUpdateType.Snapshot : SocketUpdateType.Update));
            return Task.FromResult(new CallResult(null));
        }

        public override Type? GetMessageType(IMessageAccessor message) => typeof(BybitSpotSocketEvent<T>);

        public override Query? GetSubQuery(SocketConnection connection)
        {
            return new BybitOptionsQuery("subscribe", _topics);
        }
        public override Query? GetUnsubQuery()
        {
            return new BybitOptionsQuery("unsubscribe", _topics);
        }
    }
}
