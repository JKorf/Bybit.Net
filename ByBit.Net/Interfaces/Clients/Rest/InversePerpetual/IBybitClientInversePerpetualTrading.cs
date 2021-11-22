using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ByBit.Net.Clients.Rest.InversePerpetual
{
    /// <summary>
    /// Trad
    /// </summary>
    public interface IBybitClientInversePerpetualTrading
    {
        /// <summary>
        /// 1
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitCanceledOrder>>> CancelAllOrdersAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
       
        /// <summary>
        /// 2
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitOrder>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 3
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitOrder>> GetOpenOrderRealTimeAsync(string symbol, string? orderId = null, string? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 4
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="status"></param>
        /// <param name="direction"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitCursorPage<IEnumerable<BybitOrder>>>> GetOpenOrdersAsync(string symbol, OrderStatus? status = null, SearchDirection? direction = null, int? limit = null, string? cursor = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 5
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitOrder>>> GetOpenOrdersRealTimeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 6
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="newPrice"></param>
        /// <param name="newQuantity"></param> 
        /// <param name="takeProfitPrice"></param>
        /// <param name="stopLossPrice"></param>
        /// <param name="takeProfitTriggerType"></param>
        /// <param name="stopLossTriggerType"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitOrderId>> ModifyOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? newPrice = null, decimal? newQuantity = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, long? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// 7
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="side"></param>
        /// <param name="type"></param>
        /// <param name="quantity"></param>
        /// <param name="timeInForce"></param>
        /// <param name="price"></param>
        /// <param name="closeOnTrigger"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="takeProfitPrice"></param>
        /// <param name="stopLossPrice"></param>
        /// <param name="takeProfitTriggerType"></param>
        /// <param name="stopLossTriggerType"></param>
        /// <param name="reduceOnly"></param>
        /// <param name="receiveWindow"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<BybitOrder>> PlaceOrderAsync(string symbol, OrderSide side, OrderType type, decimal quantity, TimeInForce timeInForce, decimal? price = null, bool? closeOnTrigger = null, string? clientOrderId = null, decimal? takeProfitPrice = null, decimal? stopLossPrice = null, TriggerType? takeProfitTriggerType = null, TriggerType? stopLossTriggerType = null, bool? reduceOnly = null, long? receiveWindow = null, CancellationToken ct = default);
    }
}