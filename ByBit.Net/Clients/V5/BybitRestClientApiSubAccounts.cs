using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc />
    public class BybitRestClientApiSubAccounts : IBybitRestClientApiSubAccounts
    {
        private BybitRestClientApi _baseClient;

        internal BybitRestClientApiSubAccounts(BybitRestClientApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Create Sub Account

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSubAccount>> CreateSubAccountAsync(
            string username,
            SubAccountType type,
            string? password = null,
            bool? enableQuickLogin = null,
            bool? isUta = null,
            string? note = null,
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "username", username },
                { "memberType", EnumConverter.GetString(type) },
            };
            parameters.AddOptionalParameter("password", password);
            if (enableQuickLogin != null)
                parameters.AddOptionalParameter("switch", enableQuickLogin.Value ? 1 : 0);
            parameters.AddOptionalParameter("isUta", isUta);
            parameters.AddOptionalParameter("note", note);
            return await _baseClient.SendRequestAsync<BybitSubAccount>(_baseClient.GetUrl("v5/user/create-sub-member"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Create Sub Account

        /// <inheritdoc />
        public async Task<WebCallResult<BybitApiKeyInfo>> CreateSubAccountApiKeyAsync(
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
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "subuid", subAccountId },
                { "readOnly", readOnly ? 1 : 0 },
            };
            parameters.AddOptionalParameter("note", note);
            parameters.AddOptionalParameter("ips", ipRestrictions);

            var permissions = new Dictionary<string, List<string>>();
            AddPermission(permissions, permissionContractTradeOrder, "ContractTrade", "Order");
            AddPermission(permissions, permissionContractTradePosition, "ContractTrade", "Position");
            AddPermission(permissions, permissionSpotTrade, "Spot", "SpotTrade");
            AddPermission(permissions, permissionWalletTransfer, "Wallet", "AccountTransfer");
            AddPermission(permissions, permissionWalletSubAccountTransfer, "Wallet", "SubMemberTransferList");
            AddPermission(permissions, permissionOptionsTrade, "Options", "OptionsTrade");
            AddPermission(permissions, permissionExchangeHistory, "Exchange", "ExchangeHistory");
            AddPermission(permissions, permissionCopyTrading, "CopyTrading", "CopyTrading");
            parameters.Add("permissions", permissions);
            return await _baseClient.SendRequestAsync<BybitApiKeyInfo>(_baseClient.GetUrl("v5/user/create-sub-api"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        private void AddPermission(Dictionary<string, List<string>> dict, bool? hasPermission, string key, string value) 
        {
            if (hasPermission != true)
                return;

            if (!dict.ContainsKey(key))
                dict[key] = new List<string>();
            dict[key].Add(value);
        }
        #endregion

        #region Get Subaccounts

        /// <inheritdoc />
        public async Task<WebCallResult<List<BybitSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            var result = await _baseClient.SendRequestAsync<BybitSubAccountWrapper>(_baseClient.GetUrl("v5/user/query-sub-members"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<List<BybitSubAccount>>(default);

            return result.As(result.Data.SubMembers);
        }

        #endregion

        #region Freeze Subaccount

        /// <inheritdoc />
        public async Task<WebCallResult> FreezeSubAccountAsync(string subAccountId, bool freeze, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "subuid", subAccountId },
                { "frozen", freeze ? 1 : 0 },
            };
            return await _baseClient.SendRequestAsync(_baseClient.GetUrl("v5/user/frozen-sub-member"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Edit SubAccount Api Key

        /// <inheritdoc />
        public async Task<WebCallResult<BybitApiKeyInfo>> EditSubAccountApiKeyAsync(
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
            CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("apikey", apiKey);
            if (readOnly.HasValue)
                parameters.AddOptionalParameter("readOnly", readOnly.Value ? 1 : 0);
            parameters.AddOptionalParameter("ips", ipRestrictions);

            var permissions = new Dictionary<string, List<string>>();
            AddPermission(permissions, permissionContractTradeOrder, "ContractTrade", "Order");
            AddPermission(permissions, permissionContractTradePosition, "ContractTrade", "Position");
            AddPermission(permissions, permissionSpotTrade, "Spot", "SpotTrade");
            AddPermission(permissions, permissionWalletTransfer, "Wallet", "AccountTransfer");
            AddPermission(permissions, permissionWalletSubAccountTransfer, "Wallet", "SubMemberTransferList");
            AddPermission(permissions, permissionOptionsTrade, "Options", "OptionsTrade");
            AddPermission(permissions, permissionCopyTrading, "CopyTrading", "CopyTrading");
            AddPermission(permissions, permissionExchangeHistory, "Exchange", "ExchangeHistory");
            parameters.Add("permissions", permissions);
            return await _baseClient.SendRequestAsync<BybitApiKeyInfo>(_baseClient.GetUrl("v5/user/update-sub-api"), HttpMethod.Post, ct, null, true).ConfigureAwait(false);
        }
        #endregion

        #region Delete SubAccount Api Key

        /// <inheritdoc />
        public async Task<WebCallResult> DeleteSubAccountApiKeyAsync(string? apiKey = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("apikey", apiKey);
            return await _baseClient.SendRequestAsync(_baseClient.GetUrl("v5/user/delete-sub-api"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
