using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using Bybit.Net.Enums;
using System;
using CryptoExchange.Net.RateLimiting.Guards;
using System.Linq;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc />
    internal class BybitRestClientApiSubAccounts : IBybitRestClientApiSubAccounts
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
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
            var parameters = new ParameterCollection()
            {
                { "username", username },
                { "memberType", EnumConverter.GetString(type) },
            };
            parameters.AddOptionalParameter("password", password);
            if (enableQuickLogin != null)
                parameters.AddOptionalParameter("switch", enableQuickLogin.Value ? 1 : 0);
            parameters.AddOptionalParameter("isUta", isUta);
            parameters.AddOptionalParameter("note", note);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/user/create-sub-member", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitSubAccount>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Create Sub Account Api Key

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
            var parameters = new ParameterCollection()
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

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/user/create-sub-api", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitApiKeyInfo>(request, parameters, ct).ConfigureAwait(false);
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
        public async Task<WebCallResult<BybitSubAccount[]>> GetSubAccountsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/user/query-sub-members", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BybitSubAccountWrapper>(request, null, ct).ConfigureAwait(false);
            if (!result)
                return result.As<BybitSubAccount[]>(default);

            return result.As(result.Data.SubMembers);
        }

        #endregion

        #region Freeze Subaccount

        /// <inheritdoc />
        public async Task<WebCallResult> FreezeSubAccountAsync(string subAccountId, bool freeze, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "subuid", subAccountId },
                { "frozen", freeze ? 1 : 0 },
            };
            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/user/frozen-sub-member", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
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
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("apikey", apiKey);
            if (readOnly.HasValue)
                parameters.AddOptionalParameter("readOnly", readOnly.Value ? 1 : 0);
            parameters.AddOptionalParameter("ips", ipRestrictions);

            var permissions = new Dictionary<string, List<string>>();
            EditPermission(permissions, permissionContractTradeOrder, "ContractTrade", "Order");
            EditPermission(permissions, permissionContractTradePosition, "ContractTrade", "Position");
            EditPermission(permissions, permissionSpotTrade, "Spot", "SpotTrade");
            EditPermission(permissions, permissionWalletTransfer, "Wallet", "AccountTransfer");
            EditPermission(permissions, permissionWalletSubAccountTransfer, "Wallet", "SubMemberTransferList");
            EditPermission(permissions, permissionOptionsTrade, "Options", "OptionsTrade");
            EditPermission(permissions, permissionCopyTrading, "CopyTrading", "CopyTrading");
            EditPermission(permissions, permissionExchangeHistory, "Exchange", "ExchangeHistory");
            parameters.Add("permissions", permissions.ToDictionary(x => x.Key, x => x.Value.ToArray()));

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/user/update-sub-api", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitApiKeyInfo>(request, parameters, ct).ConfigureAwait(false);
        }

        private void EditPermission(Dictionary<string, List<string>> dict, bool? hasPermission, string key, string value)
        {
            if (hasPermission == null)
                return;

            if (!dict.ContainsKey(key))
                dict[key] = new List<string>();

            if (hasPermission == true)
                dict[key].Add(value);
        }
        #endregion

        #region Delete SubAccount Api Key

        /// <inheritdoc />
        public async Task<WebCallResult> DeleteSubAccountApiKeyAsync(string? apiKey = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("apikey", apiKey);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/user/delete-sub-api", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get SubAccount Deposit Address

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDepositAddress>> GetSubAccountDepositAddressAsync(string subAccountId, string asset, string network, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("subMemberId", subAccountId);
            parameters.Add("coin", asset);
            parameters.Add("chainType", network);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/deposit/query-sub-member-address", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitDepositAddress>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion
    }
}
