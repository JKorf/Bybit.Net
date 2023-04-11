using System.Threading;
using System.Threading.Tasks;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bybit.Net.Interfaces.Clients.GeneralApi
{
    /// <summary>
    /// Bybit user and API key endpoints
    /// </summary>
    public interface IBybitClientGeneralApiMasterSub
    {
        /// <summary>
        /// Get the information of the api key. 
        /// <para><a href="https://bybit-exchange.github.io/docs/account-asset/apikey-info" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<ByBitApiKeyInfoV3>> GetApiKeyInformation(CancellationToken ct = default);
    }
}