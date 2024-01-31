using Bybit.Net.Objects.Models.Spot;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.SpotApi.v3
{
    /// <summary>
    /// Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBybitRestClientSpotApiAccountV3
    {
        /// <summary>
        /// Get wallet balances
        /// <para><a href="https://bybit-exchange.github.io/docs/spot/v3/#t-wallet" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitSpotBalance>>> GetBalancesAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get margin account info
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitMarginAccountInfo>> GetMarginAccountInfoAsync(long? receiveWindow = null, CancellationToken ct = default);
    }
}