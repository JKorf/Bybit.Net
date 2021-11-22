using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects.Models.Socket;
using ByBit.Net;
using ByBit.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.Socket
{
    public class BybitSocketClientInversePerpetual: SocketClient
    {
        /// <summary>
        /// Create a new instance of BitfinexSocketClient using the default options
        /// </summary>
        public BybitSocketClientInversePerpetual() : this(BybitSocketClientInversePerpetualOptions.Default)
        {
        }

        /// <summary>
        /// Create a new instance of BitfinexSocketClient using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public BybitSocketClientInversePerpetual(BybitSocketClientInversePerpetualOptions options) : base("Bybit[InversePerpetual]", options, options.ApiCredentials == null ? null : new BybitAuthenticationProvider(options.ApiCredentials))
        {
            if (options == null)
                throw new ArgumentException("Cant pass null options, use empty constructor for default");

            ContinueOnQueryResponse = true;
            UnhandledMessageExpected = true;

            SendPeriodic(TimeSpan.FromSeconds(30), (connection) => new BybitRequestMessage() { Operation = "ping" });
            AddGenericHandler("Heartbeat", (evnt) => { });
        }

        /// <summary>
        /// Set the API key and secret
        /// </summary>
        /// <param name="apiKey">The api key</param>
        /// <param name="apiSecret">The api secret</param>
         public void SetApiCredentials(string apiKey, string apiSecret)
        {
            SetAuthenticationProvider(new BybitAuthenticationProvider(new ApiCredentials(apiKey, apiSecret)));
        }

        /// <summary>
        /// set the default options used when creating a client without specifying options
        /// </summary>
        /// <param name="newDefaultOptions"></param>
        public static void SetDefaultOptions(BybitSocketClientInversePerpetualOptions newDefaultOptions)
        {
            BybitSocketClientInversePerpetualOptions.Default = newDefaultOptions;
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new string[] { symbol }, handler);


        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var desResult = Deserialize<IEnumerable<BybitTradeUpdate>>(data.Data["data"]);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.First().Symbol));
            });
            return await SubscribeAsync(
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => "trade." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        protected override Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection socketConnection)
        {
            throw new NotImplementedException();
        }

        protected override bool HandleQueryResponse<T>(SocketConnection socketConnection, object request, JToken data, out CallResult<T>? callResult)
        {
            throw new NotImplementedException();
        }

        protected override bool HandleSubscriptionResponse(SocketConnection socketConnection, SocketSubscription subscription, object request, JToken data, out CallResult<object>? callResult)
        {
            callResult = null;
            if (data.Type != JTokenType.Object)
                return false;

            var requestParams = ((BybitRequestMessage)request).Parameters;

            var operation = data["request"]?["op"]?.ToString();
            var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
            if (operation != "subscribe")
                return false;

            if (requestParams.Any(p => !args.Contains(p)))
                return false;

            callResult = new CallResult<object>(default, null);
            return data["success"]?.Value<bool>() == true;
        }

        protected override bool MessageMatchesHandler(JToken message, object request)
        {
            if (message.Type != JTokenType.Object)
                return false;

            var topic = message["topic"]?.ToString();
            if (topic == null)
                return false;

            var requestParams = ((BybitRequestMessage)request).Parameters;
            if (requestParams.Any(p => topic == p.ToString()))
                // TODO when multiple subs combined this won't trigger?
                return true;

            return false;
        }

        protected override bool MessageMatchesHandler(JToken message, string identifier)
        {
            if(identifier == "Heartbeat")
            {
                var ret = message["ret_msg"];
                if (ret == null)
                    return false;

                var isPing = ret.ToString() == "pong";
                if (!isPing)
                    return false;

                return true;
            }

            return false;
        }

        protected override async Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscriptionToUnsub)
        {
            var requestParams = ((BybitRequestMessage)subscriptionToUnsub.Request).Parameters;
            var message = new BybitRequestMessage { Operation = "unsubscribe", Parameters = requestParams };

            var result = false;
            await connection.SendAndWaitAsync(message, ClientOptions.SocketResponseTimeout, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                var operation = data["request"]?["op"]?.ToString();
                var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
                if (operation != "unsubscribe")
                    return false;

                if (requestParams.Any(p => !args.Contains(p)))
                    return false;

                return data["success"]?.Value<bool>() == true;
            }).ConfigureAwait(false);
            return result;
        }
    }
}
