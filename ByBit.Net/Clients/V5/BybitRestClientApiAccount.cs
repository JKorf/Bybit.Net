using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using Bybit.Net.Enums;
using System.Globalization;
using Bybit.Net.Interfaces.Clients.V5;
using Bybit.Net.Objects.Internal;
using System.Linq;
using CryptoExchange.Net.RateLimiting.Guards;

namespace Bybit.Net.Clients.V5
{
    /// <inheritdoc />
    internal class BybitRestClientApiAccount : IBybitRestClientApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        private BybitRestClientApi _baseClient;

        internal BybitRestClientApiAccount(BybitRestClientApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Set Leverage

        /// <inheritdoc />
        public async Task<HttpResult> SetLeverageAsync(
            Category category,
            string symbol,
            decimal buyLeverage,
            decimal sellLeverage,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "buyLeverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sellLeverage", sellLeverage.ToString(CultureInfo.InvariantCulture) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/position/set-leverage", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Collateral Asset

        /// <inheritdoc />
        public async Task<HttpResult> SetCollateralAssetAsync(
            string asset,
            bool useForCollateral,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "coin", asset },
                { "collateralSwitch", useForCollateral ? "ON" : "OFF" },
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/account/set-collateral-switch", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Multiple Collateral Assets

        /// <inheritdoc />
        public async Task<HttpResult> SetMultipleCollateralAssetsAsync(
            IEnumerable<BybitSetCollateralAssetRequest> assets,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "request", assets.ToArray() }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/account/set-collateral-switch-batch", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Switch Cross Isolated Margin

        /// <inheritdoc />
        public async Task<HttpResult> SwitchCrossIsolatedMarginAsync(
            Category category,
            string symbol,
            TradeMode tradeMode,
            decimal buyLeverage,
            decimal sellLeverage,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "tradeMode", EnumConverter.GetString(tradeMode) },
                { "buyLeverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sellLeverage", sellLeverage.ToString(CultureInfo.InvariantCulture) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/position/switch-isolated", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set TakeProfit StopLoss Mode

        /// <inheritdoc />
        public async Task<HttpResult<BybitTakeProfitStopLossMode>> SetTakeProfitStopLossModeAsync(
            Category category,
            string symbol,
            StopLossTakeProfitMode tpSlMode,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "tpSlMode", EnumConverter.GetString(tpSlMode) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/position/set-tpsl-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitTakeProfitStopLossMode>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Switch Position Mode

        /// <inheritdoc />
        public async Task<HttpResult> SwitchPositionModeAsync(
            Category category,
            PositionMode mode,
            string? symbol = null,
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "mode", EnumConverter.GetString(mode) },
            };

            parameters.Add("symbol", symbol);
            parameters.Add("coin", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/position/switch-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Risk Limit

        /// <inheritdoc />
        public async Task<HttpResult<BybitSetRiskLimit>> SetRiskLimitAsync(
            Category category,
            string symbol,
            int riskId,
            PositionIdx? positionIdx = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "riskId", riskId }
            };

            parameters.Add("positionIdx", EnumConverter.GetString(positionIdx));

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/position/set-risk-limit", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitSetRiskLimit>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Auto Add Margin

        /// <inheritdoc />
        public async Task<HttpResult> SetAutoAddMarginAsync(
            Category category,
            string symbol,
            bool autoAddMargin,
            PositionIdx? positionIdx = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "autoAddMargin", autoAddMargin ? "1" : "0" }
            };

            parameters.Add("positionIdx", EnumConverter.GetString(positionIdx));

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/position/set-auto-add-margin", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Balances

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitBalance>>> GetBalancesAsync(
            AccountType accountType,
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "accountType", EnumConverter.GetString(accountType) }
            };

            parameters.Add("coin", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/wallet-balance", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitBalance>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Borrow History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitBorrowHistory>>> GetBorrowHistoryAsync(
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);

            parameters.Add("currency", asset);
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/borrow-history", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitBorrowHistory>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Collateral Info

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitCollateralInfo>>> GetCollateralInfoAsync(
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);

            parameters.Add("currency", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/collateral-info", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitCollateralInfo>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Asset Greeks

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitGreeks>>> GetAssetGreeksAsync(
            string? baseAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);

            parameters.Add("baseCoin", baseAsset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/coin-greeks", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitGreeks>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Fee Rate

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitFeeRate>>> GetFeeRateAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);

            if (category != Category.Undefined)
            {
                parameters.Add("category", EnumConverter.GetString(category));
            }
            parameters.Add("symbol", symbol);
            parameters.Add("baseCoin", baseAsset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/fee-rate", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));

            var weight = category == Category.Linear ? 1 : 2;
            return await _baseClient.SendAsync<BybitResponse<BybitFeeRate>>(request, parameters, ct, singleLimiterWeight: weight).ConfigureAwait(false);
        }

        #endregion

        #region Get Margin Account Info

        /// <inheritdoc />
        public async Task<HttpResult<BybitAccountInfo>> GetMarginAccountInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/info", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitAccountInfo>(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Transaction History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitTransactionLog>>> GetTransactionHistoryAsync(
            AccountType? accountType = null,
            Category? category = null,
            string? asset = null,
            string? baseAsset = null,
            TransactionLogType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("accountType", EnumConverter.GetString(accountType));
            parameters.Add("category", EnumConverter.GetString(category));
            parameters.Add("currency", asset);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("type", EnumConverter.GetString(type));
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/transaction-log", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(25, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitTransactionLog>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Classic Contract Transaction History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitTransactionLog>>> GetClassicContractTransactionHistoryAsync(
            string? asset = null,
            string? baseAsset = null,
            TransactionLogType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("currency", asset);
            parameters.Add("baseCoin", baseAsset);
            parameters.Add("type", EnumConverter.GetString(type));
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/contract-transaction-log", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitTransactionLog>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Margin Mode

        /// <inheritdoc />
        public async Task<HttpResult<BybitSetMarginModeResult>> SetMarginModeAsync(
            MarginMode marginMode,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "setMarginMode", EnumConverter.GetString(marginMode) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/account/set-margin-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitSetMarginModeResult>(request, parameters, ct).ConfigureAwait(false);            
        }

        #endregion

        #region Get Asset Info

        /// <inheritdoc />
        public async Task<HttpResult<BybitAccountAssetInfo>> GetAssetInfoAsync(
            AccountType accountType,
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "accountType", EnumConverter.GetString(accountType) }
            };
            parameters.Add("coin", asset);


            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/transfer/query-asset-info", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(60, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BybitAssetInfoWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitAccountAssetInfo>(result);

            return HttpResult.Ok(result, result.Data.Spot);
        }

        #endregion

        #region Get All Asset Balances

        /// <inheritdoc />
        public async Task<HttpResult<BybitAllAssetBalances>> GetAllAssetBalancesAsync(
            AccountType accountType,
            string? memberId = null,
            string? asset = null,
            bool? withBonus = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "accountType", EnumConverter.GetString(accountType) }
            };
            parameters.Add("coin", asset);
            parameters.Add("memberId", memberId);
            parameters.Add("withBonus", withBonus == true ? "1" : "0");

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/transfer/query-account-coins-balance", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitAllAssetBalances>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Asset Balance

        /// <inheritdoc />
        public async Task<HttpResult<BybitSingleAssetBalance>> GetAssetBalanceAsync(
            AccountType accountType,
            string asset,
            string? memberId = null,
            bool? withBonus = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "accountType", EnumConverter.GetString(accountType) },
                { "coin", asset }
            };
            parameters.Add("memberId", memberId);
            parameters.Add("withBonus", withBonus == true ? "1" : "0");

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/transfer/query-account-coin-balance", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitSingleAssetBalance>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Transferable Assets

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<string>>> GetTransferableAssetsAsync(
            AccountType fromAccountType,
            AccountType toAccountType,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "fromAccountType", EnumConverter.GetString(fromAccountType) },
                { "toAccountType", EnumConverter.GetString(toAccountType) },
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/transfer/query-transfer-coin-list", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(60, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<string>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Create Internal transfer

        /// <inheritdoc />
        public async Task<HttpResult<BybitTransferId>> CreateInternalTransferAsync(
            string asset,
            decimal quantity,
            AccountType fromAccountType,
            AccountType toAccountType,
            string? transferId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "fromAccountType", EnumConverter.GetString(fromAccountType) },
                { "toAccountType", EnumConverter.GetString(toAccountType) },
                { "coin", asset },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "transferId", transferId ?? Guid.NewGuid().ToString() }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/asset/transfer/inter-transfer", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(60, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitTransferId>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Internal Transfers

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitTransfer>>> GetInternalTransfersAsync(
            string? transferId = null,
            string? asset = null,
            TransferStatus? transferStatus = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("transferId", transferId);
            parameters.Add("coin", asset);
            parameters.Add("status", EnumConverter.GetString(transferStatus));
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/transfer/query-inter-transfer-list", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(60, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitTransfer>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Create Universal transfer

        /// <inheritdoc />
        public async Task<HttpResult<BybitTransferId>> CreateUniversalTransferAsync(
            string asset,
            decimal quantity,
            string fromMemberId,
            string toMemberId,
            AccountType fromAccountType,
            AccountType toAccountType,
            string? transferId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "fromAccountType", EnumConverter.GetString(fromAccountType) },
                { "toAccountType", EnumConverter.GetString(toAccountType) },
                { "coin", asset },
                { "fromMemberId", fromMemberId },
                { "toMemberId", toMemberId },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "transferId", transferId ?? Guid.NewGuid().ToString() }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/asset/transfer/universal-transfer", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitTransferId>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Universal Transfers

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitTransfer>>> GetUniversalTransfersAsync(
            string? transferId = null,
            string? asset = null,
            TransferStatus? transferStatus = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("transferId", transferId);
            parameters.Add("coin", asset);
            parameters.Add("status", EnumConverter.GetString(transferStatus));
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/transfer/query-universal-transfer-list", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitTransfer>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Allowed Deposit Info

        /// <inheritdoc />
        public async Task<HttpResult<BybitAllowedDepositInfoResponse>> GetAllowedDepositAssetInfoAsync(
            string? asset = null,
            string? network = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("chain", network);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/deposit/query-allowed-list", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitAllowedDepositInfoResponse>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Deposit Account

        /// <inheritdoc />
        public async Task<HttpResult<BybitOperationResult>> SetDepositAccountAsync(
            AccountType accountType,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "accountType", EnumConverter.GetString(accountType) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/asset/deposit/deposit-to-account", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitOperationResult>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Deposits

        /// <inheritdoc />
        public async Task<HttpResult<BybitDeposits>> GetDepositsAsync(
            string? asset = null,
            string? id = null,
            string? transactionId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("id", id);
            parameters.Add("txID", transactionId);
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/deposit/query-record", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(100, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitDeposits>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Internal Deposits

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitInternalDeposit>>> GetInternalDepositsAsync(
            string? transactionId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            parameters.Add("txID", transactionId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/deposit/query-internal-record", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitResponse<BybitInternalDeposit>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Deposit Address

        /// <inheritdoc />
        public async Task<HttpResult<BybitDepositAddress>> GetDepositAddressAsync(
            string asset,
            string? networkType = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "coin", asset }
            };
            parameters.Add("chainType", networkType);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/deposit/query-address", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(300, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitDepositAddress>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Asset info

        /// <inheritdoc />
        public async Task<HttpResult<BybitUserAssetInfos>> GetAssetInfoAsync(
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/coin/query-info", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(600, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitUserAssetInfos>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Withdrawals

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitWithdrawal>>> GetWithdrawalsAsync(
            string? withdrawId = null,
            string? asset = null,
            WithdrawalType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            string? transactionId = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("withdrawID", withdrawId);
            parameters.Add("coin", asset);
            parameters.Add("withdrawType", EnumConverter.GetString(type));
            parameters.Add("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.Add("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            parameters.Add("txID", transactionId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/withdraw/query-record", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(100, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitWithdrawal>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Delayed Withdrawal Quantity

        /// <inheritdoc />
        public async Task<HttpResult<BybitDelayedWithdrawal>> GetDelayedWithdrawQuantityAsync(
            string asset,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "coin", asset }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/withdraw/withdrawable-amount", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitDelayedWithdrawal>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Withdraw

        /// <inheritdoc />
        public async Task<HttpResult<BybitId>> WithdrawAsync(
            string asset,
            string network,
            string toAddress,
            decimal quantity,
            WithdrawAccountType accountType,
            string? tag = null,
            bool? forceNetwork = null,
            bool? feeType = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "coin", asset },
                { "chain", network },
                { "address", toAddress },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "timestamp", DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow) }
            };

            parameters.Add("tag", tag);
            parameters.Add("accountType", EnumConverter.GetString(accountType));
            parameters.Add("forceChain", forceNetwork == null ? null : forceNetwork.Value ? 1 : 0);
            parameters.Add("feeType", feeType == null ? null : feeType.Value ? 1 : 0);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/asset/withdraw/create", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitId>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Withdrawal

        /// <inheritdoc />
        public async Task<HttpResult<BybitOperationResult>> CancelWithdrawalAsync(
            string id,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "id", id },
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/asset/withdraw/cancel", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(60, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitOperationResult>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Api Key Info

        /// <inheritdoc />
        public async Task<HttpResult<BybitApiKeyInfo>> GetApiKeyInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/user/query-api", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitApiKeyInfo>(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Edit Api Key

        /// <inheritdoc />
        public async Task<HttpResult<BybitApiKeyInfo>> EditApiKeyAsync(
            bool? readOnly = null,
            bool? permissionContractTradeOrder = null,
            bool? permissionContractTradePosition = null,
            bool? permissionSpotTrade = null,
            bool? permissionWalletTransfer = null,
            bool? permissionWalletSubAccountTransfer = null,
            bool? permissionOptionsTrade = null,
            bool? permissionCopyTrading = null,
            bool? permissionBlockTrading = null,
            bool? permissionExchangeHistory = null,
            bool? permissionNftProductList = null,
            bool? permissionAffiliate = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            if (readOnly.HasValue)
                parameters.Add("readOnly", readOnly.Value ? 1 : 0);

            var permissions = new Dictionary<string, List<string>>();
            AddPermission(permissions, permissionContractTradeOrder, "ContractTrade", "Order");
            AddPermission(permissions, permissionContractTradePosition, "ContractTrade", "Position");
            AddPermission(permissions, permissionSpotTrade, "Spot", "SpotTrade");
            AddPermission(permissions, permissionWalletTransfer, "Wallet", "AccountTransfer");
            AddPermission(permissions, permissionWalletSubAccountTransfer, "Wallet", "SubMemberTransferList");
            AddPermission(permissions, permissionOptionsTrade, "Options", "OptionsTrade");
            AddPermission(permissions, permissionBlockTrading, "BlockTrade", "BlockTrade");
            AddPermission(permissions, permissionCopyTrading, "CopyTrading", "CopyTrading");
            AddPermission(permissions, permissionExchangeHistory, "Exchange", "ExchangeHistory");
            AddPermission(permissions, permissionNftProductList, "NFT", "NFTQueryProductList");
            AddPermission(permissions, permissionAffiliate, "Affiliate", "Affiliate");
            parameters.Add("permissions", permissions.ToDictionary(x => x.Key, x => x.Value.ToArray()));

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/user/update-api", BybitExchange.RateLimiter.BybitRest, 1, true,
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

        #region Delete Api Key

        /// <inheritdoc />
        public async Task<HttpResult> DeleteApiKeyAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/user/delete-api", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Account Types

        /// <inheritdoc />
        public async Task<HttpResult<BybitAccountTypeInfo[]>> GetAccountTypesAsync(IEnumerable<string>? subAccountIds = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            if (subAccountIds != null)
                parameters.Add("memberIds", string.Join(",", subAccountIds));

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/user/get-member-type", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitAccountTypeInfoWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitAccountTypeInfo[]>(result);

            return HttpResult.Ok(result, result.Data.Accounts);
        }

        #endregion

        #region Add Or Reduce Margin

        /// <inheritdoc />
        public async Task<HttpResult<BybitPosition>> AddOrReduceMarginAsync(
            Category category,
            string symbol,
            decimal margin,
            PositionIdx? positionIdx = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "margin", margin.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.Add("positionIdx", EnumConverter.GetString(positionIdx));

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/position/add-margin", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitPosition>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Spot Margin Leverage

        /// <inheritdoc />
        public async Task<HttpResult> SetSpotMarginLeverageAsync(decimal leverage, string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "leverage", leverage.ToString(CultureInfo.InvariantCulture) }
            };
            parameters.Add("currency", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/spot-margin-trade/set-leverage", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Margin Status And Leverage

        /// <inheritdoc />
        public async Task<HttpResult<BybitSpotMarginLeverageStatus>> GetSpotMarginStatusAndLeverageAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/spot-margin-trade/state", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitSpotMarginLeverageStatus>(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Spot Margin Trade Mode

        /// <inheritdoc />
        public async Task<HttpResult<BybitSpotMarginStatus>> SetSpotMarginTradeModeAsync(bool spotMarginMode, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "spotMarginMode", spotMarginMode ? "1" : "0" }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/spot-margin-trade/switch-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitSpotMarginStatus>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Margin Data

        /// <inheritdoc />
        public async Task<HttpResult<BybitSpotMarginVipMarginList[]>> GetSpotMarginDataAsync(string? asset = null, string? vipLevel = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("currency", asset);
            parameters.Add("vipLevel", vipLevel);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/spot-margin-trade/data", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitSpotMarginVipMarginData>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitSpotMarginVipMarginList[]>(result);
            return HttpResult.Ok(result, result.Data.VipCoinList);
        }

        #endregion

        #region Get Spot Margin Interest Rate History

        /// <inheritdoc />
        public async Task<HttpResult<BybitSpotMarginBorrowRate[]>> GetSpotMarginInterestRateHistoryAsync(string asset, string? vipLevel = null, DateTime? startTime = null, DateTime? endTime = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("currency", asset);
            parameters.Add("vipLevel", vipLevel);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/spot-margin-trade/interest-rate-history", BybitExchange.RateLimiter.BybitRest, 1, true); 
            var result = await _baseClient.SendAsync<BybitResponse<BybitSpotMarginBorrowRate>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitSpotMarginBorrowRate[]>(result);
            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Set Spot Margin Auto Repay Mode

        /// <inheritdoc />
        public async Task<HttpResult<BybitSpotMarginAutoRepayMode[]>> SetSpotMarginAutoRepayModeAsync(bool enabled, string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("currency", asset);
            parameters.Add("autoRepayMode", enabled ? "1" : "0");

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/spot-margin-trade/set-auto-repay-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitSpotMarginAutoRepayModeWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitSpotMarginAutoRepayMode[]>(result);
            return HttpResult.Ok(result, result.Data.Data);
        }

        #endregion

        #region Get Spot Margin Auto Repay Mode

        /// <inheritdoc />
        public async Task<HttpResult<BybitSpotMarginAutoRepayMode[]>> GetSpotMarginAutoRepayModeAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("currency", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/spot-margin-trade/get-auto-repay-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitSpotMarginAutoRepayModeWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitSpotMarginAutoRepayMode[]>(result);
            return HttpResult.Ok(result, result.Data.Data);
        }

        #endregion

        #region Get Spot Margin Asset Data

        /// <inheritdoc />
        public async Task<HttpResult<BybitMarginAssetData[]>> GetSpotMarginAssetDataAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("currency", asset);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/spot-margin-trade/currency-data", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitList<BybitMarginAssetData>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitMarginAssetData[]>(result);
            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get Broker Account Info

        /// <inheritdoc />
        public async Task<HttpResult<BybitBrokerAccountInfo>> GetBrokerAccountInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/broker/account-info", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitBrokerAccountInfo>(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Broker Earnings

        /// <inheritdoc />
        public async Task<HttpResult<BybitBrokerEarnings>> GetBrokerEarningsAsync(string? bizType = null, DateTime? startTime = null, DateTime? endTime = null, string? subAccountId = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("bizType", bizType);
            parameters.Add("begin", startTime?.ToString("yyyyMMdd"));
            parameters.Add("end", endTime?.ToString("yyyyMMdd"));
            parameters.Add("uid", subAccountId);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/broker/earnings-info", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitBrokerEarnings>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Spot Hedging Mode

        /// <inheritdoc />
        public async Task<HttpResult> SetSpotHedgingModeAsync(bool spotHedgingMode, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "setHedgingMode", spotHedgingMode ? "ON" : "OFF" }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/account/set-hedging-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Repay Liabilities

        /// <inheritdoc />
        public async Task<HttpResult<BybitLiabilityRepayment[]>> RepayLiabilitiesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/account/quick-repayment", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitList<BybitLiabilityRepayment>>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success || result.Data == null)
                return HttpResult.Fail<BybitLiabilityRepayment[]>(result);

            if (result.Data.List == null)
                return HttpResult.Ok<BybitLiabilityRepayment[]>(result, Array.Empty<BybitLiabilityRepayment>());

            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Request Demo Funds

        /// <inheritdoc />
        public async Task<HttpResult> RequestDemoFundsAsync(Dictionary<string, decimal> funds, bool? addOrReduce = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("adjustType", addOrReduce == null ? null : addOrReduce == true ? 0 : 1);
            parameters.Add("utaDemoApplyMoney", funds.Select(f => new BybitDemoFundsRequest { Asset = f.Key, Quantity = f.Value }).ToArray());

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/account/demo-apply-money", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Convert Assets

        /// <inheritdoc />
        public async Task<HttpResult<BybitConvertAsset[]>> GetConvertAssetsAsync(ConvertAccountType accountType, string? asset = null, ConvertAssetSide? side = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "accountType", EnumConverter.GetString(accountType) }
            };
            parameters.Add("coin", asset);
            parameters.Add("side", side);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/exchange/query-coin-list", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitConvertAssetWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitConvertAsset[]>(result);
            return HttpResult.Ok(result, result.Data.Assets);
        }

        #endregion
        
        #region Get Convert Quote

        /// <inheritdoc />
        public async Task<HttpResult<BybitConvertQuote>> GetConvertQuoteAsync(ConvertAccountType accountType, string fromAsset, string toAsset, decimal quantity, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("accountType", accountType);
            parameters.Add("fromCoin", fromAsset);
            parameters.Add("toCoin", toAsset);
            parameters.Add("requestCoin", fromAsset);
            parameters.Add("requestAmount", quantity);
            parameters.Add("requestId", clientOrderId);
            parameters.Add("paramType", "opFrom");
            parameters.Add("paramValue", LibraryHelpers.GetClientReference(() => _baseClient.ClientOptions.Referer, _baseClient.Exchange));

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/asset/exchange/quote-apply", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitConvertQuote>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Convert Confirm Quote

        /// <inheritdoc />
        public async Task<HttpResult<BybitConvertTransactionResult>> ConvertConfirmQuoteAsync(string quoteTransactionId, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("quoteTxId", quoteTransactionId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/asset/exchange/convert-execute", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitConvertTransactionResult>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Convert Confirm Quote

        /// <inheritdoc />
        public async Task<HttpResult<BybitConvertTransaction>> GetConvertStatusAsync(ConvertAccountType accountType, string quoteTransactionId, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("quoteTxId", quoteTransactionId);
            parameters.Add("accountType", accountType);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/exchange/convert-result-query", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitConvertTransactionWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitConvertTransaction>(result);
            return HttpResult.Ok(result, result.Data.Result);
        }

        #endregion

        #region Get Convert History

        /// <inheritdoc />
        public async Task<HttpResult<BybitConvertTransaction[]>> GetConvertHistoryAsync(ConvertAccountType? accountType = null, int? page = null, int? pageSize = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("accountType", accountType);
            parameters.Add("index", page);
            parameters.Add("limit", pageSize);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/asset/exchange/query-convert-history", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitConvertTransactionListWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitConvertTransaction[]>(result);
            return HttpResult.Ok(result, result.Data.List);
        }

        #endregion

        #region Get Transferable

        /// <inheritdoc />
        public async Task<HttpResult<BybitTransferable>> GetTransferableAsync(string asset, CancellationToken ct = default)
            => await GetTransferableAsync([asset], ct).ConfigureAwait(false);

        /// <inheritdoc />
        public async Task<HttpResult<BybitTransferable>> GetTransferableAsync(IEnumerable<string> assets, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("coinName", string.Join(",", assets));

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/withdrawal", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitTransferable>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Price Limit Behavior

        /// <inheritdoc />
        public async Task<HttpResult> SetPriceLimitBehaviorAsync(Category category, bool allowModifyPrice, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("category", category);
            parameters.Add("modifyEnable", allowModifyPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "v5/account/set-limit-px-action", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot symbols

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitSpotSymbol>>> GetSpotSymbolsAsync(string? symbol = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(Category.Spot) }
            };
            parameters.Add("symbol", symbol);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/instruments-info", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitResponse<BybitSpotSymbol>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Linear Inverse symbols

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitLinearInverseSymbol>>> GetLinearInverseSymbolsAsync(
            Category category,
            string? symbol = null,            
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            if (category != Category.Linear && category != Category.Inverse)
                throw new ArgumentException("Invalid category; should be Linear or Inverse");

            var parameters = new Parameters(BybitExchange._parameterSerializationSettings)
            {
                { "category", EnumConverter.GetString(category) }
            };
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "v5/account/instruments-info", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitResponse<BybitLinearInverseSymbol>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Withdraw Address List

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitWithdrawAddress>>> GetWithdrawAddressListAsync(
            string? asset = null,
            string? network = null,
            AddressType? addressType = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("coin", asset);
            parameters.Add("chain", network);
            parameters.Add("addressType", addressType);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/asset/withdraw/query-address", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitResponse<BybitWithdrawAddress>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Small Balance Assets

        /// <inheritdoc />
        public async Task<HttpResult<BybitSmallBalanceAssets>> GetSmallBalanceAssetsAsync(
            ConvertAccountType accountType,
            string? fromAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("accountType", accountType);
            parameters.Add("fromCoin", fromAsset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/asset/covert/small-balance-list", BybitExchange.RateLimiter.BybitRest, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitSmallBalanceAssets>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Small Balances Quote

        /// <inheritdoc />
        public async Task<HttpResult<BybitSmallBalancesQuote>> GetSmallBalancesQuoteAsync(
            ConvertAccountType accountType,
            IEnumerable<string> fromAssets,
            string toAsset,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("accountType", accountType);
            parameters.Add("fromCoinList", fromAssets.ToArray());
            parameters.Add("toCoin", toAsset);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/asset/covert/get-quote", BybitExchange.RateLimiter.BybitRest, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitSmallBalancesQuote>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Confirm Small Balances Quote

        /// <inheritdoc />
        public async Task<HttpResult<BybitSmallBalancesQuoteResult>> ConfirmSmallBalancesQuoteAsync(
            string quoteId,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("quoteId", quoteId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/asset/covert/small-balance-execute", BybitExchange.RateLimiter.BybitRest, 1, true,
                limitGuard: new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitSmallBalancesQuoteResult>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Small Balance Exchange History

        /// <inheritdoc />
        public async Task<HttpResult<BybitPage<BybitSmallBalancesExchangeItem>>> GetSmallBalancesExchangeHistoryAsync(
            ConvertAccountType? accountType = null,
            string? quoteId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? page = null,
            int? pageSize = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("accountType", accountType);
            parameters.Add("quoteId", quoteId);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("cursor", page);
            parameters.Add("size", pageSize);

            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/asset/covert/small-balance-history", BybitExchange.RateLimiter.BybitRest, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitPage<BybitSmallBalancesExchangeItem>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Sign Agreement

        /// <inheritdoc />
        public async Task<HttpResult> SignAgreementAsync(AgreementCategory category, bool agree, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("category", category, EnumSerialization.Number);
            parameters.Add("agree", agree);
            var request = _definitions.GetOrCreate(HttpMethod.Post, _baseClient.BaseAddress, "/v5/user/agreement", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Funding Transaction History

        /// <inheritdoc />
        public async Task<HttpResult<BybitResponse<BybitFundingTransfer>>> GetFundingTransactionHistoryAsync(DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("createTimeFrom", startTime);
            parameters.Add("createTimeTo", endTime);
            parameters.Add("limit", limit);
            parameters.Add("cursor", cursor);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/asset/fundinghistory", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitResponse<BybitFundingTransfer>>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Asset Overview

        /// <inheritdoc />
        public async Task<HttpResult<BybitAccountOverview>> GetAssetOverviewAsync(
            string? memberId = null,
            string? valuationAsset = null,
            AssetAccountType? accountType = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("memberId", memberId);
            parameters.Add("valuationCurrency", valuationAsset);
            parameters.Add("accountType", accountType);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/asset/asset-overview", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitAccountOverview>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Spread Max Order Quantity

        /// <inheritdoc />
        public async Task<HttpResult<BybitMaxSpreadQuantity>> GetSpreadMaxOrderQuantityAsync(
            string symbol,
            OrderSide side,
            decimal price,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("side", side == OrderSide.Buy ? 1 : 2);
            parameters.Add("orderPrice", price);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/spread/max-qty", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitMaxSpreadQuantity>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

        #region Get Option Asset Info

        /// <inheritdoc />
        public async Task<HttpResult<BybitOptionAssetInfo[]>> GetOptionAssetInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/account/option-asset-info", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitOptionAssetInfoWrapper>(request, null, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<BybitOptionAssetInfo[]>(result);
            return HttpResult.Ok(result, result.Data.Result);
        }

        #endregion

        #region Get Analysis Trade Info

        /// <inheritdoc />
        public async Task<HttpResult<BybitAnalysisTradeInfo>> GetAnalysisTradeInfoAsync(
            string symbol,
            DateTime? startTime = null,
            DateTime? endTime = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(BybitExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            var request = _definitions.GetOrCreate(HttpMethod.Get, _baseClient.BaseAddress, "/v5/account/trade-info-for-analysis", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitAnalysisTradeInfo>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        #endregion

    }
}
