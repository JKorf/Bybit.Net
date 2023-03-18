using Bybit.Net.Objects.Models.Spot;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Objects.Internal;
using System;

namespace Bybit.Net.Clients.SpotApi.v3
{
    /// <inheritdoc />
    public class BybitClientSpotApiAccountV3 : IBybitClientSpotApiAccountV3
    {
        private BybitClientBaseSpotApi _baseClient;

        internal BybitClientSpotApiAccountV3(BybitClientBaseSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get balances

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotBalance>>> GetBalancesAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitBalanceWrapper>(_baseClient.GetUrl("spot/v3/private/account"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitSpotBalance>>(default);

            if (result.Data.Balances == null)
                return result.As<IEnumerable<BybitSpotBalance>>(Array.Empty<BybitSpotBalance>());

            return result.As(result.Data.Balances);
        }

        #endregion

        #region Get margin account info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitMarginAccountInfo>> GetMarginAccountInfoAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitMarginAccountInfo>(_baseClient.GetUrl("spot/v3/private/cross-margin-account"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
