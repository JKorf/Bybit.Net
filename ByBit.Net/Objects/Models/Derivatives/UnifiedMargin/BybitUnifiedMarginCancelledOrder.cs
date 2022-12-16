using Bybit.Net.Enums;

namespace Bybit.Net.Objects.Models.Derivatives.UnifiedMargin
{
    /// <summary>
    /// Cancelled order info
    /// </summary>
    public class BybitUnifiedMarginCancelledOrder : BybitDerivativesOrderId
    {
        /// <summary>
        /// Derivatives products category. If category is not passed, then return ""For now, linear option are available
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
    }
}
