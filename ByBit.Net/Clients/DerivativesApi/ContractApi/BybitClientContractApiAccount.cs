using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.DerivativesApi.ContractApi;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.Derivatives.Contract;
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

namespace Bybit.Net.Clients.DerivativesApi.ContractApi
{
    /// <inheritdoc />
    public class BybitClientUnifiedMarginApiAccount : IBybitClientContractApiAccount
    {
        private readonly BybitClientDerivativesApi _baseClient;

        internal BybitClientUnifiedMarginApiAccount(BybitClientDerivativesApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region GetBalancesAsync

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitContractBalance>>> GetBalancesAsync(string? asset = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitContractBalance>>(_baseClient.GetUrl("contract/v3/private/account/wallet/balance"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitContractBalance>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitContractBalance>>(Array.Empty<BybitContractBalance>());

            return result.As(result.Data.List);
        }

        #endregion

        #region GetPositionAsync

        /// <inheritdoc />
        public async Task<WebCallResult<BybitDerivativesCursorPage<IEnumerable<BybitContractPosition>>>> GetPositionAsync(string? symbol = null, string? settleAsset = null, SettleDataFilter? dataFilter = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            if ((symbol == null && settleAsset == null) || (symbol != null && settleAsset != null))
                throw new ArgumentException("Either symbol or settleAsset should be provided");

            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("settleCoin", settleAsset);
            parameters.AddOptionalParameter("direction", EnumConverter.GetString(dataFilter));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitDerivativesCursorPage<IEnumerable<BybitContractPosition>>>(_baseClient.GetUrl("contract/v3/private/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region GetProfitAndLossHistoryAsync

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractClosedPnlEntry>>>> GetProfitAndLossHistoryAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToSeconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToSeconds(endTime));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitContractClosedPnlEntry>>>(_baseClient.GetUrl("contract/v3/private/position/closed-pnl"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region GetTradingFeeRate

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitContractTradingFeeRate>>> GetTradingFeeRate(string? symbol = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitContractTradingFeeRate>>(_baseClient.GetUrl("/contract/v3/private/account/fee-rate"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitContractTradingFeeRate>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitContractTradingFeeRate>>(Array.Empty<BybitContractTradingFeeRate>());

            return result.As(result.Data.List);
        }

        #endregion

        #region GetUserTradesAsync

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractUserTrade>>>> GetUserTradesAsync(string symbol, string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, TradeType? tradeType = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };

            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToSeconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToSeconds(endTime));
            parameters.AddOptionalParameter("execType", tradeType == null ? null : JsonConvert.SerializeObject(tradeType, new TradeTypeConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitContractUserTrade>>>(_baseClient.GetUrl("contract/v3/private/execution/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region GetWalletFundRecords

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCursorPage<IEnumerable<BybitContractWalletFundRecord>>>> GetWalletFundRecords(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WalletFundType? fundType = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToSeconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToSeconds(endTime));
            parameters.AddOptionalParameter("execType", fundType == null ? null : JsonConvert.SerializeObject(fundType, new WalletFundTypeConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("cursor", cursor);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitCursorPage<IEnumerable<BybitContractWalletFundRecord>>>(_baseClient.GetUrl("/contract/v3/private/account/wallet/fund-records"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region SetAutoAddMarginAsync

        /// <inheritdoc />
        public async Task<WebCallResult> SetAutoAddMarginAsync(string symbol, OrderSide side, bool autoAddMargin, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "autoAddMargin", autoAddMargin ? 1 : 0 },
            };

            parameters.AddOptionalParameter("positionIdx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/position/set-auto-add-margin"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region SetFullPartialPositionModeAsync

        /// <inheritdoc />
        public async Task<WebCallResult> SetFullPartialPositionModeAsync(string symbol, StopLossTakeProfitMode mode, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "tpSlMode", JsonConvert.SerializeObject(mode, new StopLossTakeProfitModeConverter(false)) },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("/contract/v3/private/position/switch-tpsl-mode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region SetLeverageAsync

        /// <inheritdoc />
        public async Task<WebCallResult> SetLeverageAsync(string symbol, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "buyLeverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sellLeverage", sellLeverage.ToString(CultureInfo.InvariantCulture)},
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/position/set-leverage"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region SetMarginMode

        /// <inheritdoc />
        public async Task<WebCallResult> SetMarginMode(MarginMode marginMode, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "setMarginMode", EnumConverter.GetString(marginMode) }
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/account/setMarginMode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region SetPositionModeAsync

        /// <inheritdoc />
        public async Task<WebCallResult> SetPositionModeAsync(PositionMode hedgeMode, string? symbol = null, string? asset = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "mode",  hedgeMode == PositionMode.OneWay ? "0" : "3" }
            };

            if (symbol == null && asset == null || symbol != null && asset != null)
                throw new ArgumentException($"1 of {nameof(symbol)} or {nameof(asset)} should be provided");

            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("asset", asset);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/position/switch-mode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region SetRiskLimitAsync

        /// <inheritdoc />
        public async Task<WebCallResult> SetRiskLimitAsync(string symbol, long riskId, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "riskId", riskId.ToString(CultureInfo.InvariantCulture) }
            };

            parameters.AddOptionalParameter("positionIdx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("/contract/v3/private/position/set-risk-limit"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region SetTradeModeAsync

        /// <inheritdoc />
        public async Task<WebCallResult> SetTradeModeAsync(string symbol, TradeMode tradeMode, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "tradeMode", EnumConverter.GetString(tradeMode) },
                { "buyLeverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sellLeverage", sellLeverage.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/position/switch-isolated"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion
    }
}
