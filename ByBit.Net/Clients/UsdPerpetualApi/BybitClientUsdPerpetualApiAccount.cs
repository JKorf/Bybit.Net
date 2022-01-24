using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.UsdPerpetualApi;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.UsdPerpetualApi
{
    /// <inheritdoc />
    public class BybitClientUsdPerpetualApiAccount : IBybitClientUsdPerpetualApiAccount
    {
        private BybitClientUsdPerpetualApi _baseClient;
        private BybitClient _baseBaseClient;

        internal BybitClientUsdPerpetualApiAccount(BybitClient baseBaseClient, BybitClientUsdPerpetualApi baseClient)
        {
            _baseClient = baseClient;
            _baseBaseClient = baseBaseClient;
        }

        #region Get last funding rate

        /// <inheritdoc />
        public async Task<WebCallResult<BybitFundingSettlement>> GetUserLastFundingFeeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitFundingSettlement>(_baseClient.GetUrl("private/linear/funding/prev-funding"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get predicted funding rate

        /// <inheritdoc />
        public async Task<WebCallResult<BybitPredictedFunding>> GetUserPredictedFundingRateAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitPredictedFunding>(_baseClient.GetUrl("private/linear/funding/predicted-funding"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get risk limit

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitRiskLimit>>(_baseClient.GetUrl("public/linear/risk-limit"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set risk limit

        /// <inheritdoc />
        public async Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, OrderSide side, long riskId, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "risk_id", riskId.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("position_idx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitRiskId>(_baseClient.GetUrl("private/linear/position/set-risk"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get position

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitPositionUsd>>> GetPositionAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitPositionUsd>>(_baseClient.GetUrl("private/linear/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get positions

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitPositionUsd>>> GetPositionsAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<IEnumerable<BybitPositionUsdData>>(_baseClient.GetUrl("private/linear/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitPositionUsd>>(default);

            foreach (var position in result.Data)
                position.Data.IsValid = position.IsValid;

            return result.As(result.Data.Select(d => d.Data));
        }

        #endregion

        #region Set auto add margin

        /// <inheritdoc />
        public async Task<WebCallResult> SetAutoAddMarginAsync(string symbol, OrderSide side, bool autoAddMargin, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "auto_add_margin", autoAddMargin.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("position_idx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("private/linear/position/set-auto-add-margin"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Add / Reduce margin

        /// <inheritdoc />
        public async Task<WebCallResult<BybitMarginResult>> AddReduceMarginAsync(string symbol, OrderSide side, decimal margin, PositionMode? positionMode = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "margin", margin.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("position_idx", positionMode == null ? null : JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitMarginResult>(_baseClient.GetUrl("private/linear/position/add-margin"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set leverage

        /// <inheritdoc />
        public async Task<WebCallResult> SetLeverageAsync(string symbol, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "buy_leverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sell_leverage", sellLeverage.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("private/linear/position/set-leverage"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Get Profit And Loss History

        /// <inheritdoc />
        public async Task<WebCallResult<BybitPage<IEnumerable<BybitPnlEntry>>>> GetProfitAndLossHistoryAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, TradeType? type = null, int? page = null, int? pageSize = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
            };
            parameters.AddOptionalParameter("start_time", DateTimeConverter.ConvertToSeconds(startTime));
            parameters.AddOptionalParameter("end_time", DateTimeConverter.ConvertToSeconds(endTime));
            parameters.AddOptionalParameter("exec_type", type == null ? null : JsonConvert.SerializeObject(type.Value, new TradeTypeConverter(false)));
            parameters.AddOptionalParameter("page", page?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("limit", pageSize?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitPage<IEnumerable<BybitPnlEntry>>>(_baseClient.GetUrl("private/linear/trade/closed-pnl/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

            if (result && result.Data.Data == null)
                result.Data.Data = new BybitPnlEntry[0];

            return result;
        }

        #endregion

        #region Set full / partial position mode

        /// <inheritdoc />
        public async Task<WebCallResult<BybitTpSlMode>> SetFullPartialPositionModeAsync(string symbol, StopLossTakeProfitMode mode, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "tp_sl_mode", JsonConvert.SerializeObject(mode, new StopLossTakeProfitModeConverter(false)) },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitTpSlMode>(_baseClient.GetUrl("private/linear/tpsl/switch-mode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set Position Mode Switch

        /// <inheritdoc />
        public async Task<WebCallResult> SetPositionModeAsync(string symbol, bool hedgeMode, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "mode", hedgeMode ? "BothSide": "MergedSingle" },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("private/linear/position/switch-mode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Set position mode

        /// <inheritdoc />
        public async Task<WebCallResult> SetIsolatedPositionModeAsync(string symbol, bool isIsolated, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "is_isolated", isIsolated.ToString() },
                { "buy_leverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sell_leverage", sellLeverage.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("private/linear/position/switch-isolated"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Get balances

        /// <inheritdoc />
        public Task<WebCallResult<Dictionary<string, BybitBalance>>> GetBalancesAsync(string? asset = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            return _baseBaseClient.InversePerpetualApi.Account.GetBalancesAsync();
        }

        #endregion

        #region Get wallet fund history

        /// <inheritdoc />
        public Task<WebCallResult<IEnumerable<BybitWalletFundRecord>>> GetWalletFundHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WalletFundType? type = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            return _baseBaseClient.InversePerpetualApi.Account.GetWalletFundHistoryAsync();
        }

        #endregion

        #region Get withdrawal history

        /// <inheritdoc />
        public Task<WebCallResult<IEnumerable<BybitWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WithdrawStatus? status = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            return _baseBaseClient.InversePerpetualApi.Account.GetWithdrawalHistoryAsync();
        }

        #endregion

        #region Get asset exchange history

        /// <inheritdoc />
        public Task<WebCallResult<IEnumerable<BybitExchangeHistoryEntry>>> GetAssetExchangeHistoryAsync(long? fromId = null, SearchDirection? direction = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            return _baseBaseClient.InversePerpetualApi.Account.GetAssetExchangeHistoryAsync();
        }

        #endregion

        #region Get api key info

        /// <inheritdoc />
        public Task<WebCallResult<IEnumerable<ByBitApiKeyInfo>>> GetApiKeyInfoAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            return _baseBaseClient.InversePerpetualApi.Account.GetApiKeyInfoAsync();
        }

        #endregion
    }
}
