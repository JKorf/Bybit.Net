using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net;
using Bybit.Net.Objects.Options;
using Bybit.Net.Interfaces;
using Bybit.Net.SymbolOrderBooks;

namespace Bybit.Net
{
    /// <summary>
    /// Helpers
    /// </summary>
    public static class BybitHelpers
    {
        /// <summary>
        /// Add the IBybitClient and IBybitSocketClient to the sevice collection so they can be injected
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="defaultRestOptionsDelegate">Set default options for the rest client</param>
        /// <param name="defaultSocketOptionsDelegate">Set default options for the socket client</param>
        /// <param name="socketClientLifeTime">The lifetime of the IBybitSocketClient for the service collection. Defaults to Singleton.</param>
        /// <returns></returns>
        public static IServiceCollection AddBybit(
            this IServiceCollection services,
            Action<BybitRestOptions>? defaultRestOptionsDelegate = null,
            Action<BybitSocketOptions>? defaultSocketOptionsDelegate = null,
            ServiceLifetime? socketClientLifeTime = null)
        {
            var restOptions = BybitRestOptions.Default.Copy();

            if (defaultRestOptionsDelegate != null)
            {
                defaultRestOptionsDelegate(restOptions);
                BybitRestClient.SetDefaultOptions(defaultRestOptionsDelegate);
            }

            if (defaultSocketOptionsDelegate != null)
                BybitSocketClient.SetDefaultOptions(defaultSocketOptionsDelegate);

            services.AddHttpClient<IBybitRestClient, BybitRestClient>(options =>
            {
                options.Timeout = restOptions.RequestTimeout;
            }).ConfigurePrimaryHttpMessageHandler(() => {
                var handler = new HttpClientHandler();
                if (restOptions.Proxy != null)
                {
                    handler.Proxy = new WebProxy
                    {
                        Address = new Uri($"{restOptions.Proxy.Host}:{restOptions.Proxy.Port}"),
                        Credentials = restOptions.Proxy.Password == null ? null : new NetworkCredential(restOptions.Proxy.Login, restOptions.Proxy.Password)
                    };
                }
                return handler;
            });

            services.AddSingleton<IBybitOrderBookFactory, BybitOrderBookFactory>();
            services.AddTransient<IBybitRestClient, BybitRestClient>();
            services.AddTransient(x => x.GetRequiredService<IBybitRestClient>().V5Api.CommonSpotClient);
            if (socketClientLifeTime == null)
                services.AddSingleton<IBybitSocketClient, BybitSocketClient>();
            else
                services.Add(new ServiceDescriptor(typeof(IBybitSocketClient), typeof(BybitSocketClient), socketClientLifeTime.Value));
            return services;
        }
    }
}
