using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.InversePerpetualApi;
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

namespace Bybit.Net.Clients.InversePerpetualApi
{
    /// <inheritdoc />
    public class BybitClientInversePerpetualApiAccount : IBybitClientInversePerpetualApiAccount
    {
        private BybitClientInversePerpetualApi _baseClient;

        internal BybitClientInversePerpetualApiAccount(BybitClientInversePerpetualApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get risk limit

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync(string? symbol = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitRiskLimit>>(_baseClient.GetUrl("v2/public/risk-limit/list"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Set risk limit

        /// <inheritdoc />
        public async Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, long riskId, PositionMode? mode = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "risk_id", riskId.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("position_idx", mode == null ? null : JsonConvert.SerializeObject(mode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitRiskId>(_baseClient.GetUrl("v2/private/position/risk-limit"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get positions
        /// <inheritdoc />
        public async Task<WebCallResult<BybitPosition>> GetPositionAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitPosition>(_baseClient.GetUrl("v2/private/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitPosition>>> GetPositionsAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<IEnumerable<BybitPositionData>>(_baseClient.GetUrl("v2/private/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitPosition>>(default);

            foreach (var position in result.Data)
                position.Data.IsValid = position.IsValid;

            return result.As(result.Data.Select(d => d.Data));
        }

        #endregion

        #region Change margin

        /// <inheritdoc />
        public async Task<WebCallResult<decimal>> ChangeMarginAsync(string symbol, decimal margin, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "margin", margin.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<decimal>(_baseClient.GetUrl("v2/private/position/change-position-margin"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set leverage

        /// <inheritdoc />
        public async Task<WebCallResult<int?>> SetLeverageAsync(string symbol, decimal leverage, bool? leverageOnly = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "leverage", leverage.ToString(CultureInfo.InvariantCulture) }
            };
            parameters.AddOptionalParameter("leverage_only", leverageOnly);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<int?>(_baseClient.GetUrl("v2/private/position/leverage/save"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
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
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitPage<IEnumerable<BybitPnlEntry>>>(_baseClient.GetUrl("v2/private/trade/closed-pnl/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

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
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitTpSlMode>(_baseClient.GetUrl("v2/private/tpsl/switch-mode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set isolated mode

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
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("v2/private/position/switch-isolated"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Get balances

        /// <inheritdoc />
        public async Task<WebCallResult<Dictionary<string, BybitBalance>>> GetBalancesAsync(string? asset = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<Dictionary<string, BybitBalance>>(_baseClient.GetUrl("v2/private/wallet/balance"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get last user funding fee

        /// <inheritdoc />
        public async Task<WebCallResult<BybitFundingSettlement>> GetLastUserFundingFeeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitFundingSettlement>(_baseClient.GetUrl("v2/private/funding/prev-funding"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get predicted user funding fee

        /// <inheritdoc />
        public async Task<WebCallResult<BybitPredictedFunding>> GetPredictedUserFundingFeeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitPredictedFunding>(_baseClient.GetUrl("v2/private/funding/predicted-funding"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get wallet fund history

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitWalletFundRecord>>> GetWalletFundHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WalletFundType? type = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("start_date", startTime?.ToString("yyyy-MM-dd"));
            parameters.AddOptionalParameter("end_date", endTime?.ToString("yyyy-MM-dd"));
            parameters.AddOptionalParameter("wallet_fund_type", type == null ? null : JsonConvert.SerializeObject(type, new WalletFundTypeConverter(false)));
            parameters.AddOptionalParameter("page", page?.ToString());
            parameters.AddOptionalParameter("limit", pageSize?.ToString());
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitData<IEnumerable<BybitWalletFundRecord>>>(_baseClient.GetUrl("v2/private/wallet/fund/records"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitWalletFundRecord>>(default);

            if (result.Data.Data == null)
                return result.As<IEnumerable<BybitWalletFundRecord>>(new BybitWalletFundRecord[0]);

            return result.As(result.Data.Data);
        }

        #endregion

        #region Get withdrawal history

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WithdrawStatus? status = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("start_date", startTime?.ToString("yyyy-MM-dd"));
            parameters.AddOptionalParameter("end_date", endTime?.ToString("yyyy-MM-dd"));
            parameters.AddOptionalParameter("status", status == null ? null : JsonConvert.SerializeObject(status, new WithdrawStatusConverter(false)));
            parameters.AddOptionalParameter("page", page?.ToString());
            parameters.AddOptionalParameter("limit", pageSize?.ToString());
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitData<IEnumerable<BybitWithdrawal>>>(_baseClient.GetUrl("v2/private/wallet/withdraw/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitWithdrawal>>(default);

            if (result.Data.Data == null)
                return result.As<IEnumerable<BybitWithdrawal>>(new BybitWithdrawal[0]);

            return result.As(result.Data.Data);
        }

        #endregion

        #region Get asset exchange history

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitExchangeHistoryEntry>>> GetAssetExchangeHistoryAsync(long? fromId = null, SearchDirection? direction = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("from", fromId?.ToString());
            parameters.AddOptionalParameter("direction", direction == null ? null : JsonConvert.SerializeObject(direction, new SearchDirectionConverter(false)));
            parameters.AddOptionalParameter("limit", limit?.ToString());
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitExchangeHistoryEntry>>(_baseClient.GetUrl("v2/private/exchange-order/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get api key info

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<ByBitApiKeyInfo>>> GetApiKeyInfoAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("recv_window", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<ByBitApiKeyInfo>>(_baseClient.GetUrl("v2/private/account/api-key"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
