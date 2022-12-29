using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.DerivativesApi.UnifiedMarginApi;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.Derivatives.UnifiedMargin;
using Bybit.Net.Objects.Models.UnifiedMargin;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.DerivativesApi.UnifiedMarginApi
{
    /// <inheritdoc />
    public class BybitClientUnifiedMarginApiAccount : IBybitClientUnifiedMarginApiAccount
    {
        private readonly BybitClientDerivativesApi _baseClient;

        internal BybitClientUnifiedMarginApiAccount(BybitClientDerivativesApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region UMA enabled

        /// <inheritdoc />
        public async Task<WebCallResult<bool>> IsUMAEnabled()
        {
            var result = await GetWalletBalance().ConfigureAwait(false);

            return result.As(result.Error == null || result.Error.Code != 10020);
        }

        #endregion

        #region Get wallet balance

        /// <inheritdoc />
        public async Task<WebCallResult<BybitUnifiedMarginBalance>> GetWalletBalance(string? asset = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitUnifiedMarginBalance>(_baseClient.GetUrl("unified/v3/private/account/wallet/balance"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Exchange coins

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitUnifiedMarginCoinExchangeResult>>> ExchangeCoinsAsync(string? fromCoin = null, string? toCoin = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("fromCoin", fromCoin);
            parameters.AddOptionalParameter("toCoin", toCoin);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitUnifiedMarginCoinExchangeResult>>(_baseClient.GetUrl("asset/v2/private/exchange/exchange-order-all"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitUnifiedMarginCoinExchangeResult>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitUnifiedMarginCoinExchangeResult>>(Array.Empty<BybitUnifiedMarginCoinExchangeResult>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get borrow history

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitUnifiedMarginBorrowRecord>>>> GetBorrowHistoryAsync(string? asset, DateTime? startTime, DateTime? endTime, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("currency", asset);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitUnifiedMarginBorrowRecord>>>(_baseClient.GetUrl("unified/v3/private/account/borrow-history"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get borrow rate

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitUnifiedMarginBorrowRate>>> GetBorrowRateAsync(string? asset = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("asset", asset);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitUnifiedMarginBorrowRate>>(_baseClient.GetUrl("unified/v3/private/account/borrow-history"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitUnifiedMarginBorrowRate>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitUnifiedMarginBorrowRate>>(Array.Empty<BybitUnifiedMarginBorrowRate>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get position async

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginPosition>>>> GetPositionAsync(Category category, string? symbol, string? baseAsset, SearchDirection? direction, int? limit, string? cursor, long? receiveWindow, CancellationToken ct)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginPosition>>>(_baseClient.GetUrl("unified/v3/private/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get transaction log

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginTransactionLog>>>> GetTransactionLogAsync(Category category, string asset, string? baseAsset, DateTime? startTime, DateTime? endTime, SearchDirection? direction, int? limit, string? cursor, long? receiveWindow, CancellationToken ct)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "currency", asset },
            };

            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endtime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginTransactionLog>>>(_baseClient.GetUrl("unified/v3/private/account/transaction-log"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set full part partial position mode async

        /// <inheritdoc />
        public async Task<WebCallResult> SetFullPartialPositionModeAsync(Category category, string symbol, StopLossTakeProfitMode mode, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "tpSlMode", JsonConvert.SerializeObject(mode, new StopLossTakeProfitModeConverter(false)) },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("unified/v3/private/position/tpsl/switch-mode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Set leverage

        /// <inheritdoc />
        public async Task<WebCallResult> SetLeverageAsync(Category category, string symbol, decimal buyLeverage, decimal cellLeverage, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "buyLeverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "cellLeverage", cellLeverage.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("unified/v3/private/position/set-leverage"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Set risk limit

        /// <inheritdoc />
        public async Task<WebCallResult> SetRiskLimitAsync(Category category, string symbol, long riskId, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol },
                { "riskId", riskId.ToString(CultureInfo.InvariantCulture) }
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("unified/v3/private/position/set-risk-limit"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Set stop loss/take profit

        /// <inheritdoc />
        public async Task<WebCallResult> SetSlTpAsync(Category category, string symbol, decimal? takeProfit = null, decimal? stopLoss = null, decimal? trailingStop = null, TriggerType? tpTriggerBy = null, TriggerType? slTriggerBy = null, decimal? activePrice = null, decimal? slSize = null, decimal? tpSize = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
                { "symbol", symbol }
            };

            parameters.AddOptionalParameter("takeProfit", takeProfit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("stopLoss", stopLoss?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("trailingStop", trailingStop?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpTriggerBy", tpTriggerBy == null ? null : JsonConvert.SerializeObject(tpTriggerBy, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("slTriggerBy", slTriggerBy == null ? null : JsonConvert.SerializeObject(slTriggerBy, new TriggerTypeConverter(false)));
            parameters.AddOptionalParameter("activePrice", activePrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("slSize", slSize?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("tpSize", tpSize?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("unified/v3/private/position/trading-stop"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Transfer funds between account

        /// <inheritdoc />
        public async Task<WebCallResult<BybitUnifiedMarginTransferInfo>> TransferFundsAsync(string transferId, decimal amount, string currency, AccountType fromAccountType, AccountType toAccountType, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "transferId", transferId },
                { "amount", amount.ToString(CultureInfo.InvariantCulture) },
                { "coin", currency.ToString(CultureInfo.InvariantCulture) },
                { "from_account_type", EnumConverter.GetString(fromAccountType) },
                { "to_account_type", EnumConverter.GetString(toAccountType) },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitUnifiedMarginTransferInfo>(_baseClient.GetUrl("asset/v1/private/transfer"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get profit and loss history

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginPnlEntry>>>> GetProfitAndLossHistoryAsync(Category category, string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, OrderFilter? orderFilter = null, DateTime? startTime = null, DateTime? endTime = null, TradeType? type = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "category", EnumConverter.GetString(category) },
            };

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("baseCoin", baseAsset);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderFilter", EnumConverter.GetString(orderFilter));
            parameters.AddOptionalParameter("execType", EnumConverter.GetString(type));
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endtime", DateTimeConverter.ConvertToMilliseconds(endTime));

            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesCursorPage<IEnumerable<BybitUnifiedMarginPnlEntry>>>(_baseClient.GetUrl("/unified/v3/private/execution/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
