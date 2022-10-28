using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitResult<T>
    {
        [JsonProperty("ret_code")]
        public int ReturnCode { get; set; }
        [JsonProperty("retCode")]
        private int ReturnCodeInternal
        {
            get => ReturnCode;
            set => ReturnCode = value; 
        }

        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; } = string.Empty;
        [JsonProperty("retMsg")]
        private string ReturnMessageInternal
        {
            get => ReturnMessage;
            set => ReturnMessage = value;
        }

        [JsonProperty("ext_code")]
        public int? ExtCode { get; set; }
        [JsonProperty("ext_info")]
        public string? ExtInfo { get; set; }
        [JsonProperty("time_now"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
        private DateTime TimestampInternal
        {
            get => Timestamp;
            set => Timestamp = value;
        }

        [JsonProperty("rate_limit_status")]
        public int? RateLimitStatus { get; set; }
        [JsonProperty("rate_limit_reset_ms"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? RateLimitReset { get; set; }
        [JsonProperty("rate_limit")]
        public int? RateLimit { get; set; }

#pragma warning disable 8618
        public T Result { get; set; }
#pragma warning restore
    }
}
