using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects.Options;
using System;

namespace Bybit.Net.Objects.Options
{
    /// <summary>
    /// Options for the BybitRestClient
    /// </summary>
    public class BybitRestOptions : RestExchangeOptions<BybitEnvironment, ApiCredentials>
    {
        /// <summary>
        /// Default options for the rest client
        /// </summary>
        internal static BybitRestOptions Default { get; set; } = new BybitRestOptions
        {
            Environment = BybitEnvironment.Live
        };

        /// <summary>
        /// ctor
        /// </summary>
        public BybitRestOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// A referer, will be sent in the Referer header
        /// </summary>
        public string? Referer { get; set; }

        /// <summary>
        /// The default receive window for requests
        /// </summary>
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Options for the V5 API
        /// </summary>
        public RestApiOptions V5Options { get; private set; } = new RestApiOptions();

        internal BybitRestOptions Set(BybitRestOptions targetOptions)
        {
            targetOptions = base.Set<BybitRestOptions>(targetOptions);
            targetOptions.Referer = Referer;
            targetOptions.ReceiveWindow = ReceiveWindow;
            targetOptions.V5Options = V5Options.Set(targetOptions.V5Options);
            return targetOptions;
        }
    }
}
