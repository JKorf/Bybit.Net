using Bybit.Net.Converters;
using Bybit.Net.Enums;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Spot system endpoints
    /// </summary>
    public class BybitClientUsdFuturesAccount : BybitClientFuturesBaseAccount, IBybitClientFuturesAccount
    //: IBybitInversePerpetualClientAccount
    {
        internal BybitClientUsdFuturesAccount(BybitClientUsdFutures baseClient) : base(baseClient)
        {
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

        #region Get last funding rate

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
        public async Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, long riskId, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "risk_id", riskId.ToString(CultureInfo.InvariantCulture) },
            };
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
        public async Task<WebCallResult> SetAutoAddMarginAsync(string symbol, OrderSide side, bool autoAddMargin, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "auto_add_margin", autoAddMargin.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("private/linear/position/set-auto-add-margin"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return new WebCallResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);
        }

        #endregion

        #region Add / Reduce margin

        /// <inheritdoc />
        public async Task<WebCallResult<BybitMarginResult>> AddReduceMarginAsync(string symbol, OrderSide side, decimal margin, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "margin", margin.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitMarginResult>(_baseClient.GetUrl("private/linear/position/add-margin"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set leverage

        /// <inheritdoc />
        public async Task<WebCallResult> SetLeverageAsync(string symbol, int buyLeverage, int sellLeverage, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "buy_leverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sell_leverage", sellLeverage.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("private/linear/position/set-leverage"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return new WebCallResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);
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
            parameters.AddOptionalParameter("start_time",  DateTimeConverter.ConvertToSeconds(startTime));
            parameters.AddOptionalParameter("end_time",  DateTimeConverter.ConvertToSeconds(endTime));
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

            return await _baseClient.SendRequestAsync<BybitTpSlMode>(_baseClient.GetUrl("v2/private/tpsl/switch-mode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set position mode

        /// <inheritdoc />
        public async Task<WebCallResult> SetPositionModeAsync(string symbol, bool isIsolated, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default)
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
            return new WebCallResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);
        }

        #endregion
    }
}
