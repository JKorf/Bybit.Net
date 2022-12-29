using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Derivatives
{
    /// <summary>
    /// Mark price klines entry
    /// </summary>
    [JsonConverter(typeof(ArrayConverter))]
    public class BybitUnifiedMarginMarkPriceKlineEntry
    {
        /// <summary>
        /// Start
        /// </summary>
        [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Start { get; set; }
        /// <summary>
        /// Open
        /// </summary>
        [ArrayProperty(1)]
        public decimal Open { get; set; }
        /// <summary>
        /// High
        /// </summary>
        [ArrayProperty(2)]
        public decimal High { get; set; }
        /// <summary>
        /// Low
        /// </summary>
        [ArrayProperty(3)]
        public decimal Low { get; set; }
        /// <summary>
        /// Close
        /// </summary>
        [ArrayProperty(4)]
        public decimal Close { get; set; }
    }
}
