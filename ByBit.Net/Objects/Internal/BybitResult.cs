using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitResult<T>
    {
        [JsonProperty("ret_code")]
        public int ReturnCode { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; } = string.Empty;
        [JsonProperty("ext_code")]
        public int? ExtCode { get; set; }
        [JsonProperty("ext_info")]
        public string? ExtInfo { get; set; }
        [JsonProperty("time_now"), JsonConverter(typeof(TimestampSecondsConverter))]
        public DateTime Timestamp { get; set; }
        public int? RateLimitStatus { get; set; }
        [JsonProperty("rate_limit_reset_ms"), JsonConverter(typeof(TimestampConverter))]
        public DateTime? RateLimitReset { get; set; }
        public int? RateLimit { get; set; }

        public T Result { get; set; }
    }
}
