using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Bybit.Net.Converters
{
    internal class DecimalToStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal) || objectType == typeof(decimal?));
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var dec = value as decimal?;
            if (dec.HasValue)
                writer.WriteValue(dec.Value.ToString(CultureInfo.InvariantCulture));
            else
                writer.WriteNull();
        }
    }
}
