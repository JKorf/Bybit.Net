using Bybit.Net;
using Bybit.Net.Clients;
using Bybit.Net.Interfaces;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Options;
using Bybit.Net.SymbolOrderBooks;
using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for DI
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services such as the IBybitRestClient and IBybitSocketClient. Configures the services based on the provided configuration.<br />
        /// See <see href="https://github.com/JKorf/Bybit.Net/blob/main/Examples/example-config.json" /> for an example of how to set up the configuration.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="configuration">The configuration(section) containing the options</param>
        /// <returns></returns>
        public static IServiceCollection AddBybit(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var options = BybitOptions.CreateFromConfiguration(configuration);

            services.AddSingleton(Options.Options.Create(options.Rest));
            services.AddSingleton(Options.Options.Create(options.Socket));
            services.AddSingleton(Options.Options.Create(options));

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
            var options = BybitOptions.Create(optionsDelegate);

            services.AddSingleton(Options.Options.Create(options.Rest));
            services.AddSingleton(Options.Options.Create(options.Socket));
            services.AddSingleton(Options.Options.Create(options));

            return AddBybitCore(services, options.SocketClientLifeTime);
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
                var options = serviceProvider.GetRequiredService<IOptions<BybitRestOptions>>().Value;
                return LibraryHelpers.CreateHttpClientMessageHandler(options);
            }).SetHandlerLifetime(Timeout.InfiniteTimeSpan);
            services.Add(new ServiceDescriptor(typeof(IBybitSocketClient), x => { return new BybitSocketClient(x.GetRequiredService<IOptions<BybitSocketOptions>>(), x.GetRequiredService<ILoggerFactory>()); }, socketClientLifeTime ?? ServiceLifetime.Singleton));

            services.AddTransient<IBybitOrderBookFactory, BybitOrderBookFactory>();
            services.AddTransient<IBybitTrackerFactory, BybitTrackerFactory>();
            services.AddTransient<ITrackerFactory, BybitTrackerFactory>();
            services.AddSingleton<IBybitUserClientProvider, BybitUserClientProvider>(x =>
            new BybitUserClientProvider(
                x.GetRequiredService<IHttpClientFactory>().CreateClient(typeof(IBybitRestClient).Name),
                x.GetRequiredService<ILoggerFactory>(),
                x.GetRequiredService<IOptions<BybitRestOptions>>(),
                x.GetRequiredService<IOptions<BybitSocketOptions>>()));

            services.RegisterSharedRestInterfaces(x => x.GetRequiredService<IBybitRestClient>().V5Api.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBybitSocketClient>().V5SpotApi.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBybitSocketClient>().V5LinearApi.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBybitSocketClient>().V5InverseApi.SharedClient);
            services.RegisterSharedSocketInterfaces(x => x.GetRequiredService<IBybitSocketClient>().V5PrivateApi.SharedClient);

            services.RegisterSharedApiClient<
                IBybitSharedApiClient,
                BybitSharedApiClient>(sharedApis => sharedApis
                    .Add(client => client.Rest)
                    .Add(client => client.SpotSocket)
                    .Add(client => client.InverseSocket)
                    .Add(client => client.LinearSocket)
                    .Add(client => client.PrivateSocket)
                    );

            return services;
        }
    }
}
