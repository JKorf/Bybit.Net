using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Net.Http;

namespace Bybit.Net.Clients
{
    /// <inheritdoc />
    public class BybitUserClientProvider : UserClientProvider<
        IBybitRestClient,
        IBybitSocketClient,
        BybitRestOptions,
        BybitSocketOptions,
        BybitCredentials,
        BybitEnvironment
        >, IBybitUserClientProvider
    {
        /// <inheritdoc />
        public override string ExchangeName => BybitExchange.ExchangeName;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="optionsDelegate">Options to use for created clients</param>
        public BybitUserClientProvider(Action<BybitOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate).Rest), Options.Create(ApplyOptionsDelegate(optionsDelegate).Socket))
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public BybitUserClientProvider(
            HttpClient? httpClient,
            ILoggerFactory? loggerFactory,
            IOptions<BybitRestOptions> restOptions,
            IOptions<BybitSocketOptions> socketOptions)
            : base(httpClient, loggerFactory, restOptions, socketOptions)
        {
        }

        /// <inheritdoc />
        protected override IBybitRestClient ConstructRestClient(HttpClient client, ILoggerFactory? loggerFactory, IOptions<BybitRestOptions> options)
            => new BybitRestClient(client, loggerFactory, options);
        /// <inheritdoc />
        protected override IBybitSocketClient ConstructSocketClient(ILoggerFactory? loggerFactory, IOptions<BybitSocketOptions> options)
            => new BybitSocketClient(options, loggerFactory);
    }
}
