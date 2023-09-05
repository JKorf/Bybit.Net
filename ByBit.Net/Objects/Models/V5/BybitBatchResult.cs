using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.V5
{
    public class BybitBatchResult
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("msg")]
        public string Message { get; set; } = string.Empty;
    }
    
    public class BybitBatchResult<T> : BybitBatchResult
    {
        public T Data { get; set; }
    }
}
