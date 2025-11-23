using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using System.Linq;
using System.Text.Json;

namespace Bybit.Net.Clients.V5
{
    internal class BybitSocketClientApiConverter1 : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BybitExchange._serializerContext);

        protected override MessageEvaluator[] MessageEvaluators { get; } = [

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
                    new PropertyFieldReference("topic"),
                ],
                IdentifyMessageCallback = x => x.FieldValue("topic"),
            }
        ];
    }


    internal class BybitSocketClientApiConverter2 : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BybitExchange._serializerContext);

        protected override MessageEvaluator[] MessageEvaluators { get; } = [

            new MessageEvaluator {
                Priority = 1,
                Fields = [
                    new PropertyFieldReference("type") { Constraint = x => x.Equals("COMMAND_RESP", System.StringComparison.Ordinal) },
                    new PropertyFieldReference("successTopics") { Depth = 2, ArrayValues = true },
                    new PropertyFieldReference("failTopics") { Depth = 2, ArrayValues = true },
                ],
                IdentifyMessageCallback = x => {
                    var topics = x.FieldValue("successTopics").Split(',')?.ToList() ?? new();
                    topics.AddRange(x.FieldValue("failTopics")?.Split(',') ?? []);
                    return "resp" + string.Join("-", topics);
                },
            },

            new MessageEvaluator {
                Priority = 2,
                Fields = [
                    new PropertyFieldReference("topic"),
                ],
                IdentifyMessageCallback = x => x.FieldValue("topic"),
            },

            new MessageEvaluator {
                Priority = 3,
                Fields = [
                    new PropertyFieldReference("op") { Constraint = x => x.Equals("pong", System.StringComparison.Ordinal) },
                ],
                StaticIdentifier = "pong",
            }
        ];
    }

    internal class BybitSocketClientApiConverter3 : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BybitExchange._serializerContext);

        protected override MessageEvaluator[] MessageEvaluators { get; } = [

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
                    new PropertyFieldReference("op") { Constraint = x => x.Equals("pong", System.StringComparison.Ordinal) },
                ],
                StaticIdentifier = "pong",
            }
        ];
    }
}
