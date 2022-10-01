using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Bybit.Net.Converters
{
    /// <summary>
    /// Converter for decimal in JSON deserialization
    /// </summary>
    public class DecimalJsonConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal));
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            if (string.IsNullOrWhiteSpace(reader.Value?.ToString()))
            {
                return decimal.Zero;
            }

            if (reader.TokenType == JsonToken.Float ||
                reader.TokenType == JsonToken.Integer ||
                reader.TokenType == JsonToken.String)
            {
                return decimal.Parse(reader.Value.ToString(), NumberStyles.Float, new CultureInfo("en-US"));
            }

            throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            var dec = (decimal)value;
            if (dec == decimal.MinValue)
            {
                writer.WriteValue(string.Empty);
            }
            else
            {
                writer.WriteValue(dec);
            }
        }
    }
}
