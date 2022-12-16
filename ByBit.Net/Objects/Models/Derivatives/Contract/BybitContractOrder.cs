using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.Derivatives;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Contract
{
    /// <summary>
    /// Contract Order info
    /// </summary>
    public class BybitContractOrder : BybitDerivativesOrder
    {
        /// <summary>
        /// Price of last fill
        /// </summary>
        [JsonProperty("lastPriceOnCreated")]
        public decimal? LastTradePrice { get; set; }

        /// <summary>
        /// Trigger direction. Mainly used in conditional order. 
        /// </summary>
        [JsonConverter(typeof(EnumConverter))]
        public TriggerDirection TriggerDirection { get; set; }

        /// <summary>
        /// Position idx, used to identify positions in different position modes
        /// </summary>
        [JsonProperty("positionIdx"), JsonConverter(typeof(PositionModeConverter))]
        public PositionMode? PositionMode { get; set; }
    }
}
