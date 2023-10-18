using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.V5
{
    internal class BybitAccountTypeInfoWrapper
    {
        public IEnumerable<BybitAcountTypeInfo> Accounts { get; set; } = Array.Empty<BybitAcountTypeInfo>();
    }

    /// <summary>
    /// Account type
    /// </summary>
    public class BybitAcountTypeInfo
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
