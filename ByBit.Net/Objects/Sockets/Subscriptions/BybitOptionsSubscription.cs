using Bybit.Net.Objects.Sockets.Queries;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;
using System;

namespace Bybit.Net.Objects.Sockets.Subscriptions
{
    internal class BybitOptionsSubscription<T> : Subscription
    {
        private string[] _topics;
        private Action<DateTime, string?, BybitSpotSocketEvent<T>> _handler;

        public BybitOptionsSubscription(ILogger logger, string[] topics, Action<DateTime, string?, BybitSpotSocketEvent<T>> handler, bool auth = false) : base(logger, auth)
        {
            _topics = topics;
            _handler = handler;

            IndividualSubscriptionCount = topics.Length;

            MessageRouter = MessageRouter.CreateWithoutTopicFilter<BybitSpotSocketEvent<T>>(topics, DoHandleMessage);
        }

        public CallResult DoHandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BybitSpotSocketEvent<T> message)
        {
            _handler.Invoke(receiveTime, originalData, message);
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
