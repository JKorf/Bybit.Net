namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Order ids
    /// </summary>
    public class BybitOrderId
    {
        /// <summary>
        /// The order id
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        public string? ClientOrderId { get; set; }
    }
}
