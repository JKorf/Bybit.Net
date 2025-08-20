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
        public async Task<WebCallResult> SetLeverageAsync(
            Category category,
            string symbol,
            decimal buyLeverage,
            decimal sellLeverage,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "buyLeverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sellLeverage", sellLeverage.ToString(CultureInfo.InvariantCulture) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/position/set-leverage", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Collateral Asset

        /// <inheritdoc />
        public async Task<WebCallResult> SetCollateralAssetAsync(
            string asset,
            bool useForCollateral,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "coin", asset },
                { "collateralSwitch", useForCollateral ? "ON" : "OFF" },
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/account/set-collateral-switch", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Multiple Collateral Assets

        /// <inheritdoc />
        public async Task<WebCallResult> SetMultipleCollateralAssetsAsync(
            IEnumerable<BybitSetCollateralAssetRequest> assets,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "request", assets.ToArray() }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/account/set-collateral-switch-batch", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Switch Cross Isolated Margin

        /// <inheritdoc />
        public async Task<WebCallResult> SwitchCrossIsolatedMarginAsync(
            Category category,
            string symbol,
            TradeMode tradeMode,
            decimal buyLeverage,
            decimal sellLeverage,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "tradeMode", EnumConverter.GetString(tradeMode) },
                { "buyLeverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sellLeverage", sellLeverage.ToString(CultureInfo.InvariantCulture) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/position/switch-isolated", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set TakeProfit StopLoss Mode

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTakeProfitStopLossMode>> SetTakeProfitStopLossModeAsync(
            Category category,
            string symbol,
            StopLossTakeProfitMode tpSlMode,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "tpSlMode", EnumConverter.GetString(tpSlMode) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/position/set-tpsl-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitTakeProfitStopLossMode>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Switch Position Mode

        /// <inheritdoc />
        public async Task<WebCallResult> SwitchPositionModeAsync(
            Category category,
            PositionMode mode,
            string? symbol = null,
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "mode", EnumConverter.GetString(mode) },
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("coin", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/position/switch-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Risk Limit

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSetRiskLimit>> SetRiskLimitAsync(
            Category category,
            string symbol,
            int riskId,
            PositionIdx? positionIdx = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "riskId", riskId }
            };

            parameters.AddOptionalParameter("positionIdx", EnumConverter.GetString(positionIdx));

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/position/set-risk-limit", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitSetRiskLimit>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Auto Add Margin

        /// <inheritdoc />
        public async Task<WebCallResult> SetAutoAddMarginAsync(
            Category category,
            string symbol,
            bool autoAddMargin,
            PositionIdx? positionIdx = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "autoAddMargin", autoAddMargin ? "1" : "0" }
            };

            parameters.AddOptionalParameter("positionIdx", EnumConverter.GetString(positionIdx));

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/position/set-auto-add-margin", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Balances

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitBalance>>> GetBalancesAsync(
            AccountType accountType,
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "accountType", EnumConverter.GetString(accountType) }
            };

            parameters.AddOptionalParameter("coin", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/account/wallet-balance", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitBalance>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Borrow History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitBorrowHistory>>> GetBorrowHistoryAsync(
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();

            parameters.AddOptionalParameter("currency", asset);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/account/borrow-history", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitBorrowHistory>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Collateral Info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitCollateralInfo>>> GetCollateralInfoAsync(
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();

            parameters.AddOptionalParameter("currency", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/account/collateral-info", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitCollateralInfo>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Asset Greeks

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitGreeks>>> GetAssetGreeksAsync(
            string? baseAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();

            parameters.AddOptionalParameter("baseCoin", baseAsset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/coin-greeks", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitGreeks>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Fee Rate

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitFeeRate>>> GetFeeRateAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();

            if (category != Category.Undefined)
            {
                parameters.AddOptionalParameter("category", EnumConverter.GetString(category));
            }
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/account/fee-rate", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));

            var weight = category == Category.Linear ? 1 : 2;
            return await _baseClient.SendAsync<BybitResponse<BybitFeeRate>>(request, parameters, ct, singleLimiterWeight: weight).ConfigureAwait(false);
        }

        #endregion

        #region Get Margin Account Info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitAccountInfo>> GetMarginAccountInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/account/info", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitAccountInfo>(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Transaction History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitTransactionLog>>> GetTransactionHistoryAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("accountType", EnumConverter.GetString(accountType));
            parameters.AddOptionalParameter("category", EnumConverter.GetString(category));
            parameters.AddOptionalParameter("currency", asset);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("type", EnumConverter.GetString(type));
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/account/transaction-log", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitTransactionLog>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Classic Contract Transaction History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitTransactionLog>>> GetClassicContractTransactionHistoryAsync(
            string? asset = null,
            string? baseAsset = null,
            TransactionLogType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("currency", asset);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("type", EnumConverter.GetString(type));
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/account/contract-transaction-log", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitTransactionLog>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Margin Mode

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSetMarginModeResult>> SetMarginModeAsync(
            MarginMode marginMode,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "setMarginMode", EnumConverter.GetString(marginMode) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/account/set-margin-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitSetMarginModeResult>(request, parameters, ct).ConfigureAwait(false);            
        }

        #endregion

        #region Get Asset Info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitAccountAssetInfo>> GetAssetInfoAsync(
            AccountType accountType,
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "accountType", EnumConverter.GetString(accountType) }
            };
            parameters.AddOptionalParameter("coin", asset);


            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/transfer/query-asset-info", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(60, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            var result = await _baseClient.SendAsync<BybitAssetInfoWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result.As<BybitAccountAssetInfo>(null);

            return result.As(result.Data.Spot);
        }

        #endregion

        #region Get All Asset Balances

        /// <inheritdoc />
        public async Task<WebCallResult<BybitAllAssetBalances>> GetAllAssetBalancesAsync(
            AccountType accountType,
            string? memberId = null,
            string? asset = null,
            bool? withBonus = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "accountType", EnumConverter.GetString(accountType) }
            };
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("memberId", memberId);
            parameters.AddOptionalParameter("withBonus", withBonus == true ? "1" : "0");

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/transfer/query-account-coins-balance", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitAllAssetBalances>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Asset Balance

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSingleAssetBalance>> GetAssetBalanceAsync(
            AccountType accountType,
            string asset,
            string? memberId = null,
            bool? withBonus = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "accountType", EnumConverter.GetString(accountType) },
                { "coin", asset }
            };
            parameters.AddOptionalParameter("memberId", memberId);
            parameters.AddOptionalParameter("withBonus", withBonus == true ? "1" : "0");

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/transfer/query-account-coin-balance", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitSingleAssetBalance>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Transferable Assets

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<string>>> GetTransferableAssetsAsync(
            AccountType fromAccountType,
            AccountType toAccountType,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "fromAccountType", EnumConverter.GetString(fromAccountType) },
                { "toAccountType", EnumConverter.GetString(toAccountType) },
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/transfer/query-transfer-coin-list", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(60, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<string>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Create Internal transfer

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTransferId>> CreateInternalTransferAsync(
            string asset,
            decimal quantity,
            AccountType fromAccountType,
            AccountType toAccountType,
            string? transferId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "fromAccountType", EnumConverter.GetString(fromAccountType) },
                { "toAccountType", EnumConverter.GetString(toAccountType) },
                { "coin", asset },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "transferId", transferId ?? Guid.NewGuid().ToString() }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/asset/transfer/inter-transfer", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(60, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitTransferId>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Internal Transfers

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitTransfer>>> GetInternalTransfersAsync(
            string? transferId = null,
            string? asset = null,
            TransferStatus? transferStatus = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("transferId", transferId);
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("status", EnumConverter.GetString(transferStatus));
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/transfer/query-inter-transfer-list", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(60, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitTransfer>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Create Universal transfer

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTransferId>> CreateUniversalTransferAsync(
            string asset,
            decimal quantity,
            string fromMemberId,
            string toMemberId,
            AccountType fromAccountType,
            AccountType toAccountType,
            string? transferId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "fromAccountType", EnumConverter.GetString(fromAccountType) },
                { "toAccountType", EnumConverter.GetString(toAccountType) },
                { "coin", asset },
                { "fromMemberId", fromMemberId },
                { "toMemberId", toMemberId },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "transferId", transferId ?? Guid.NewGuid().ToString() }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/asset/transfer/universal-transfer", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitTransferId>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Universal Transfers

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitTransfer>>> GetUniversalTransfersAsync(
            string? transferId = null,
            string? asset = null,
            TransferStatus? transferStatus = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("transferId", transferId);
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("status", EnumConverter.GetString(transferStatus));
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/transfer/query-universal-transfer-list", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitTransfer>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Allowed Deposit Info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitAllowedDepositInfoResponse>> GetAllowedDepositAssetInfoAsync(
            string? asset = null,
            string? network = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("chain", network);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/deposit/query-allowed-list", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitAllowedDepositInfoResponse>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Deposit Account

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOperationResult>> SetDepositAccountAsync(
            AccountType accountType,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "accountType", EnumConverter.GetString(accountType) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/asset/deposit/deposit-to-account", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitOperationResult>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Deposits

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDeposits>> GetDepositsAsync(
            string? asset = null,
            string? id = null,
            string? transactionId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("id", id);
            parameters.AddOptionalParameter("txID", transactionId);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/deposit/query-record", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(100, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitDeposits>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Internal Deposits

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitInternalDeposit>>> GetInternalDepositsAsync(
            string? transactionId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("coin", asset);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);
            parameters.AddOptional("txID", transactionId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/deposit/query-internal-record", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitResponse<BybitInternalDeposit>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Deposit Address

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDepositAddress>> GetDepositAddressAsync(
            string asset,
            string? networkType = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "coin", asset }
            };
            parameters.AddOptionalParameter("chainType", networkType);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/deposit/query-address", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(300, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitDepositAddress>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Asset info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitUserAssetInfos>> GetAssetInfoAsync(
            string? asset = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("coin", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/coin/query-info", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(600, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitUserAssetInfos>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Withdrawals

        /// <inheritdoc />
        public async Task<WebCallResult<BybitResponse<BybitWithdrawal>>> GetWithdrawalsAsync(
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
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("withdrawID", withdrawId);
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("withdrawType", EnumConverter.GetString(type));
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("txID", transactionId);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/withdraw/query-record", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(100, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitResponse<BybitWithdrawal>>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Delayed Withdrawal Quantity

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDelayedWithdrawal>> GetDelayedWithdrawQuantityAsync(
            string asset,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "coin", asset }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/withdraw/withdrawable-amount", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitDelayedWithdrawal>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Withdraw

        /// <inheritdoc />
        public async Task<WebCallResult<BybitId>> WithdrawAsync(
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
            var parameters = new ParameterCollection()
            {
                { "coin", asset },
                { "chain", network },
                { "address", toAddress },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "timestamp", DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow) }
            };

            parameters.AddOptionalParameter("tag", tag);
            parameters.AddOptionalParameter("accountType", EnumConverter.GetString(accountType));
            parameters.AddOptionalParameter("forceChain", forceNetwork == null ? null : forceNetwork.Value ? 1 : 0);
            parameters.AddOptionalParameter("feeType", feeType == null ? null : feeType.Value ? 1 : 0);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/asset/withdraw/create", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitId>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Withdrawal

        /// <inheritdoc />
        public async Task<WebCallResult<BybitOperationResult>> CancelWithdrawalAsync(
            string id,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "id", id },
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/asset/withdraw/cancel", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(60, TimeSpan.FromMinutes(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitOperationResult>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Api Key Info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitApiKeyInfo>> GetApiKeyInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/user/query-api", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitApiKeyInfo>(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Edit Api Key

        /// <inheritdoc />
        public async Task<WebCallResult<BybitApiKeyInfo>> EditApiKeyAsync(
            bool? readOnly = null,
            string? ipRestrictions = null,
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
            var parameters = new ParameterCollection();
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
            AddPermission(permissions, permissionBlockTrading, "BlockTrade", "BlockTrade");
            AddPermission(permissions, permissionCopyTrading, "CopyTrading", "CopyTrading");
            AddPermission(permissions, permissionExchangeHistory, "Exchange", "ExchangeHistory");
            AddPermission(permissions, permissionNftProductList, "NFT", "NFTQueryProductList");
            AddPermission(permissions, permissionAffiliate, "Affiliate", "Affiliate");
            parameters.Add("permissions", permissions.ToDictionary(x => x.Key, x => x.Value.ToArray()));

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/user/update-api", BybitExchange.RateLimiter.BybitRest, 1, true,
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
        public async Task<WebCallResult> DeleteApiKeyAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/user/delete-api", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Account Types

        /// <inheritdoc />
        public async Task<WebCallResult<BybitAccountTypeInfo[]>> GetAccountTypesAsync(IEnumerable<string>? subAccountIds = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            if (subAccountIds != null)
                parameters.AddOptionalParameter("memberIds", string.Join(",", subAccountIds));

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/user/get-member-type", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitAccountTypeInfoWrapper>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result.As<BybitAccountTypeInfo[]>(default);

            return result.As(result.Data.Accounts);
        }

        #endregion

        #region Add Or Reduce Margin

        /// <inheritdoc />
        public async Task<WebCallResult<BybitPosition>> AddOrReduceMarginAsync(
            Category category,
            string symbol,
            decimal margin,
            PositionIdx? positionIdx = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "margin", margin.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.AddOptionalParameter("positionIdx", EnumConverter.GetString(positionIdx));

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/position/add-margin", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitPosition>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Spot Margin Leverage

        /// <inheritdoc />
        public async Task<WebCallResult> SetSpotMarginLeverageAsync(decimal leverage, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "leverage", leverage.ToString(CultureInfo.InvariantCulture) }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/spot-margin-trade/set-leverage", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Margin Status And Leverage

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotMarginLeverageStatus>> GetSpotMarginStatusAndLeverageAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/spot-margin-trade/state", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitSpotMarginLeverageStatus>(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Spot Margin Trade Mode

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotMarginStatus>> SetSpotMarginTradeModeAsync(bool spotMarginMode, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "spotMarginMode", spotMarginMode ? "1" : "0" }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/spot-margin-trade/switch-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitSpotMarginStatus>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Spot Margin Data

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotMarginVipMarginList[]>> GetSpotMarginDataAsync(string? asset = null, string? vipLevel = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("currency", asset);
            parameters.AddOptionalParameter("vipLevel", vipLevel);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/spot-margin-trade/data", BybitExchange.RateLimiter.BybitRest, 1, false);
            var result = await _baseClient.SendAsync<BybitSpotMarginVipMarginData>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result.As<BybitSpotMarginVipMarginList[]>(default);

            return result.As(result.Data.VipCoinList);
        }

        #endregion

        #region Get Spot Margin Interest Rate History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotMarginBorrowRate[]>> GetSpotMarginInterestRateHistoryAsync(string asset, string? vipLevel = null, DateTime? startTime = null, DateTime? endTime = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("currency", asset);
            parameters.AddOptional("vipLevel", vipLevel);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/spot-margin-trade/interest-rate-history", BybitExchange.RateLimiter.BybitRest, 1, true); 
            var result = await _baseClient.SendAsync<BybitResponse<BybitSpotMarginBorrowRate>>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BybitSpotMarginBorrowRate[]>(result.Data?.List);
        }

        #endregion

        #region Get Broker Account Info

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBrokerAccountInfo>> GetBrokerAccountInfoAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/broker/account-info", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitBrokerAccountInfo>(request, null, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Broker Earnings

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBrokerEarnings>> GetBrokerEarningsAsync(string? bizType = null, DateTime? startTime = null, DateTime? endTime = null, string? subAccountId = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("bizType", bizType);
            parameters.AddOptional("begin", startTime?.ToString("yyyyMMdd"));
            parameters.AddOptional("end", endTime?.ToString("yyyyMMdd"));
            parameters.AddOptional("uid", subAccountId);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("cursor", cursor);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/broker/earnings-info", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitBrokerEarnings>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Spot Hedging Mode

        /// <inheritdoc />
        public async Task<WebCallResult> SetSpotHedgingModeAsync(bool spotHedgingMode, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "setHedgingMode", spotHedgingMode ? "ON" : "OFF" }
            };

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/account/set-hedging-mode", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Repay Liabilities

        /// <inheritdoc />
        public async Task<WebCallResult<BybitLiabilityRepayment[]>> RepayLiabilitiesAsync(string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalParameter("coin", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/account/quick-repayment", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitList<BybitLiabilityRepayment>>(request, parameters, ct).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<BybitLiabilityRepayment[]>(default);

            if (result.Data.List == null)
                return result.As<BybitLiabilityRepayment[]>(Array.Empty<BybitLiabilityRepayment>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Request Demo Funds

        /// <inheritdoc />
        public async Task<WebCallResult> RequestDemoFundsAsync(Dictionary<string, decimal> funds, bool? addOrReduce = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("adjustType", addOrReduce == null ? null : addOrReduce == true ? 0 : 1);
            parameters.AddOptionalParameter("utaDemoApplyMoney", funds.Select(f => new BybitDemoFundsRequest { Asset = f.Key, Quantity = f.Value }).ToArray());

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/account/demo-apply-money", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Get Convert Assets

        /// <inheritdoc />
        public async Task<WebCallResult<BybitConvertAsset[]>> GetConvertAssetsAsync(ConvertAccountType accountType, string? asset = null, ConvertAssetSide? side = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection
            {
                { "accountType", EnumConverter.GetString(accountType) }
            };
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalEnum("side", side);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/exchange/query-coin-list", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitConvertAssetWrapper>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BybitConvertAsset[]>(result.Data?.Assets);
        }

        #endregion
        
        #region Get Convert Quote

        /// <inheritdoc />
        public async Task<WebCallResult<BybitConvertQuote>> GetConvertQuoteAsync(ConvertAccountType accountType, string fromAsset, string toAsset, decimal quantity, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("accountType", accountType);
            parameters.Add("fromCoin", fromAsset);
            parameters.Add("toCoin", toAsset);
            parameters.Add("requestCoin", fromAsset);
            parameters.AddString("requestAmount", quantity);
            parameters.AddOptional("requestId", clientOrderId);
            parameters.Add("paramType", "opFrom");
            parameters.Add("paramValue", _baseClient._referer);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/asset/exchange/quote-apply", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitConvertQuote>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Convert Confirm Quote

        /// <inheritdoc />
        public async Task<WebCallResult<BybitConvertTransactionResult>> ConvertConfirmQuoteAsync(string quoteTransactionId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("quoteTxId", quoteTransactionId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/asset/exchange/convert-execute", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync<BybitConvertTransactionResult>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Convert Confirm Quote

        /// <inheritdoc />
        public async Task<WebCallResult<BybitConvertTransaction>> GetConvertStatusAsync(ConvertAccountType accountType, string quoteTransactionId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("quoteTxId", quoteTransactionId);
            parameters.AddEnum("accountType", accountType);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/exchange/convert-result-query", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitConvertTransactionWrapper>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BybitConvertTransaction>(result.Data?.Result);
        }

        #endregion

        #region Get Convert History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitConvertTransaction[]>> GetConvertHistoryAsync(ConvertAccountType? accountType = null, int? page = null, int? pageSize = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalEnum("accountType", accountType);
            parameters.AddOptional("index", page);
            parameters.AddOptional("limit", pageSize);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/asset/exchange/query-convert-history", BybitExchange.RateLimiter.BybitRest, 1, true);
            var result = await _baseClient.SendAsync<BybitConvertTransactionListWrapper>(request, parameters, ct).ConfigureAwait(false);
            return result.As<BybitConvertTransaction[]>(result.Data?.List);
        }

        #endregion

        #region Get Transferable

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTransferable>> GetTransferableAsync(string asset, CancellationToken ct = default)
            => await GetTransferableAsync([asset], ct).ConfigureAwait(false);

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTransferable>> GetTransferableAsync(IEnumerable<string> assets, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("coinName", string.Join(",", assets));

            var request = _definitions.GetOrCreate(HttpMethod.Get, "v5/account/withdrawal", BybitExchange.RateLimiter.BybitRest, 1, true,
                new SingleLimitGuard(50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, null, SingleLimitGuard.PerApiKey));
            return await _baseClient.SendAsync<BybitTransferable>(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

        #region Set Price Limit Behavior

        /// <inheritdoc />
        public async Task<WebCallResult> SetPriceLimitBehaviorAsync(Category category, bool allowModifyPrice, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("category", category);
            parameters.Add("modifyEnable", allowModifyPrice);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "v5/account/set-limit-px-action", BybitExchange.RateLimiter.BybitRest, 1, true);
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        #endregion

    }
}
