using Bybit.Net.Objects.Models.CopyTrading;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.CopyTradingApi
{
    /// <summary>
    /// Bybit Copy Trading exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBybitClientCopyTradingApiExchangeData
    {
        /// <summary>
        /// Retrieve the server timestamp
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-servertime" /></para>
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get a list of supported symbols
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-ct_symbol_list" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitCopyTradingSymbol>>> GetSymbolsAsync(CancellationToken ct = default);
    }
}
