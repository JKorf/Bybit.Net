using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Sockets.Queries;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;
using System;

namespace Bybit.Net.Objects.Sockets.Subscriptions
{
    internal class BybitOrderBookSubscription : Subscription
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
            MessageRouter = MessageRouter.CreateWithoutTopicFilter<BybitSpotSocketEvent<BybitOrderbook>>(topics, DoHandleMessage);
        }

        public CallResult DoHandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BybitSpotSocketEvent<BybitOrderbook> message)
        {
            var splitIndex = message.Topic.LastIndexOf('.');
            message.Data.Timestamp = message.Data.Timestamp;
            message.Data.MatchingEngineTimestamp = message.CTimestamp!.Value;

            _handler?.Invoke(
                new DataEvent<BybitOrderbook>(message.Data, receiveTime, originalData)
                    .WithStreamId(message.Topic)
                    .WithSymbol(splitIndex == -1 ? null : message.Topic.Substring(splitIndex + 1))
                    .WithUpdateType(string.Equals(message.Type, "snapshot", StringComparison.Ordinal) ? SocketUpdateType.Snapshot : SocketUpdateType.Update)
                    .WithDataTimestamp(message.Data.Timestamp)
                );
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
