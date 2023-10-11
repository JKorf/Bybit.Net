using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
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
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/user/create-subuid" /></para>
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="type">Account type</param>
        /// <param name="password">Password, 8-30 characters, must include numbers, upper and lowercase letters</param>
        /// <param name="enableQuickLogin">Enable quick login</param>
        /// <param name="isUta">Uta account</param>
        /// <param name="note">Set a remark</param>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSubAccount>> CreateSubAccountAsync(string username, SubAccountType type, string? password = null, bool? enableQuickLogin = null, bool? isUta = null, string? note = null, CancellationToken ct = default);

        /// <summary>
        /// Create a new API key for a sub account
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/user/create-subuid-apikey" /></para>
        /// </summary>
        /// <param name="subAccountId">Subaccount id</param>
        /// <param name="readOnly">Readonly key</param>
        /// <param name="permissionContractTradeOrder">Has contract order permission</param>
        /// <param name="permissionContractTradePosition">Has contract position permission</param>
        /// <param name="permissionSpotTrade">Has spot trade permission</param>
        /// <param name="permissionWalletTransfer">Has wallet transfer permission</param>
        /// <param name="permissionWalletSubAccountTransfer">Has permission wallet subaccount transfer permission</param>
        /// <param name="permissionOptionsTrade">Has option trade permission</param>
        /// <param name="permissionExchangeHistory">Has exchange history permission</param>
        /// <param name="permissionCopyTrading">Has copy trade permission</param>
        /// <param name="ipRestrictions">Ip restrictions, comma seperated</param>
        /// <param name="note">Note</param>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitApiKeyInfo>> CreateSubAccountApiKeyAsync(
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
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/user/subuid-list" /></para>
        /// </summary>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<WebCallResult<List<BybitSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default);

        /// <summary>
        /// Edit API key
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/user/modify-sub-apikey" /></para>
        /// </summary>
        /// <param name="apiKey">Api key, should be passed if editing from Master account, should be null if editing own API key from sub account</param>
        /// <param name="readOnly">Readonly</param>
        /// <param name="ipRestrictions">IP restrictions, comma seperated</param>
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
        Task<WebCallResult<BybitApiKeyInfo>> EditSubAccountApiKeyAsync(
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
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/user/rm-sub-apikey" /></para>
        /// </summary>
        /// <param name="apiKey">Api key, should be passed if deleting from Master account, should be null if editing own API key from sub account</param>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<WebCallResult> DeleteSubAccountApiKeyAsync(string? apiKey = null, CancellationToken ct = default);
    }
}