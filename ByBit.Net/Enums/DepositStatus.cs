using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Deposit status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<DepositStatus>))]
    public enum DepositStatus
    {
        /// <summary>
        /// ["<c>0</c>"] Unknown
        /// </summary>
        [Map("0")]
        Unknown,
        /// <summary>
        /// ["<c>1</c>"] Awaiting confirmations
        /// </summary>
        [Map("1")]
        ToBeConfirmed,
        /// <summary>
        /// ["<c>2</c>"] Processing
        /// </summary>
        [Map("2")]
        Processing,
        /// <summary>
        /// ["<c>3</c>"] Success
        /// </summary>
        [Map("3")]
        Success,
        /// <summary>
        /// ["<c>4</c>"] Failed
        /// </summary>
        [Map("4")]
        DepositFailed,
        /// <summary>
        /// ["<c>7</c>"] A blockchain rollback occurred after the deposit had already been credited.
        /// </summary>
        [Map("7")]
        RollbackProcessing,
        /// <summary>
        /// ["<c>70011</c>"] A blockchain rollback occurred, and the deposit has been reversed. The credited funds have been deducted, and no final credit remains.
        /// </summary>
        [Map("70011")]
        Rollback,
        /// <summary>
        /// ["<c>70012</c>"] Although a blockchain rollback occurred, the deposit remains valid. After review, it was determined that no clawback or deduction is required.
        /// </summary>
        [Map("70012")]
        SuccessAfterRollback,
        /// <summary>
        /// ["<c>70013</c>"] The deposit was initially credited, but the backend system failed to process the blockchain rollback automatically. The case is pending manual review.
        /// </summary>
        [Map("70013")]
        PendingAfterRollback,
        /// <summary>
        /// ["<c>10011</c>"] Pending to be credited to funding pool
        /// </summary>
        [Map("10011")]
        PendingCreditToFundingPool,
        /// <summary>
        /// ["<c>10012</c>"] Credited to funding pool successfully
        /// </summary>
        [Map("10012")]
        CreditedToFundingPool
    }
}
