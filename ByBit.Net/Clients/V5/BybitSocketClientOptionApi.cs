using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Models.V5;
using Bybit.Net.Objects.Options;
using Bybit.Net.Objects.Sockets.Queries;
using Bybit.Net.Objects.Sockets.Subscriptions;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets.MessageParsing;
using CryptoExchange.Net.Sockets.MessageParsing.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc cref="IBybitSocketClientOptionApi" />
    public class BybitSocketClientOptionApi : BybitSocketClientBaseApi, IBybitSocketClientOptionApi
    {
        private static readonly MessagePath _typePath = MessagePath.Get().Property("type");
        private static readonly MessagePath _successPath = MessagePath.Get().Property("data").Property("successTopics");
        private static readonly MessagePath _failPath = MessagePath.Get().Property("data").Property("failTopics");
        private static readonly MessagePath _topicPath = MessagePath.Get().Property("topic");
        private static readonly MessagePath _opPath = MessagePath.Get().Property("op");

        internal BybitSocketClientOptionApi(ILogger log, BybitSocketOptions options)
            : base(log, options, "/v5/public/option")
        {
            RegisterPeriodicQuery("Heartbeat", TimeSpan.FromSeconds(20), x => new BybitPingQuery(), x => { });
        }

        /// <inheritdoc />
        public override string? GetListenerIdentifier(IMessageAccessor message)
        {
            var type = message.GetValue<string>(_typePath);
            if (type == "COMMAND_RESP")
            {
                var success = message.GetValues<string>(_successPath);
                if (success == null)
                    return null;

                success.AddRange(message.GetValues<string>(_failPath));
                return "resp" + string.Join("-", success.OrderBy(s => s));
            }

            var op = message.GetValue<string>(_opPath);
            if (op == "pong")
                return "pong";

            return message.GetValue<string>(_topicPath);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BybitOptionTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BybitOptionTickerUpdate>> handler, CancellationToken ct = default)
        {
            var subscription = new BybitOptionsSubscription<BybitOptionTickerUpdate>(_logger, symbols.Select(x => $"tickers.{x}").ToArray(), handler);
            return await SubscribeAsync(BaseAddress + _baseEndpoint, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BybitAuthenticationProvider(credentials);
    }
}
