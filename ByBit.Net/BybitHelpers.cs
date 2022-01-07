using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects;
using Microsoft.Extensions.DependencyInjection;
using System;

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
        /// <param name="defaultOptionsCallback">Set default options for the client</param>
        /// <param name="socketClientLifeTime">The lifetime of the IBybitSocketClient for the service collection. Defaults to Scoped.</param>
        /// <returns></returns>
        public static IServiceCollection AddBybit(
            this IServiceCollection services,
            Action<BybitClientOptions, BybitSocketClientOptions>? defaultOptionsCallback = null,
            ServiceLifetime? socketClientLifeTime = null)
        {
            if (defaultOptionsCallback != null)
            {
                var options = new BybitClientOptions();
                var socketOptions = new BybitSocketClientOptions();
                defaultOptionsCallback?.Invoke(options, socketOptions);

                BybitClient.SetDefaultOptions(options);
                BybitSocketClient.SetDefaultOptions(socketOptions);
            }

            services.AddTransient<IBybitClient, BybitClient>();
            if (socketClientLifeTime == null)
                services.AddScoped<IBybitSocketClient, BybitSocketClient>();
            else
                services.Add(new ServiceDescriptor(typeof(IBybitSocketClient), typeof(BybitSocketClient), socketClientLifeTime.Value));
            return services;
        }
    }
}
