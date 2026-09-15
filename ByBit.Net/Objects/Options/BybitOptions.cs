using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Configuration;
using System;

namespace Bybit.Net.Objects.Options
{
    /// <summary>
    /// Bybit options
    /// </summary>
    public class BybitOptions : LibraryOptions<BybitRestOptions, BybitSocketOptions, BybitCredentials, BybitEnvironment>
    {
        /// <summary>
        /// Options for Shared API usage
        /// </summary>
        public SharedApiOptions SharedApi { get; set; } = new();


        /// <summary>
        /// Create options using the provided configuration action
        /// </summary>
        public static BybitOptions Create(Action<BybitOptions>? configure = null)
        {
            var options = CreateUnconfigured();
            configure?.Invoke(options);
            return Normalize(options);
        }

        /// <summary>
        /// Create options using the provided configuration
        /// </summary>
        public static BybitOptions CreateFromConfiguration(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var options = CreateUnconfigured();

            try
            {
                configuration.Bind(options);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Invalid Bybit configuration provided", ex);
            }

            if (options.Environment != null)
                options.Environment = BybitEnvironment.GetEnvironmentByName(options.Environment.Name) ?? options.Environment;
            if (options.Rest?.Environment != null)
                options.Rest.Environment = BybitEnvironment.GetEnvironmentByName(options.Rest.Environment.Name) ?? options.Rest.Environment;
            if (options.Socket?.Environment != null)
                options.Socket.Environment = BybitEnvironment.GetEnvironmentByName(options.Socket.Environment.Name) ?? options.Socket.Environment;

            return Normalize(options);
        }

        private static BybitOptions CreateUnconfigured()
        {
            var options = new BybitOptions();
            options.Rest.Environment = null!;
            options.Socket.Environment = null!;
            return options;
        }

        private static BybitOptions Normalize(BybitOptions options)
        {
            if (options.Rest == null || options.Socket == null)
                throw new ArgumentException("Options null");

            options.Rest.Environment ??= options.Environment ?? BybitEnvironment.Live;
            options.Rest.ApiCredentials ??= options.ApiCredentials;
            options.Socket.Environment ??= options.Environment ?? BybitEnvironment.Live;
            options.Socket.ApiCredentials ??= options.ApiCredentials;
            return options;
        }
    }
}
