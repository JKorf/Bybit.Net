using CryptoExchange.Net.Converters;
using System.Text.Json.Serialization;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Kline info
    /// </summary>
    [JsonConverter(typeof(ArrayConverter<BybitKline>))]
    [SerializationModel]
    public record BybitKline: BybitBasicKline
    {
        /// <summary>
        /// Volume
        /// </summary>
        [ArrayProperty(5), JsonConverter(typeof(DecimalConverter))]
        public decimal Volume { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [ArrayProperty(6), JsonConverter(typeof(DecimalConverter))]
        public decimal QuoteVolume { get; set; }
    }
}