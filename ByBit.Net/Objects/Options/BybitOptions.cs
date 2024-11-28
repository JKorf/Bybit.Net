using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Options
{
    /// <summary>
    /// Bybit options
    /// </summary>
    public class BybitOptions : LibraryOptions<BybitRestOptions, BybitSocketOptions, ApiCredentials, BybitEnvironment>
    {
    }
}
