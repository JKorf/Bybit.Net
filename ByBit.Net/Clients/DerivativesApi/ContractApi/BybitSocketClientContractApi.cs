using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Models.Socket.Derivatives.Contract;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets.Queries;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.MessageParsing;
using CryptoExchange.Net.Sockets.MessageParsing.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.DerivativesApi.ContractApi
{
    /// <inheritdoc cref="IBybitSocketClientContractApi" />
    public class BybitSocketClientContractApi : SocketApiClient, IBybitSocketClientContractApi
    {
        private static readonly MessagePath _reqIdPath = MessagePath.Get().Property("req_id");
        private static readonly MessagePath _topicPath = MessagePath.Get().Property("topic");

        internal BybitSocketClientContractApi(ILogger log, BybitSocketOptions options)
            : base(log, options.Environment.SocketBaseAddress.AppendPath("contract/private/v3"), options, options.ContractOptions)
        {
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            RegisterPeriodicQuery("Heartbeat", TimeSpan.FromSeconds(20), x => new BybitQuery("ping", null), x => { });
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);

        /// <inheritdoc />
        public override string? GetListenerIdentifier(IMessageAccessor message)
        {
            var reqId = message.GetValue<string>(_reqIdPath);
            if (reqId != null)
                return reqId;

            return message.GetValue<string>(_topicPath);
        }

        /// <inheritdoc />
        protected override Query? GetAuthenticationRequest()
        {
            var expireTime = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddSeconds(30))!;
            var authProvider = (BybitAuthenticationProvider)AuthenticationProvider!;
            var key = authProvider.GetApiKey();
            var sign = authProvider.Sign($"GET/realtime{expireTime}");

            return new BybitQuery("auth", new object[]
            {
                key,
                expireTime,
                sign
            });
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitContractPositionUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitContractPositionUpdate>>(_logger, new[] { "user.position.contractAccount" }, handler, true);
            return await SubscribeAsync(subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitContractUserTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitContractUserTradeUpdate>>(_logger, new[] { "user.execution.contractAccount" }, handler, true);
            return await SubscribeAsync(subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitContractOrderUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitContractOrderUpdate>>(_logger, new[] { "user.order.contractAccount" }, handler, true);
            return await SubscribeAsync(subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<IEnumerable<BybitContractBalanceUpdate>>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitSubscription<IEnumerable<BybitContractBalanceUpdate>>(_logger, new[] { "user.wallet.contractAccount" }, handler, true);
            return await SubscribeAsync(subscription, ct).ConfigureAwait(false);
        }
    }
}
