using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Authentication;
using System.Net.Http;
using Bybit.Net.Objects.Options;
using System;
using Microsoft.Extensions.Logging;
using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Options;
using CryptoExchange.Net.Objects.Options;

namespace Bybit.Net.Clients
{
    /// <inheritdoc cref="IBybitRestClient" />
    public class BybitRestClient : BaseRestClient<BybitEnvironment, BybitCredentials>, IBybitRestClient
    {
        /// <inheritdoc />
        public Interfaces.Clients.V5.IBybitRestClientApi V5Api { get; }

        #region constructor/destructor
        /// <summary>
        /// Create a new instance of the BybitRestClient using provided options
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BybitRestClient(Action<BybitRestOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate)))
        {
        }

        /// <summary>
        /// Create a new instance of the BybitRestClient
        /// </summary>
        /// <param name="options">Option configuration delegate</param>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="httpClient">Http client for this client</param>
        public BybitRestClient(HttpClient? httpClient, ILoggerFactory? loggerFactory, IOptions<BybitRestOptions> options)
            : base(loggerFactory, "Bybit")
        {
            Initialize(options.Value);

            V5Api = AddApiClient(new V5.BybitRestClientApi(_logger, httpClient, options.Value));
        }

        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BybitRestOptions> optionsDelegate)
        {
            BybitRestOptions.Default = ApplyOptionsDelegate(optionsDelegate);
        }
    }
}
