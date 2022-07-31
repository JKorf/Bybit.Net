using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.CopyTrading;
using CryptoExchange.Net.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.CopyTradingApi
{
    /// <summary>
    /// Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBybitClientCopyTradingApiAccount
    {
        /// <summary>
        /// Get the current wallet balance
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-ct_symbol_list" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCopyTradingBalance>> GetBalancesAsync(CancellationToken ct = default);

        /// <summary>
        /// Transfer to or from the Copy Trading account
        /// <para><a href="https://bybit-exchange.github.io/docs/copy_trading/#t-ct_wallet_transfer" /></para>
        /// </summary>
        /// <param name="transferId">Uninque id</param>
        /// <param name="asset">Asset to transfer</param>
        /// <param name="quantity">Quantity to transfer</param>
        /// <param name="fromAccount">From account type</param>
        /// <param name="toAccount">To account type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitCopyTradingTransfer>> TransferAsync(string transferId, string asset, decimal quantity, AccountType fromAccount, AccountType toAccount, CancellationToken ct = default);
    }
}
