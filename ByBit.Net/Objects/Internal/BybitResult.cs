using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitResult<T>
    {
        [JsonPropertyName("ret_code")]
        public int ReturnCode { get; set; }
        [JsonInclude, JsonPropertyName("retCode")]
        private int ReturnCodeInternal
        {
            get => ReturnCode;
            set => ReturnCode = value; 
        }

        [JsonPropertyName("ret_msg")]
        public string ReturnMessage { get; set; } = string.Empty;
        [JsonInclude, JsonPropertyName("retMsg")]
        private string ReturnMessageInternal
        {
            get => ReturnMessage;
            set => ReturnMessage = value;
        }

        [JsonPropertyName("ext_code")]
        public int? ExtCode { get; set; }
        [JsonPropertyName("ext_info")]
        public string? ExtInfo { get; set; }
        [JsonPropertyName("time_now"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        [JsonInclude, JsonPropertyName("time"), JsonConverter(typeof(DateTimeConverter))]
        private DateTime TimestampInternal
        {
            get => Timestamp;
            set => Timestamp = value;
        }

        [JsonPropertyName("rate_limit_status")]
        public int? RateLimitStatus { get; set; }
        [JsonPropertyName("rate_limit_reset_ms"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? RateLimitReset { get; set; }
        [JsonPropertyName("rate_limit")]
        public int? RateLimit { get; set; }

#pragma warning disable 8618
        [JsonPropertyName("result")]
        public T Result { get; set; }
#pragma warning restore
    }
}
