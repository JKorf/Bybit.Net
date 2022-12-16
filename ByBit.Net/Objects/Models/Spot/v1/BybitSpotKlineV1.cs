using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot.v1
{
    /// <summary>
    /// Kline data
    /// </summary>
    [JsonConverter(typeof(ArrayConverter))]
    public class BybitSpotKlineV1
    {
        /// <summary>
        /// Candle open time
        /// </summary>
        [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
        public DateTime OpenTime { get; set; }
        /// <summary>
        /// Open price
        /// </summary>
        [ArrayProperty(1)]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        [ArrayProperty(2)]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        [ArrayProperty(3)]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Close price
        /// </summary>
        [ArrayProperty(4)]
        public decimal ClosePrice { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        [ArrayProperty(5)]
        public decimal Volume { get; set; }
        /// <summary>
        /// Close time
        /// </summary>
        [ArrayProperty(6), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CloseTime { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [ArrayProperty(7)]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// Number of trades
        /// </summary>
        [ArrayProperty(8)]
        public int Trades { get; set; }
        /// <summary>
        /// Take volume
        /// </summary>
        [ArrayProperty(9)]
        public decimal TakerVolume { get; set; }
        /// <summary>
        /// Taker quote volume
        /// </summary>
        [ArrayProperty(10)]
        public decimal TakerQuoteVolume { get; set; }
    }
}
