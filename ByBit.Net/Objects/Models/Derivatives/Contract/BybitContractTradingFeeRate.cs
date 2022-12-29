namespace Bybit.Net.Objects.Models.Derivatives.Contract
{
    /// <summary>
    /// User trading fee rate
    /// </summary>
    public class BybitContractTradingFeeRate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Taker fee rate
        /// </summary>
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// Maker fee rate
        /// </summary>
        public decimal MakerFeeRate { get; set; }
    }
}
