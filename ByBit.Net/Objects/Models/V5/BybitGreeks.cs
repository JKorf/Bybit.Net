namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Greeks
    /// </summary>
    public class BybitGreeks
    {
        /// <summary>
        /// Asset
        /// </summary>
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Delta
        /// </summary>
        public decimal TotalDelta { get; set; }
        /// <summary>
        /// Gamma
        /// </summary>
        public decimal TotalGamma { get; set; }
        /// <summary>
        /// Vega
        /// </summary>
        public decimal TotalVega { get; set; }
        /// <summary>
        /// Theta
        /// </summary>
        public decimal TotalTheta { get; set; }
    }
}
