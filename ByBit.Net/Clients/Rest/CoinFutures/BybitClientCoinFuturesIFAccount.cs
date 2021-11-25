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
    public class BybitClientCoinFuturesIFAccount : BybitClientFuturesBaseAccount
    //: IBybitInversePerpetualClientAccount
    {
        internal BybitClientCoinFuturesIFAccount(BybitClientCoinFutures baseClient) : base(baseClient)
        {
        }

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
        public async Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, long riskId, PositionMode? mode = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "risk_id", riskId.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("position_idx", mode == null ? null: JsonConvert.SerializeObject(mode, new PositionModeConverter(false)));
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitRiskId>(_baseClient.GetUrl("futures/private/position/risk-limit"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get positions

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitPosition>>> GetPositionsAsync(string? symbol = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<IEnumerable<BybitPositionData>>(_baseClient.GetUrl("futures/private/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitPosition>>(default);

            foreach (var position in result.Data)
                position.Data.IsValid = position.IsValid;

            return result.As(result.Data.Select(d => d.Data));
        }

        #endregion

        #region Change margin

        /// <inheritdoc />
        public async Task<WebCallResult<decimal>> ChangeMarginAsync(string symbol, PositionMode mode, decimal margin, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "position_idx", JsonConvert.SerializeObject(mode, new PositionModeConverter(false)) },
                { "margin", margin.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<decimal>(_baseClient.GetUrl("futures/private/position/change-position-margin"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set leverage

        /// <inheritdoc />
        public async Task<WebCallResult<int>> SetLeverageAsync(string symbol, int buyLeverage, int sellLeverage, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "buy_leverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sell_leverage", sellLeverage.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<int>(_baseClient.GetUrl("futures/private/position/leverage/save"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
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

            var result = await _baseClient.SendRequestAsync<BybitPage<IEnumerable<BybitPnlEntry>>>(_baseClient.GetUrl("futures/private/trade/closed-pnl/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

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

            return await _baseClient.SendRequestAsync<BybitTpSlMode>(_baseClient.GetUrl("futures/private/tpsl/switch-mode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Set position mode

        /// <inheritdoc />
        public async Task<WebCallResult> SetPositionModeAsync(string symbol, bool hedgeMode, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "mode", hedgeMode ? 3: 0 },
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("futures/private/position/switch-mode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return new WebCallResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);
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

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("futures/private/position/switch-isolated"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return new WebCallResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error);
        }

        #endregion
    }
}
