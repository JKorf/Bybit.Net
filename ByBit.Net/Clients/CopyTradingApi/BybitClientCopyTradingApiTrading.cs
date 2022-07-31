using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.CopyTradingApi;
using Bybit.Net.Objects.Models.CopyTrading;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.CopyTradingApi
{
    /// <inheritdoc />
    public class BybitClientCopyTradingApiTrading : IBybitClientCopyTradingApiTrading
    {
        private BybitClientCopyTradingApi _baseClient;

        internal BybitClientCopyTradingApiTrading(BybitClientCopyTradingApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Positions

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitCopyTradingPosition>>> GetPositionsAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            return await _baseClient.SendRequestListAsync<BybitCopyTradingPosition>(_baseClient.GetUrl("contract/v3/private/copytrading/position/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Close Position

        /// <inheritdoc />
        public async Task<WebCallResult> ClosePositionAsync(string symbol, PositionMode positionMode, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "positionIdx", JsonConvert.SerializeObject(positionMode, new PositionModeConverter(false)) }
            };
            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/copytrading/position/close"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Close Position

        /// <inheritdoc />
        public async Task<WebCallResult> SetLeverageAsync(string symbol, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "buyLeverage", buyLeverage.ToString(CultureInfo.InvariantCulture) },
                { "sellLeverage", sellLeverage.ToString(CultureInfo.InvariantCulture) }
            };
            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("contract/v3/private/copytrading/position/set-leverage"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }

        #endregion

        #region Place Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCopyTradingId>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal price, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "orderType", JsonConvert.SerializeObject(type, new OrderSideConverter(false)) },
                { "side", JsonConvert.SerializeObject(side, new OrderTypeConverter(false)) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) },
                { "price", price.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            return await _baseClient.SendRequestAsync<BybitCopyTradingId>(_baseClient.GetUrl("contract/v3/private/copytrading/order/create"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get Orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitCopyTradingOrder>>> GetOrdersAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, string? copyTradeOrderType = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("copyTradeOrderType", copyTradeOrderType);
            return await _baseClient.SendRequestListAsync<BybitCopyTradingOrder>(_baseClient.GetUrl("contract/v3/private/copytrading/order/list"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Cancel Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCopyTradingId>> CancelOrderAsync(string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            if ((orderId == null && clientOrderId == null) || (orderId != null && clientOrderId != null))
                throw new ArgumentException("Either orderId or clientOrderId should be provided");

            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            return await _baseClient.SendRequestAsync<BybitCopyTradingId>(_baseClient.GetUrl("contract/v3/private/copytrading/order/cancel"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Close Order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitCopyTradingId>> CloseOrderAsync(string symbol, string? clientOrderId = null, string? parentOrderId = null, string? parentClientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("parentOrderId", parentOrderId);
            parameters.AddOptionalParameter("parentOrderLinkId", parentClientOrderId);
            return await _baseClient.SendRequestAsync<BybitCopyTradingId>(_baseClient.GetUrl("contract/v3/private/copytrading/order/close"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
