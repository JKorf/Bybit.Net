using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using System.Linq;
using System.Text.Json;

namespace Bybit.Net.Clients.MessageHandlers
{
    internal class BybitSocketMessageHandler3 : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BybitExchange._serializerContext);

        protected override MessageEvaluator[] TypeEvaluators { get; } = [

            new MessageEvaluator {
                Priority = 1,
                ForceIfFound = true,
                Fields = [
                    new PropertyFieldReference("req_id"),
                ],
                IdentifyMessageCallback = x => x.FieldValue("req_id"),
            },

            new MessageEvaluator {
                Priority = 2,
                ForceIfFound = true,
                Fields = [
                    new PropertyFieldReference("reqId"),
                ],
                IdentifyMessageCallback = x => x.FieldValue("reqId"),
            },

            new MessageEvaluator {
                Priority = 3,
                ForceIfFound = true,
                Fields = [
                    new PropertyFieldReference("topic"),
                ],
                IdentifyMessageCallback = x => x.FieldValue("topic"),
            },

            new MessageEvaluator {
                Priority = 4,
                Fields = [
                    new PropertyFieldReference("op") { Constraint = x => x!.Equals("pong", System.StringComparison.Ordinal) },
                ],
                StaticIdentifier = "pong",
            }
        ];
    }
}
