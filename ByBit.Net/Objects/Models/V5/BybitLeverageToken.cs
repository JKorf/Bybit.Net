using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.V5
{
    internal class BybitLeverageTokenWrapper
    {
        public IEnumerable<BybitLeverageToken> List { get; set; } = Array.Empty<BybitLeverageToken>();
    }

    /// <summary>
    /// Leverage token info
    /// </summary>
    public class BybitLeverageToken
    {
        /// <summary>
        /// Token abbreviation
        /// </summary>
        [JsonProperty("ltCoin")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Full name
        /// </summary>
        [JsonProperty("ltName")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Min order quantity
        /// </summary>
        [JsonProperty("minPurchase")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// Max order quantity
        /// </summary>
        [JsonProperty("maxPurchase")]
        public decimal MaxOrderQuantity { get; set; }
        /// <summary>
        /// Maximum purchase amount in a single day
        /// </summary>
        [JsonProperty("maxPurchaseDaily")]
        public decimal MaxDailyBuy { get; set; }
        /// <summary>
        /// Single Maximum redemption quantity
        /// </summary>
        [JsonProperty("maxRedeem")]
        public decimal MaxRedeem { get; set; }
        /// <summary>
        /// Single Minimum redemption quantity
        /// </summary>
        [JsonProperty("minRedeem")]
        public decimal MinRedeem { get; set; }
        /// <summary>
        /// Maximum redeem amount in a single day
        /// </summary>
        [JsonProperty("maxRedeemDaily")]
        public decimal MaxRedeemDaily { get; set; }
        /// <summary>
        /// Purchase fee rate
        /// </summary>
        [JsonProperty("purchaseFeeRate")]
        public decimal BuyFeeRate { get; set; }
        /// <summary>
        /// Redeem fee rate
        /// </summary>
        [JsonProperty("redeemFeeRate")]
        public decimal RedeemFeeRate { get; set; }
        /// <summary>
        /// Token status
        /// </summary>
        [JsonProperty("ltStatus"), JsonConverter(typeof(EnumConverter))]
        public LeverageTokenStatus Status { get; set; }
        /// <summary>
        /// Funding fee charged daily for users holding leveraged token
        /// </summary>
        [JsonProperty("fundFee")]
        public decimal FundingFee { get; set; }
        /// <summary>
        /// The time to charge funding fee
        /// </summary>
        [JsonProperty("fundFeeTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime FundingFeeTime { get; set; }
        /// <summary>
        /// Management fee rate
        /// </summary>
        [JsonProperty("manageFeeRate")]
        public decimal ManageFundingFee { get; set; }
        /// <summary>
        /// The time to charge management fee
        /// </summary>
        [JsonProperty("manageFeeTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime ManageFundingFeeTime { get; set; }
        /// <summary>
        /// Nominal asset value
        /// </summary>
        [JsonProperty("value")]
        public decimal Value { get; set; }
        /// <summary>
        /// 	Net value
        /// </summary>
        [JsonProperty("netValue")]
        public decimal NetValue { get; set; }
        /// <summary>
        /// Total purchase upper limit
        /// </summary>
        [JsonProperty("total")]
        public decimal Total { get; set; }
    }
}
