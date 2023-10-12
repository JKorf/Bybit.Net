using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Leverage token status
    /// </summary>
    public enum LeverageTokenStatus
    {
        /// <summary>
        /// Purchaseable and redeemable
        /// </summary>
        [Map("1")]
        YesPurchaseYesRedeem,
        /// <summary>
        /// Purchasable but not redeemable
        /// </summary>
        [Map("2")]
        YesPurchaseNoRedeem,
        /// <summary>
        /// Not purchasable but is redeemable
        /// </summary>
        [Map("3")]
        NoPurchaseYesRedeem,
        /// <summary>
        /// Not purchasable or redeemable
        /// </summary>
        [Map("4")]
        NoPurchaseNoRedeem,
        /// <summary>
        /// Adjusting position
        /// </summary>
        [Map("5")]
        AdjustingPosition
    }
}
