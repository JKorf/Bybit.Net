using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using System.Linq;
using System.Text.Json;

namespace Bybit.Net.Clients.MessageHandlers
{
    internal class BybitSocketMessageHandler1 : JsonSocketMessageHandler
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
                    new PropertyFieldReference("topic"),
                ],
                TypeIdentifierCallback = x => x.FieldValue("topic")!,
            }
        ];
    }
}
