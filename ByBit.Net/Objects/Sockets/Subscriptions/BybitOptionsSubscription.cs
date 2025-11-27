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
    internal class BybitOptionsSubscription<T> : Subscription<BybitOptionsQueryResponse, BybitOptionsQueryResponse>
    {
        private string[] _topics;
        private Action<DateTime, string?, BybitSpotSocketEvent<T>> _handler;

        public BybitOptionsSubscription(ILogger logger, string[] topics, Action<DateTime, string?, BybitSpotSocketEvent<T>> handler, bool auth = false) : base(logger, auth)
        {
            _topics = topics;
            _handler = handler;

            MessageMatcher = MessageMatcher.Create<BybitSpotSocketEvent<T>>(topics, DoHandleMessage);
            MessageRouter = MessageRouter.Create<BybitSpotSocketEvent<T>>(topics, DoHandleMessage);
        }

        public CallResult DoHandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BybitSpotSocketEvent<T> message)
        {
            var splitIndex = message.Topic.LastIndexOf('.');

            _handler.Invoke(receiveTime, originalData, message);

            //_handler?.Invoke(message.As(message.Data, message.Topic, splitIndex == -1 ? null : message.Topic.Substring(splitIndex + 1), string.Equals(message.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update).WithDataTimestamp(message.Timestamp));
            return CallResult.SuccessResult;
        }


        protected override Query? GetSubQuery(SocketConnection connection)
        {
            return new BybitOptionsQuery("subscribe", _topics);
        }
        protected override Query? GetUnsubQuery(SocketConnection connection)
        {
            return new BybitOptionsQuery("unsubscribe", _topics);
        }
    }
}
