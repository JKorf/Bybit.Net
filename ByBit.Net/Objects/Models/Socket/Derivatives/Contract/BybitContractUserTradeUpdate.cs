namespace Bybit.Net.Objects.Models.Socket.Derivatives.Contract
{
    /// <summary>
    /// Trade update
    /// </summary>
    public record BybitContractUserTradeUpdate : BybitDerivativesUserTradeUpdate
    {
        /// <summary>
        /// Quantity to close
        /// </summary>
        public decimal? ClosedSize { get; set; }
    }
}
