using Bybit.Net.Objects.Models.V5;
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
    internal class BybitOrderBookSubscription : Subscription<BybitQueryResponse, BybitQueryResponse>
    {
        private readonly SocketApiClient _client;
        private string[] _topics;
        private Action<DataEvent<BybitOrderbook>> _handler;

        public BybitOrderBookSubscription(ILogger logger, SocketApiClient client, string[] topics, Action<DataEvent<BybitOrderbook>> handler, bool auth = false) : base(logger, auth)
        {
            _client = client;
            _topics = topics;
            _handler = handler;

            MessageMatcher = MessageMatcher.Create<BybitSpotSocketEvent<BybitOrderbook>>(topics, DoHandleMessage);
        }

        public CallResult DoHandleMessage(SocketConnection connection, DataEvent<BybitSpotSocketEvent<BybitOrderbook>> message)
        {
            var splitIndex = message.Data.Topic.LastIndexOf('.');
            message.Data.Data.Timestamp = message.Data.Timestamp;
            message.Data.Data.MatchingEngineTimestamp = message.Data.CTimestamp!.Value;
            _handler?.Invoke(message.As(message.Data.Data, message.Data.Topic, splitIndex == -1 ? null : message.Data.Topic.Substring(splitIndex + 1), string.Equals(message.Data.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update).WithDataTimestamp(message.Data.Timestamp));
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
