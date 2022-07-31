using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.CopyTradingApi;
using Bybit.Net.Objects.Models.CopyTrading;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.CopyTradingApi
{
    /// <inheritdoc />
    public  class BybitClientCopyTradingApiAccount : IBybitClientCopyTradingApiAccount
    {
        private BybitClientCopyTradingApi _baseClient;

        internal BybitClientCopyTradingApiAccount(BybitClientCopyTradingApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Balances

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCopyTradingBalance>> GetBalancesAsync(CancellationToken ct = default)
        {
            return await _baseClient.SendRequestAsync<BybitCopyTradingBalance>(_baseClient.GetUrl("contract/v3/private/copytrading/wallet/balance"), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
        }

        #endregion

        #region Transfer

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCopyTradingTransfer>> TransferAsync(string transferId, string asset, decimal quantity, AccountType fromAccount, AccountType toAccount, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "transferId", transferId },
                { "coin", asset },
                { "amount", quantity },
                { "fromAccountType", EnumConverter.GetString(fromAccount) },
                { "toAccountType", EnumConverter.GetString(toAccount) },
            };
            return await _baseClient.SendRequestAsync<BybitCopyTradingTransfer>(_baseClient.GetUrl("contract/v3/private/copytrading/wallet/transfer"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
