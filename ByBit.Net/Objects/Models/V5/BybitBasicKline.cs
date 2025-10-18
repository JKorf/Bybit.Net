using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters;
using System.Text.Json.Serialization;
using System;
using Bybit.Net.Converters;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Mark price kline info
    /// </summary>
    [JsonConverter(typeof(ArrayConverter<BybitBasicKline>))]
    [SerializationModel]
    public record BybitBasicKline
    {
        /// <summary>
        /// Kline open time
        /// </summary>
        [ArrayProperty(0)]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Open price
        /// </summary>
        [ArrayProperty(1), JsonConverter(typeof(DecimalConverter))]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        [ArrayProperty(2), JsonConverter(typeof(DecimalConverter))]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        [ArrayProperty(3), JsonConverter(typeof(DecimalConverter))]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Close price
        /// </summary>
        [ArrayProperty(4), JsonConverter(typeof(DecimalConverter))]
        public decimal ClosePrice { get; set; }
    }
}
