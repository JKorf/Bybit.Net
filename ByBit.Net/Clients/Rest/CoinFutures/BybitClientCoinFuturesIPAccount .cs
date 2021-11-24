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
    public class BybitClientCoinFuturesIPAccount : BybitClientFuturesBaseAccount, IBybitClientFuturesAccount
    //: IBybitInversePerpetualClientAccount
    {
        internal BybitClientCoinFuturesIPAccount(BybitClientCoinFutures baseClient) : base(baseClient)
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

            return await _baseClient.SendRequestAsync<BybitFundingSettlement>(_baseClient.GetUrl("v2/private/funding/prev-funding"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
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

            return await _baseClient.SendRequestAsync<BybitPredictedFunding>(_baseClient.GetUrl("v2/private/funding/predicted-funding"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get risk limit

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync(string? symbol = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitRiskLimit>>(_baseClient.GetUrl("v2/public/risk-limit/list"), HttpMethod.Get, ct, parameters).ConfigureAwait(false);
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

            return await _baseClient.SendRequestAsync<BybitRiskId>(_baseClient.GetUrl("v2/private/position/risk-limit"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get position

        /// <inheritdoc />
        public async Task<WebCallResult<BybitPosition>> GetPositionAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitPosition>(_baseClient.GetUrl("v2/private/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get positions

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitPosition>>> GetPositionsAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

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
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<decimal>(_baseClient.GetUrl("v2/private/position/change-position-margin"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set leverage

        /// <inheritdoc />
        public async Task<WebCallResult<int>> SetLeverageAsync(string symbol, int leverage, bool? leverageOnly = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "leverage", leverage.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("leverage_only", leverageOnly?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<int>(_baseClient.GetUrl("v2/private/position/leverage/save"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
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
            parameters.AddOptionalParameter("start_time", startTime == null ? null : JsonConvert.SerializeObject(startTime.Value, new TimestampSecondsConverter()));
            parameters.AddOptionalParameter("end_time", endTime == null ? null : JsonConvert.SerializeObject(endTime.Value, new TimestampSecondsConverter()));
            parameters.AddOptionalParameter("exec_type", type == null ? null : JsonConvert.SerializeObject(type.Value, new TradeTypeConverter(false)));
            parameters.AddOptionalParameter("page", page?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("limit", pageSize?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

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
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitTpSlMode>(_baseClient.GetUrl("private/linear/tpsl/switch-mode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set isolated mode

        /// <inheritdoc />
        public async Task<WebCallResult> SetIsolatedModeAsync(string symbol, bool isIsolated, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "is_isolated", isIsolated.ToString() },
                { "buy_leverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sell_leverage", sellLeverage.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("v2/private/position/switch-isolated"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return new WebCallResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);
        }

        #endregion
    }
}
