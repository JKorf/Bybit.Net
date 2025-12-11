using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using System.Linq;
using System.Text.Json;

namespace Bybit.Net.Clients.MessageHandlers
{
    internal class BybitSocketMessageHandler2 : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BybitExchange._serializerContext);

        protected override MessageTypeDefinition[] TypeEvaluators { get; } = [

            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("type").WithEqualConstraint("COMMAND_RESP"),
                    new PropertyFieldReference("successTopics") { Depth = 2, ArrayValues = true },
                    new PropertyFieldReference("failTopics") { Depth = 2, ArrayValues = true },
                ],
                TypeIdentifierCallback = x => {
                    var topics = x.FieldValue("successTopics")!.Split(',')?.ToList() ?? new();
                    topics.AddRange(x.FieldValue("failTopics")?.Split(',') ?? []);
                    return "resp" + string.Join("-", topics);
                },
            },

            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("topic"),
                ],
                TypeIdentifierCallback = x => x.FieldValue("topic")!,
            },

            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("op").WithEqualConstraint("pong"),
                ],
                StaticIdentifier = "pong",
            }
        ];
    }
}
