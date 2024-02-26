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
        public static BybitRestOptions Default { get; set; } = new BybitRestOptions
        {
            Environment = BybitEnvironment.Live
        };

        /// <summary>
        /// A referer, will be sent in the Referer header
        /// </summary>
        public string? Referer { get; set; }

        /// <summary>
        /// The default receive window for requests
        /// </summary>
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Options for the Spot API
        /// </summary>
        public RestApiOptions SpotOptions { get; private set; } = new RestApiOptions();

        /// <summary>
        /// Options for the Copy Trading API
        /// </summary>
        public RestApiOptions CopyTradingOptions { get; private set; } = new RestApiOptions();

        /// <summary>
        /// Options for the Derivatives API
        /// </summary>
        public RestApiOptions DerivativesOptions { get; private set; } = new RestApiOptions();

        /// <summary>
        /// Options for the V5 API
        /// </summary>
        public RestApiOptions V5Options { get; private set; } = new RestApiOptions();

        internal BybitRestOptions Copy()
        {
            var options = Copy<BybitRestOptions>();
            options.Referer = Referer;
            options.ReceiveWindow = ReceiveWindow;
            options.SpotOptions = SpotOptions.Copy<RestApiOptions>();
            options.CopyTradingOptions = CopyTradingOptions.Copy<RestApiOptions>();
            options.DerivativesOptions = DerivativesOptions.Copy<RestApiOptions>();
            options.V5Options = V5Options.Copy<RestApiOptions>();
            return options;
        }
    }
}
