using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Sub account list
    /// </summary>
    public class BybitSubAccountList
    {
        /// <summary>
        /// Sub account ids
        /// </summary>
        [JsonProperty("sub_user_id")]
        public IEnumerable<long> SubAccountIds { get; set; } = Array.Empty<long>();
    }
}
