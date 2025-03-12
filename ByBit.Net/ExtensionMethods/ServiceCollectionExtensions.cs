using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using Bybit.Net.SymbolOrderBooks;
using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for DI
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services such as the IBybitRestClient and IBybitSocketClient. Configures the services based on the provided configuration.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="configuration">The configuration(section) containing the options</param>
        /// <returns></returns>
        public static IServiceCollection AddBybit(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var options = new BybitOptions();
            // Reset environment so we know if theyre overriden
            options.Rest.Environment = null!;
            options.Socket.Environment = null!;
            configuration.Bind(options);

            if (options.Rest == null || options.Socket == null)
                throw new ArgumentException("Options null");

            var restEnvName = options.Rest.Environment?.Name ?? options.Environment?.Name ?? BybitEnvironment.Live.Name;
            var socketEnvName = options.Socket.Environment?.Name ?? options.Environment?.Name ?? BybitEnvironment.Live.Name;
            options.Rest.Environment = BybitEnvironment.GetEnvironmentByName(restEnvName) ?? options.Rest.Environment!;
            options.Rest.ApiCredentials = options.Rest.ApiCredentials ?? options.ApiCredentials;
            options.Socket.Environment = BybitEnvironment.GetEnvironmentByName(socketEnvName) ?? options.Socket.Environment!;
            options.Socket.ApiCredentials = options.Socket.ApiCredentials ?? options.ApiCredentials;


            services.AddSingleton(x => Options.Options.Create(options.Rest));
            services.AddSingleton(x => Options.Options.Create(options.Socket));

            return AddBybitCore(services, options.SocketClientLifeTime);
        }

        /// <summary>
        /// Add services such as the IBybitRestClient and IBybitSocketClient. Services will be configured based on the provided options.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="optionsDelegate">Set options for the Bybit services</param>
        /// <returns></returns>
        public static IServiceCollection AddBybit(
            this IServiceCollection services,
            Action<BybitOptions>? optionsDelegate = null)
        {
            var options = new BybitOptions();
            // Reset environment so we know if theyre overriden
            options.Rest.Environment = null!;
            options.Socket.Environment = null!;
            optionsDelegate?.Invoke(options);
            if (options.Rest == null || options.Socket == null)
                throw new ArgumentException("Options null");

            options.Rest.Environment = options.Rest.Environment ?? options.Environment ?? BybitEnvironment.Live;
            options.Rest.ApiCredentials = options.Rest.ApiCredentials ?? options.ApiCredentials;
            options.Socket.Environment = options.Socket.Environment ?? options.Environment ?? BybitEnvironment.Live;
            options.Socket.ApiCredentials = options.Socket.ApiCredentials ?? options.ApiCredentials;

            services.AddSingleton(x => Options.Options.Create(options.Rest));
            services.AddSingleton(x => Options.Options.Create(options.Socket));

            return AddBybitCore(services, options.SocketClientLifeTime);
        }

        /// <summary>
        /// DEPRECATED; use <see cref="AddBybit(IServiceCollection, Action{BybitOptions}?)" /> instead
        /// </summary>
        public static IServiceCollection AddBybit(
            this IServiceCollection services,
            Action<BybitRestOptions> restDelegate,
            Action<BybitSocketOptions>? socketDelegate = null,
            ServiceLifetime? socketClientLifeTime = null)
        {
            services.Configure<BybitRestOptions>((x) => { restDelegate?.Invoke(x); });
            services.Configure<BybitSocketOptions>((x) => { socketDelegate?.Invoke(x); });

            return AddBybitCore(services, socketClientLifeTime);
        }

        private static IServiceCollection AddBybitCore(
            this IServiceCollection services,
            ServiceLifetime? socketClientLifeTime = null)
        {
            services.AddHttpClient<IBybitRestClient, BybitRestClient>((client, serviceProvider) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<BybitRestOptions>>().Value;
                client.Timeout = options.RequestTimeout;
                return new BybitRestClient(client, serviceProvider.GetRequiredService<ILoggerFactory>(), serviceProvider.GetRequiredService<IOptions<BybitRestOptions>>());
            }).ConfigurePrimaryHttpMessageHandler((serviceProvider) => {
                var handler = new HttpClientHandler();
                try
                {
                    handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    handler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;
                }
                catch (PlatformNotSupportedException) { }
                catch (NotImplementedException) { } // Mono runtime throws NotImplementedException for DefaultProxyCredentials setting

                var options = serviceProvider.GetRequiredService<IOptions<BybitRestOptions>>().Value;
                if (options.Proxy != null)
                {
                    handler.Proxy = new WebProxy
                    {
                        Address = new Uri($"{options.Proxy.Host}:{options.Proxy.Port}"),
                        Credentials = options.Proxy.Password == null ? null : new NetworkCredential(options.Proxy.Login, options.Proxy.Password)
                    };
                }
                return handler;
            });
            services.Add(new ServiceDescriptor(typeof(IBybitSocketClient), x => { return new BybitSocketClient(x.GetRequiredService<IOptions<BybitSocketOptions>>(), x.GetRequiredService<ILoggerFactory>()); }, socketClientLifeTime ?? ServiceLifetime.Singleton));

            services.AddTransient<ICryptoRestClient, CryptoRestClient>();
            services.AddTransient<ICryptoSocketClient, CryptoSocketClient>();
            services.AddTransient<IBybitOrderBookFactory, BybitOrderBookFactory>();
            services.AddTransient<IBybitTrackerFactory, BybitTrackerFactory>();

            services.RegisterSharedRestInterfaces(x => x.GetRequiredService<IBybitRestClient>().V5Api.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBybitSocketClient>().V5SpotApi.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBybitSocketClient>().V5LinearApi.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBybitSocketClient>().V5InverseApi.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBybitSocketClient>().V5PrivateApi.SharedClient);

            return services;
        }
    }
}
