using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Oco trigger type
    /// </summary>
    public enum OcoTriggerType
    {
        /// <summary>
        /// Trigger by unknown
        /// </summary>
        [Map("OcoTriggerByUnknown")]
        OcoTriggerByUnknown,
        /// <summary>
        /// Trigger by take profit
        /// </summary>
        [Map("OcoTriggerTp")]
        OcoTriggerTp,
        /// <summary>
        /// Trigger by stop loss
        /// </summary>
        [Map("OcoTriggerBySl")]
        OcoTriggerBySl
    }
}
