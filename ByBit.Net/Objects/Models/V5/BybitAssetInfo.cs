using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    internal class BybitAssetInfoWrapper
    {
        public BybitAccountAssetInfo Spot { get; set; } = null!;
    }

    /// <summary>
    /// Account asset info
    /// </summary>
    public class BybitAccountAssetInfo
    {
        /// <summary>
        /// Account status
        /// </summary>
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// Assdet info
        /// </summary>
        public IEnumerable<BybitAssetInfo> Assets { get; set; } = Array.Empty<BybitAssetInfo>();
    }

    /// <summary>
    /// Asset info
    /// </summary>
    public class BybitAssetInfo
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Frozen amount
        /// </summary>
        public decimal Frozen { get; set; }
        /// <summary>
        /// Free amount
        /// </summary>
        public decimal Free { get; set; }
        /// <summary>
        /// Amount in withdrawing
        /// </summary>
        [JsonProperty("withdraw")]
        public decimal? Withdrawing { get; set; }
    }
}
