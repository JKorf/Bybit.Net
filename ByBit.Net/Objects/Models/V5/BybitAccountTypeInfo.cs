using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    internal class BybitAccountTypeInfoWrapper
    {
        public IEnumerable<BybitAccountTypeInfo> Accounts { get; set; } = Array.Empty<BybitAccountTypeInfo>();
    }

    /// <summary>
    /// Account type
    /// </summary>
    public class BybitAccountTypeInfo
    {
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("uid")]
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// Account types
        /// </summary>
        [JsonProperty("accountType")]
        public IEnumerable<string> AccountTypes { get; set; } = Array.Empty<string>();
    }
}
