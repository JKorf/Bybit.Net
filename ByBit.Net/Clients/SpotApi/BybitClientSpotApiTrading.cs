using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.SpotApi;
using Bybit.Net.Objects.Models.Spot;
using CryptoExchange.Net;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.SpotApi
{
    /// <inheritdoc />
    public class BybitClientSpotApiTrading : IBybitClientSpotApiTrading
    {
        private readonly BybitClientSpotApi _baseClient;

        internal BybitClientSpotApiTrading(BybitClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Place order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotOrderPlaced>> PlaceOrderAsync(string symbol, Enums.OrderSide side, Enums.OrderType type, decimal quantity, decimal? price = null, TimeInForce? timeInForce = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "type", JsonConvert.SerializeObject(type, new OrderTypeSpotConverter(false)) },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) }
            };
            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("timeInForce", timeInForce == null ? null : JsonConvert.SerializeObject(timeInForce, new TimeInForceSpotConverter(false)));
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitSpotOrderPlaced>(_baseClient.GetUrl("spot/v1/order"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (result)
                _baseClient.InvokeOrderPlaced(new OrderId { SourceObject = result.Data, Id = result.Data.Id.ToString(CultureInfo.InvariantCulture) });
            return result;
        }

        #endregion

        #region Get order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotOrder>> GetOrderAsync(long? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitSpotOrder>(_baseClient.GetUrl("spot/v1/order"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get open orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotOrder>>> GetOpenOrdersAsync(string? symbol = null, long? orderId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotOrder>>(_baseClient.GetUrl("spot/v1/open-orders"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get open orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotOrder>>> GetOrdersAsync(string? symbol = null, long? orderId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotOrder>>(_baseClient.GetUrl("spot/v1/history-orders"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Cancel order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotOrderPlaced>> CancelOrderAsync(long? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitSpotOrderPlaced>(_baseClient.GetUrl("spot/v1/order"), HttpMethod.Delete, ct, parameters, true).ConfigureAwait(false);
            if (result)
                _baseClient.InvokeOrderCanceled(new OrderId { SourceObject = result.Data, Id = result.Data.Id.ToString(CultureInfo.InvariantCulture) });
            return result;
        }

        #endregion

        #region Get user trades

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotUserTrade>>> GetUserTradesAsync(string? symbol = null, long? fromId = null, long? toId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("fromId", fromId);
            parameters.AddOptionalParameter("toId", toId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotUserTrade>>(_baseClient.GetUrl("spot/v1/myTrades"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion
    }
}
