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
        /// <returns></returns>
        public static IServiceCollection AddBybit(this IServiceCollection services, Action<BybitClientOptions, BybitSocketClientOptions>? defaultOptionsCallback = null)
        {
            if (defaultOptionsCallback != null)
            {
                var options = new BybitClientOptions();
                var socketOptions = new BybitSocketClientOptions();
                defaultOptionsCallback?.Invoke(options, socketOptions);

                BybitClient.SetDefaultOptions(options);
                BybitSocketClient.SetDefaultOptions(socketOptions);
            }

            return services.AddTransient<IBybitClient, BybitClient>()
                           .AddScoped<IBybitSocketClient, BybitSocketClient>();
        }
    }
}
