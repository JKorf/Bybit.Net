using CryptoExchange.Net.Converters.SystemTextJson;
using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    [SerializationModel]
    internal record BybitBorrowAssetWrapper
    {
        /// <summary>
        /// Vip asset list
        /// </summary>
        [JsonPropertyName("vipCoinList")]
        public BybitBorrowAsset[] VipAssetList { get; set; } = Array.Empty<BybitBorrowAsset>();
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializationModel]
    public record BybitBorrowAsset
    {
        /// <summary>
        /// Assets
        /// </summary>
        [JsonPropertyName("list")]
        public BybitBorrowAssetInfo[] Assets { get; set; } = Array.Empty<BybitBorrowAssetInfo>();
        /// <summary>
        /// Vip level
        /// </summary>
        [JsonPropertyName("vipLevel")]
        public AccountLevel AccountLevel { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializationModel]
    public record BybitBorrowAssetInfo
    {
        /// <summary>
        /// Borrowing accuracy
        /// </summary>
        [JsonPropertyName("borrowingAccuracy")]
        public int BorrowingAccuracy { get; set; }
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Flexible hourly interest rate
        /// </summary>
        [JsonPropertyName("flexibleHourlyInterestRate")]
        public decimal? FlexibleHourlyInterestRate { get; set; }
        /// <summary>
        /// Hourly interest rate14 d
        /// </summary>
        [JsonPropertyName("hourlyInterestRate14D")]
        public decimal? HourlyInterestRate14D { get; set; }
        /// <summary>
        /// Hourly interest rate180 d
        /// </summary>
        [JsonPropertyName("hourlyInterestRate180D")]
        public decimal? HourlyInterestRate180D { get; set; }
        /// <summary>
        /// Hourly interest rate30 d
        /// </summary>
        [JsonPropertyName("hourlyInterestRate30D")]
        public decimal? HourlyInterestRate30D { get; set; }
        /// <summary>
        /// Hourly interest rate7 d
        /// </summary>
        [JsonPropertyName("hourlyInterestRate7D")]
        public decimal? HourlyInterestRate7D { get; set; }
        /// <summary>
        /// Hourly interest rate90 d
        /// </summary>
        [JsonPropertyName("hourlyInterestRate90D")]
        public decimal? HourlyInterestRate90D { get; set; }
        /// <summary>
        /// Max borrowing quantity
        /// </summary>
        [JsonPropertyName("maxBorrowingAmount")]
        public decimal MaxBorrowingQuantity { get; set; }
        /// <summary>
        /// Min borrowing quantity
        /// </summary>
        [JsonPropertyName("minBorrowingAmount")]
        public decimal MinBorrowingQuantity { get; set; }
    }


}
