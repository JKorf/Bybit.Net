using Bybit.Net.Interfaces.Clients.SpotApi.v1;
using Bybit.Net.Objects.Models.Spot;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.SpotApi.v1
{
    /// <inheritdoc />
    public class BybitClientSpotApiAccountV1 : IBybitClientSpotApiAccountV1
    {
        private BybitClientBaseSpotApi _baseClient;

        internal BybitClientSpotApiAccountV1(BybitClientBaseSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get balances

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotBalance>>> GetBalancesAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitSpotBalanceWrapper>(_baseClient.GetUrl("spot/v1/account"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            return result.As(result.Data?.Balances!);
        }

        #endregion

        #region Get margin account info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitMarginAccountInfo>> GetMarginAccountInfoAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitMarginAccountInfo>(_baseClient.GetUrl("spot/v1/cross-margin/accounts/balance"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
