using Bybit.Net.Objects.Sockets.Queries;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Sockets.Subscriptions
{
    internal class BybitSubscription<T> : Subscription<BybitQueryResponse, BybitQueryResponse>
    {
        private string[] _topics;
        private Action<DataEvent<T>> _handler;

        public BybitSubscription(ILogger logger, string[] topics, Action<DataEvent<T>> handler, bool auth = false) : base(logger, auth)
        {
            _topics = topics;
            _handler = handler;

            MessageMatcher = MessageMatcher.Create<BybitSpotSocketEvent<T>>(topics, DoHandleMessage);
        }

        public CallResult DoHandleMessage(SocketConnection connection, DataEvent<BybitSpotSocketEvent<T>> message)
        {
            var splitIndex = message.Data.Topic.LastIndexOf('.');
            _handler?.Invoke(message.As(message.Data.Data, message.Data.Topic, splitIndex == -1 ? null : message.Data.Topic.Substring(splitIndex + 1), string.Equals(message.Data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update).WithDataTimestamp(message.Data.Timestamp));
            return CallResult.SuccessResult;
        }

        public override Query? GetSubQuery(SocketConnection connection)
        {
            return new BybitQuery("subscribe", _topics);
        }
        public override Query? GetUnsubQuery()
        {
            return new BybitQuery("unsubscribe", _topics);
        }
    }
}
