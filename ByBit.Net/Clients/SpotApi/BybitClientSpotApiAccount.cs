using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Spot;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <inheritdoc />
    public class BybitClientSpotApiAccount : IBybitClientSpotApiAccount
    {
        private BybitClientSpotApi _baseClient;

        internal BybitClientSpotApiAccount(BybitClientSpotApi baseClient)
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
    }
}
