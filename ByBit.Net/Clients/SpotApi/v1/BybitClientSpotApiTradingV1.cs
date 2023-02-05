using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Spot;
using CryptoExchange.Net;
using CryptoExchange.Net.CommonObjects;
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
using Bybit.Net.Interfaces.Clients.SpotApi.v1;
using Bybit.Net.Objects.Models.Spot.v1;

namespace Bybit.Net.Clients.SpotApi.v1
{
    /// <inheritdoc />
    public class BybitClientSpotApiTradingV1 : IBybitClientSpotApiTradingV1
    {
        private readonly BybitClientBaseSpotApi _baseClient;

        internal BybitClientSpotApiTradingV1(BybitClientBaseSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Place order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotOrderPlaced>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal? price = null, TimeInForce? timeInForce = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default)
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
            parameters.AddOptionalParameter("agentSource", _baseClient.ClientOptions.Referer);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitSpotOrderPlaced>(_baseClient.GetUrl("spot/v1/order"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (result)
                _baseClient.InvokeOrderPlaced(new OrderId { SourceObject = result.Data, Id = result.Data.Id.ToString(CultureInfo.InvariantCulture) });
            return result;
        }

        #endregion

        #region Get order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotOrderV1>> GetOrderAsync(long? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitSpotOrderV1>(_baseClient.GetUrl("spot/v1/order"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get open orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotOrderV1>>> GetOpenOrdersAsync(string? symbol = null, long? orderId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotOrderV1>>(_baseClient.GetUrl("spot/v1/open-orders"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get open orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotOrderV1>>> GetOrdersAsync(string? symbol = null, long? orderId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotOrderV1>>(_baseClient.GetUrl("spot/v1/history-orders"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
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

        #region Cancel MultipleOrders 
        /// <inheritdoc />
        public async Task<WebCallResult> CancelMultipleOrderAsync(string symbol, OrderSide? side = null, IEnumerable<OrderType>? orderTypes = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("side", side.HasValue ? JsonConvert.SerializeObject(side, new OrderSideConverter(false)) : null);
            parameters.AddOptionalParameter("orderTypes", orderTypes != null && orderTypes.Any() ? string.Join(",", orderTypes.Select(o => JsonConvert.SerializeObject(o, new OrderTypeConverter(false)))) : null);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("spot/order/batch-cancel"), HttpMethod.Delete, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }
        #endregion

        #region Get user trades

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotUserTradeV1>>> GetUserTradesAsync(string? symbol = null, long? fromId = null, long? toId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("fromId", fromId);
            parameters.AddOptionalParameter("toId", toId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitSpotUserTradeV1>>(_baseClient.GetUrl("spot/v1/myTrades"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Cross marging

        #region Place borrow order

        /// <inheritdoc />
        public async Task<WebCallResult<long>> PlaceBorrowOrderAsync(string asset, decimal quantity, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "currency", asset },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) }
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<long>(_baseClient.GetUrl("spot/v1/cross-margin/loan"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Place repay order

        /// <inheritdoc />
        public async Task<WebCallResult<long>> PlaceRepayOrderAsync(string asset, decimal quantity, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "currency", asset },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) }
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<long>(_baseClient.GetUrl("spot/v1/cross-margin/repay"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get borrow info

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitBorrowRecord>>> GetBorrowRecordsAsync(DateTime? startTime = null, DateTime? endTime = null, string? asset = null, BorrowStatus? status = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("currency", asset);
            parameters.AddOptionalParameter("status", EnumConverter.GetString(status));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitBorrowRecord>>(_baseClient.GetUrl("spot/v1/cross-margin/order"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get repayment history

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitRepayRecord>>> GetRepayRecordsAsync(DateTime? startTime = null, DateTime? endTime = null, string? asset = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("currency", asset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<IEnumerable<BybitRepayRecord>>(_baseClient.GetUrl("spot/v1/cross-margin/repay/history"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #endregion
    }
}
