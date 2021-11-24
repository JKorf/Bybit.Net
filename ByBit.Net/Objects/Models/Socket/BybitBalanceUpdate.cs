namespace Bybit.Net.Objects.Models.Socket
{
    /// <summary>
    /// Balance update
    /// </summary>
    public class BybitBalanceUpdate
    {
        /// <summary>
        /// Wallet balance
        /// </summary>
        public decimal WalletBalance { get; set; }
        /// <summary>
        /// Available balance = wallet balance - used margin
        /// </summary>
        public decimal AvailbleBalance { get; set; }
    }
}
