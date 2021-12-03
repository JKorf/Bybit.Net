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
        public decimal Price { get; set; }
    }
}
