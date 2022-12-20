using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Position update
    /// </summary>
    public class BybitUnifiedMarginPositionUpdate : BybitDerivativesPositionUpdate
    {
        /// <summary>
        /// Position margin
        /// </summary>
        public decimal PositionMargin { get; set; }

        /// <summary>
        /// Session UPL, for USDC only
        /// </summary>
        public decimal? SessionUPL { get; set; }

        /// <summary>
        /// Session RPL, for USDC only
        /// </summary>
        public decimal? SessionRPL { get; set; }

        /// <summary>
        /// Is isolated
        /// </summary>
        public bool IsIsolated { get; set; }

        /// <summary>
        /// Stop loss and take profit mode
        /// </summary>
        [JsonProperty("tpslMode"), JsonConverter(typeof(StopLossTakeProfitModeConverter))]
        public StopLossTakeProfitMode StopMode { get; set; }
    }
}
