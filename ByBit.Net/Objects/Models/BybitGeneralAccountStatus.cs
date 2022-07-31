using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models
{
    /// <summary>
    /// Account status
    /// </summary>
    public class BybitGeneralAccountStatus
    {
        /// <summary>
        /// Account status
        /// </summary>
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// Asset infos
        /// </summary>
        public IEnumerable<BybitGeneralAssetInfo> Assets { get; set; } = Array.Empty<BybitGeneralAssetInfo>();
    }

    /// <summary>
    /// Asset info
    /// </summary>
    public class BybitGeneralAssetInfo
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Free amount
        /// </summary>
        public decimal Free { get; set; }
        /// <summary>
        /// Frozen amount
        /// </summary>
        public decimal Frozen { get; set; }
        /// <summary>
        /// temporarily ""
        /// </summary>
        public string? Withdraw { get; set; }
    }
}
