using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.V5
{
    /// <summary>
    /// Bybit sub account endpoints
    /// </summary>
    public interface IBybitRestClientApiSubAccounts
    {
        /// <summary>
        /// Create a new sub account
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/user/create-subuid" /><br />
        /// Endpoint:<br />
        /// POST /v5/user/create-sub-member
        /// </para>
        /// </summary>
        /// <param name="username">["<c>username</c>"] Username</param>
        /// <param name="type">["<c>memberType</c>"] Account type</param>
        /// <param name="password">["<c>password</c>"] Password, 8-30 characters, must include numbers, upper and lowercase letters</param>
        /// <param name="enableQuickLogin">["<c>switch</c>"] Enable quick login</param>
        /// <param name="isUta">["<c>isUta</c>"] Uta account</param>
        /// <param name="note">["<c>note</c>"] Set a remark</param>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitSubAccount>> CreateSubAccountAsync(string username, SubAccountType type, string? password = null, bool? enableQuickLogin = null, bool? isUta = null, string? note = null, CancellationToken ct = default);

        /// <summary>
        /// Create a new API key for a sub account
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/user/create-subuid-apikey" /><br />
        /// Endpoint:<br />
        /// POST /v5/user/create-sub-api
        /// </para>
        /// </summary>
        /// <param name="subAccountId">["<c>subuid</c>"] Subaccount id</param>
        /// <param name="readOnly">["<c>readOnly</c>"] Readonly key</param>
        /// <param name="permissionContractTradeOrder">Has contract order permission</param>
        /// <param name="permissionContractTradePosition">Has contract position permission</param>
        /// <param name="permissionSpotTrade">Has spot trade permission</param>
        /// <param name="permissionWalletTransfer">Has wallet transfer permission</param>
        /// <param name="permissionWalletSubAccountTransfer">Has permission wallet subaccount transfer permission</param>
        /// <param name="permissionOptionsTrade">Has option trade permission</param>
        /// <param name="permissionExchangeHistory">Has exchange history permission</param>
        /// <param name="permissionCopyTrading">Has copy trade permission</param>
        /// <param name="ipRestrictions">["<c>ips</c>"] Ip restrictions, comma seperated</param>
        /// <param name="note">["<c>note</c>"] Note</param>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitApiKeyInfo>> CreateSubAccountApiKeyAsync(
           string subAccountId,
           bool readOnly,
           bool? permissionContractTradeOrder = null,
           bool? permissionContractTradePosition = null,
           bool? permissionSpotTrade = null,
           bool? permissionWalletTransfer = null,
           bool? permissionWalletSubAccountTransfer = null,
           bool? permissionOptionsTrade = null,
           bool? permissionExchangeHistory = null,
           bool? permissionCopyTrading = null,
           string? ipRestrictions = null,
           string? note = null,
           CancellationToken ct = default);

        /// <summary>
        /// Get list of subaccounts
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/user/subuid-list" /><br />
        /// Endpoint:<br />
        /// GET /v5/user/query-sub-members
        /// </para>
        /// </summary>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitSubAccount[]>> GetSubAccountsAsync(CancellationToken ct = default);

        /// <summary>
        /// Edit API key. Note that permissions starting with the same topic (for example `permissionContractTradeOrder` and `permissionContractTradePosition` or `permissionWalletTransfer` and `permissionWalletSubAccountTransfer`) can not be adjusted separately and should both be set when changing one of the values.
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/user/modify-sub-apikey" /><br />
        /// Endpoint:<br />
        /// POST /v5/user/update-sub-api
        /// </para>
        /// </summary>
        /// <param name="apiKey">["<c>apikey</c>"] Api key, should be passed if editing from Master account, should be null if editing own API key from sub account</param>
        /// <param name="readOnly">["<c>readOnly</c>"] Readonly</param>
        /// <param name="ipRestrictions">["<c>ips</c>"] IP restrictions, comma seperated</param>
        /// <param name="permissionContractTradeOrder">Has contract order permission</param>
        /// <param name="permissionContractTradePosition">Has contract position permission</param>
        /// <param name="permissionSpotTrade">Has spot trade permission</param>
        /// <param name="permissionWalletTransfer">Has wallet transfer permission</param>
        /// <param name="permissionWalletSubAccountTransfer">Has permission wallet subaccount transfer permission</param>
        /// <param name="permissionOptionsTrade">Has option trade permission</param>
        /// <param name="permissionExchangeHistory">Has exchange history permission</param>
        /// <param name="permissionCopyTrading">Has copy trade permission</param>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<HttpResult<BybitApiKeyInfo>> EditSubAccountApiKeyAsync(
            string? apiKey = null,
            bool? readOnly = null,
            string? ipRestrictions = null,
            bool? permissionContractTradeOrder = null,
            bool? permissionContractTradePosition = null,
            bool? permissionSpotTrade = null,
            bool? permissionWalletTransfer = null,
            bool? permissionWalletSubAccountTransfer = null,
            bool? permissionOptionsTrade = null,
            bool? permissionCopyTrading = null,
            bool? permissionExchangeHistory = null,
            CancellationToken ct = default);

        /// <summary>
        /// Delete an API key
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/user/rm-sub-apikey" /><br />
        /// Endpoint:<br />
        /// POST /v5/user/delete-sub-api
        /// </para>
        /// </summary>
        /// <param name="apiKey">["<c>apikey</c>"] Api key, should be passed if deleting from Master account, should be null if editing own API key from sub account</param>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<HttpResult> DeleteSubAccountApiKeyAsync(string? apiKey = null, CancellationToken ct = default);

        /// <summary>
        /// Get deposit address for a sub account, only available for master account
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/asset/deposit/sub-deposit-addr" /><br />
        /// Endpoint:<br />
        /// GET /v5/asset/deposit/query-sub-member-address
        /// </para>
        /// </summary>
        /// <param name="subAccountId">["<c>subMemberId</c>"]</param>
        /// <param name="asset">["<c>coin</c>"]</param>
        /// <param name="network">["<c>chainType</c>"]</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<HttpResult<BybitDepositAddress>> GetSubAccountDepositAddressAsync(string subAccountId, string asset, string network, CancellationToken ct = default);
    }
}