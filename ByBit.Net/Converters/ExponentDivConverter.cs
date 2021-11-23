using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Converters
{
    internal class ExponentDivConverter : JsonConverter
    {
        private double _div;

        public ExponentDivConverter(int exponent)
        {
            _div = Math.Pow(10, (exponent - 2));
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            var value = (long)reader.Value;
            return (decimal)(value/_div);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
