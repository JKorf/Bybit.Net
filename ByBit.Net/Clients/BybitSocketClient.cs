using System;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Authentication;
using Bybit.Net.Clients.V5;
using Bybit.Net.Interfaces.Clients.V5;
using Microsoft.Extensions.Logging;
using Bybit.Net.Objects.Options;
using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Options;
using CryptoExchange.Net.Objects.Options;

namespace Bybit.Net.Clients
{
    /// <inheritdoc cref="IBybitSocketClient" />
    public class BybitSocketClient : BaseSocketClient, IBybitSocketClient
    {
        /// <inheritdoc />
        public IBybitSocketClientSpotApi V5SpotApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientLinearApi V5LinearApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientInverseApi V5InverseApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientOptionApi V5OptionsApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientSpreadApi V5SpreadApi { get; }
        /// <inheritdoc />
        public IBybitSocketClientPrivateApi V5PrivateApi { get; }

        /// <summary>
        /// Create a new instance of the BybitSocketClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public BybitSocketClient(Action<BybitSocketOptions>? optionsDelegate = null)
            : this(Options.Create(ApplyOptionsDelegate(optionsDelegate)), null)
        {
        }

        /// <summary>
        /// Create a new instance of the BybitSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="options">Option configuration</param>
        public BybitSocketClient(IOptions<BybitSocketOptions> options, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Bybit")
        {
            Initialize(options.Value);

            V5SpotApi = AddApiClient(new BybitSocketClientSpotApi(_logger, options.Value));
            V5InverseApi = AddApiClient(new BybitSocketClientInverseApi(_logger, options.Value));
            V5LinearApi = AddApiClient(new BybitSocketClientLinearApi(_logger, options.Value));
            V5OptionsApi = AddApiClient(new BybitSocketClientOptionApi(_logger, options.Value));
            V5SpreadApi = AddApiClient(new BybitSocketClientSpreadApi(_logger, options.Value));
            V5PrivateApi = AddApiClient(new BybitSocketClientPrivateApi(_logger, options.Value));
        }

        /// <inheritdoc />
        public void SetOptions(UpdateOptions options)
        {
            V5SpotApi.SetOptions(options);
            V5InverseApi.SetOptions(options);
            V5LinearApi.SetOptions(options);
            V5OptionsApi.SetOptions(options);
            V5SpreadApi.SetOptions(options);
            V5PrivateApi.SetOptions(options);
        }

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<BybitSocketOptions> optionsDelegate)
        {
            BybitSocketOptions.Default = ApplyOptionsDelegate(optionsDelegate);
        }

        /// <inheritdoc />
        public void SetApiCredentials(ApiCredentials credentials)
        {
            V5LinearApi.SetApiCredentials(credentials);
            V5OptionsApi.SetApiCredentials(credentials);
            V5InverseApi.SetApiCredentials(credentials);
            V5PrivateApi.SetApiCredentials(credentials);
            V5SpreadApi.SetApiCredentials(credentials);
            V5SpotApi.SetApiCredentials(credentials);
        }
    }
}
