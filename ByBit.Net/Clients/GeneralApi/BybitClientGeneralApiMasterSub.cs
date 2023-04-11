using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bybit.Net.Interfaces.Clients.GeneralApi;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bybit.Net.Clients.GeneralApi
{
    /// <inheritdoc />
    public class BybitClientGeneralApiMasterSub : IBybitClientGeneralApiMasterSub
    {
        private readonly BybitClientGeneralApi _baseClient;

        internal BybitClientGeneralApiMasterSub(BybitClientGeneralApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<ByBitApiKeyInfoV3>> GetApiKeyInformation(CancellationToken ct = default)
        {
            var result = await _baseClient.SendRequestAsync<ByBitApiKeyInfoV3>(_baseClient.GetUrl("/user/v3/private/query-api"), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            return result.As(result.Data);
        }
    }
}