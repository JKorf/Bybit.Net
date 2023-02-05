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
using Bybit.Net.Interfaces.Clients.SpotApi.v3;
using Bybit.Net.Objects.Models.Spot.v3;
using Bybit.Net.Objects.Internal;

namespace Bybit.Net.Clients.SpotApi.v3
{
    /// <inheritdoc />
    public class BybitClientSpotApiTradingV3 : IBybitClientSpotApiTradingV3
    {
        private readonly BybitClientBaseSpotApi _baseClient;

        internal BybitClientSpotApiTradingV3(BybitClientBaseSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Place order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotOrderPlaced>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, decimal? price = null, TimeInForce? timeInForce = null, string? clientOrderId = null, int orderCategory = 0, decimal? triggerPrice = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) },
                { "orderType", JsonConvert.SerializeObject(type, new OrderTypeSpotConverter(false)) },
                { "orderQty", quantity.ToString(CultureInfo.InvariantCulture) }
            };
            parameters.AddOptionalParameter("orderPrice", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("timeInForce", timeInForce == null ? null : JsonConvert.SerializeObject(timeInForce, new TimeInForceSpotConverter(false)));
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderCategory", orderCategory.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("agentSource", _baseClient.ClientOptions.Referer);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitSpotOrderPlaced>(_baseClient.GetUrl("spot/v3/private/order"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (result)
                _baseClient.InvokeOrderPlaced(new OrderId { SourceObject = result.Data, Id = result.Data.Id.ToString(CultureInfo.InvariantCulture) });
            return result;
        }

        #endregion

        #region Get order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotOrderV3>> GetOrderAsync(long? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitSpotOrderV3>(_baseClient.GetUrl("spot/v3/private/order"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get open orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotOrderV3>>> GetOpenOrdersAsync(string? symbol = null, long? orderId = null, int? limit = null, int? orderCategory = 0, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("orderCategory", orderCategory ?? 0);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitSpotOrderV3>>(_baseClient.GetUrl("spot/v3/private/open-orders"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitSpotOrderV3>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitSpotOrderV3>>(Array.Empty<BybitSpotOrderV3>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Get open orders

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotOrderV3>>> GetOrdersAsync(string? symbol = null, long? orderId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitSpotOrderV3>>(_baseClient.GetUrl("spot/v3/private/history-orders"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);

            if (!result || result.Data == null)
                return result.As<IEnumerable<BybitSpotOrderV3>>(default);

            if (result.Data.List == null)
                return result.As<IEnumerable<BybitSpotOrderV3>>(Array.Empty<BybitSpotOrderV3>());

            return result.As(result.Data.List);
        }

        #endregion

        #region Cancel order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitSpotOrderPlaced>> CancelOrderAsync(long? orderId = null, string? clientOrderId = null, int? orderCategory = 0, long? receiveWindow = null, CancellationToken ct = default)
        {
            if (orderId == null && clientOrderId == null || orderId != null && clientOrderId != null)
                throw new ArgumentException($"1 of {nameof(orderId)} or {nameof(clientOrderId)} should be provided");

            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("orderLinkId", clientOrderId);
            parameters.AddOptionalParameter("orderCategory", orderCategory ?? 0);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitSpotOrderPlaced>(_baseClient.GetUrl("spot/v3/private/cancel-order"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (result)
                _baseClient.InvokeOrderCanceled(new OrderId { SourceObject = result.Data, Id = result.Data.Id.ToString(CultureInfo.InvariantCulture) });
            return result;
        }

        #endregion

        #region Cancel MultipleOrders 
        /// <inheritdoc />
        public async Task<WebCallResult> CancelMultipleOrderAsync(string symbol, OrderSide? side = null, IEnumerable<OrderType>? orderTypes = null, int? orderCategory = 0, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("side", side.HasValue ? JsonConvert.SerializeObject(side, new OrderSideConverter(false)) : null);
            parameters.AddOptionalParameter("orderTypes", orderTypes != null && orderTypes.Any() ? string.Join(",", orderTypes.Select(o => JsonConvert.SerializeObject(o, new OrderTypeConverter(false)))) : null);
            parameters.AddOptionalParameter("orderCategory", orderCategory ?? 0);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<object>(_baseClient.GetUrl("spot/v3/private/cancel-orders"), HttpMethod.Delete, ct, parameters, true).ConfigureAwait(false);
            return result.AsDataless();
        }
        #endregion

        #region Get user trades

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitSpotUserTradeV3>>> GetUserTradesAsync(string? symbol = null, long? fromId = null, long? toId = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("fromTradeId", fromId);
            parameters.AddOptionalParameter("toTradeId", toId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitSpotUserTradeV3>>(_baseClient.GetUrl("spot/v3/private/my-trades"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<IEnumerable<BybitSpotUserTradeV3>>(default);

            return result.As(result.Data.List);
        }

        #endregion

        #region Cross marging

        #region Place borrow order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitBorrowOrderV3>> PlaceBorrowOrderAsync(string asset, decimal quantity, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "coin", asset },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) }
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitBorrowOrderV3>(_baseClient.GetUrl("spot/v3/private/cross-margin-loan"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Place repay order

        /// <inheritdoc />
        public async Task<WebCallResult<BybitRepayOrderV3>> PlaceRepayOrderAsync(string asset, decimal quantity, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "coin", asset },
                { "qty", quantity.ToString(CultureInfo.InvariantCulture) }
            };
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.SendRequestAsync<BybitRepayOrderV3>(_baseClient.GetUrl("spot/v3/private/cross-margin-repay"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        #endregion

        #region Get borrow info

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitBorrowRecord>>> GetBorrowRecordsAsync(DateTime? startTime = null, DateTime? endTime = null, string? asset = null, BorrowStatus? status = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("status", EnumConverter.GetString(status));
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitBorrowRecord>>(_baseClient.GetUrl("spot/v3/private/cross-margin-orders"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result || result.Data == null)
            {
                return result.As<IEnumerable<BybitBorrowRecord>>(default);
            }

            return result.As(result.Data.List);
        }

        #endregion

        #region Get repayment history

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BybitRepayRecord>>> GetRepayRecordsAsync(DateTime? startTime = null, DateTime? endTime = null, string? asset = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("coin", asset);
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture) ?? _baseClient.ClientOptions.ReceiveWindow.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));

            var result = await _baseClient.SendRequestAsync<BybitList<BybitRepayRecord>>(_baseClient.GetUrl("spot/v3/private/cross-margin-repay-history"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
            if (!result || result.Data == null)
            {
                return result.As<IEnumerable<BybitRepayRecord>>(default);
            }

            return result.As(result.Data.List);
        }

        #endregion

        #endregion
    }
}
