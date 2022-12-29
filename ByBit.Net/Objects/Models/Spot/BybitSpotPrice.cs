namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Price info
    /// </summary>
    public class BybitSpotPrice
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Price
        /// </summary>
        /// <remarks> Useful for V3 as they send it in string format </remarks>
        public decimal Price { get; set; }
    }
}
