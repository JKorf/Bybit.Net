using Bybit.Net.Enums;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Spot;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBybitClientSpotApiAccount
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotBalance>>> GetBalancesAsync(long? receiveWindow = null, CancellationToken ct = default);
    }
}