using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Asset info
    /// </summary>
    public class BybitUserAssetInfos : BybitBaseResponse
    {
        /// <summary>
        /// Assets
        /// </summary>
        [JsonProperty("rows")]
        public IEnumerable<BybitUserAssetInfo> Assets { get; set; } = Array.Empty<BybitUserAssetInfo>();
    }

    /// <summary>
    /// Asset info for user
    /// </summary>
    public class BybitUserAssetInfo
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// asset
        /// </summary>
        [JsonProperty("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity remaining
        /// </summary>
        [JsonProperty("remainAmount")]
        public decimal? QuantityRemaining { get; set; }
        /// <summary>
        /// Networks
        /// </summary>
        [JsonProperty("chains")]
        public IEnumerable<BybitAssetNetworkInfo> Networks { get; set; } = new List<BybitAssetNetworkInfo>();
    }

    /// <summary>
    /// Asset network info
    /// </summary>
    public class BybitAssetNetworkInfo
    {
        /// <summary>
        /// Network type
        /// </summary>
        [JsonProperty("chainType")]
        public string NetworkType { get; set; } = string.Empty;
        /// <summary>
        /// Confirmations
        /// </summary>
        public int? Confirmation { get; set; }
        /// <summary>
        /// Withdrawal fee
        /// </summary>
        public decimal? WithdrawFee { get; set; }
        /// <summary>
        /// Min deposit quantity
        /// </summary>
        [JsonProperty("depositMin")]
        public decimal? MinDeposit { get; set; }
        /// <summary>
        /// Min withdrawal quantity
        /// </summary>
        [JsonProperty("withdrawMin")]
        public decimal? MinWithdraw { get; set; }
        /// <summary>
        /// Chain
        /// </summary>
        [JsonProperty("chain")]
        public string Network { get; set; } = string.Empty;
        /// <summary>
        /// Chain deposit enabled
        /// </summary>
        [JsonProperty("chainDeposit")]
        [JsonConverter(typeof(BoolConverter))]
        public bool? NetworkDeposit { get; set; }
        /// <summary>
        /// Chain withdraw enabled
        /// </summary>
        [JsonProperty("chainWithdraw")]
        [JsonConverter(typeof(BoolConverter))]
        public bool? NetworkWithdraw { get; set; }
        /// <summary>
        /// Minimal accuracy
        /// </summary>
        public int MinAccuracy { get; set; }
        /// <summary>
        /// Withdrawal percentage fee
        /// </summary>
        public decimal? WithdrawPercentageFee { get; set; }
    }
}
