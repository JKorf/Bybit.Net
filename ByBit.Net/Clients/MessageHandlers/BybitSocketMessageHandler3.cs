using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using System.Text.Json;

namespace Bybit.Net.Clients.MessageHandlers
{
    internal class BybitSocketMessageHandler3 : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BybitExchange._serializerContext);

        protected override MessageTypeDefinition[] TypeEvaluators { get; } = [

            new MessageTypeDefinition {
                ForceIfFound = true,
                Fields = [
                    new PropertyFieldReference("req_id"),
                ],
                TypeIdentifierCallback = x => x.FieldValue("req_id")!,
            },

            new MessageTypeDefinition {
                ForceIfFound = true,
                Fields = [
                    new PropertyFieldReference("reqId"),
                ],
                TypeIdentifierCallback = x => x.FieldValue("reqId")!,
            },

            new MessageTypeDefinition {
                ForceIfFound = true,
                Fields = [
                    new PropertyFieldReference("topic"),
                ],
                TypeIdentifierCallback = x => x.FieldValue("topic")!,
            },

            new MessageTypeDefinition {
                Fields = [
                    new PropertyFieldReference("op").WithEqualConstraint("pong")
                ],
                StaticIdentifier = "pong",
            }
        ];
    }
}
