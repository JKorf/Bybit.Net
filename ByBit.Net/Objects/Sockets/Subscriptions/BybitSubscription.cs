using Bybit.Net.Objects.Sockets.Queries;
using CryptoExchange.Net.Clients;
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
        private readonly SocketApiClient _client;
        private string[] _topics;
        private Action<DateTime, string?, BybitSpotSocketEvent<T>> _handler;

        public BybitSubscription(ILogger logger, SocketApiClient client, string[] topics, Action<DateTime, string?, BybitSpotSocketEvent<T>> handler, bool auth = false) : base(logger, auth)
        {
            _client = client;
            _topics = topics;
            _handler = handler;

            MessageMatcher = MessageMatcher.Create<BybitSpotSocketEvent<T>>(topics, DoHandleMessage);
            MessageRouter = MessageRouter.CreateWithoutTopicFilter<BybitSpotSocketEvent<T>>(topics, DoHandleMessage);
        }

        public CallResult DoHandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BybitSpotSocketEvent<T> message)
        {
            _handler.Invoke(receiveTime, originalData, message);
            return CallResult.SuccessResult;
        }

        protected override Query? GetSubQuery(SocketConnection connection)
        {
            return new BybitQuery(_client, "subscribe", _topics);
        }
        protected override Query? GetUnsubQuery(SocketConnection connection)
        {
            return new BybitQuery(_client, "unsubscribe", _topics);
        }
    }
}
