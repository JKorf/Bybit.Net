using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Leverage token record type
    /// </summary>
    public enum LeverageTokenRecordType
    {
        /// <summary>
        /// Purchase record
        /// </summary>
        [Map("1")]
        Purchase,
        /// <summary>
        /// Redeem record
        /// </summary>
        [Map("2")]
        Redeem
    }
}
