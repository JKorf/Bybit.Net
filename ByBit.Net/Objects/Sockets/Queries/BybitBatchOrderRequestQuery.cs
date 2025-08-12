using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using System.Collections.Generic;
using System.Linq;

namespace Bybit.Net.Objects.Sockets.Queries
{
    internal class BybitBatchOrderRequestQuery : Query<BybitBatchResult<BybitBatchOrderId>[]>
    {
        private readonly SocketApiClient _client;

        public BybitBatchOrderRequestQuery(SocketApiClient client, string op, Dictionary<string, string>? headers, params object[]? args) : 
            base(new BybitRequestQueryMessage { RequestId = ExchangeHelpers.NextId().ToString(), Header = headers, Operation = op, Args = args?.ToArray() }, true, 1)
        {
            _client = client;
            MessageMatcher = MessageMatcher.Create<BybitRequestQueryResponse<BybitList<BybitBatchOrderId>, BybitList<BybitBatchResult>>>(((BybitRequestQueryMessage)Request).RequestId, HandleMessage);
        }

        public CallResult<BybitBatchResult<BybitBatchOrderId>[]> HandleMessage(SocketConnection connection, DataEvent<BybitRequestQueryResponse<BybitList<BybitBatchOrderId>, BybitList<BybitBatchResult>>> message)
        {
            if (message.Data.ReturnCode != 0)
                return new CallResult<BybitBatchResult<BybitBatchOrderId>[]>(new ServerError(message.Data.ReturnCode, _client.GetErrorInfo(message.Data.ReturnCode, message.Data.ReturnMessage)), message.OriginalData);

            var resultList = new List<BybitBatchResult<BybitBatchOrderId>>();
            var resultItems = message.Data.Data!.List.ToArray();
            int index = 0;
            foreach (var item in message.Data.ExtendedInfo!.List)
            {
                var resultItem = resultItems[index++];
                resultList.Add(new BybitBatchResult<BybitBatchOrderId>
                {
                    Code = item.Code,
                    Message = item.Message,
                    Data = resultItem
                }); 
            }

            return message.ToCallResult(resultList.ToArray());
        }
    }
}
