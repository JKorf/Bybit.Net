using Newtonsoft.Json;
using System;
using System.Diagnostics;

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

            long value;
            if (reader.Value is string strValue)
            {
                if(!long.TryParse(strValue, out value))
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss:fff} | Warning | Failed to parse exponential value {strValue}");
                    return default;
                }
            }
            else
                value = (long)reader.Value;
            return (decimal)(value/_div);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
