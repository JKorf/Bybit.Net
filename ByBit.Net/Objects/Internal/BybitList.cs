using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Internal
{
    internal class BybitList<T>
    {
        [JsonPropertyName("list")]
        public T[] List { get; set; } = Array.Empty<T>();
    }
}
