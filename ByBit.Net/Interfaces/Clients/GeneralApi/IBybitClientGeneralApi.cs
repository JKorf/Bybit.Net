using System;

namespace Bybit.Net.Interfaces.Clients.GeneralApi
{
    /// <summary>
    /// Bybit general API endpoints
    /// </summary>
    public interface IBybitClientGeneralApi : IDisposable
    {
        /// <summary>
        /// Endpoints related to asset transfer
        /// </summary>
        IBybitClientGeneralApiTransfer Transfer { get; }
        /// <summary>
        /// Endpoint related to withrawing/depositing
        /// </summary>
        IBybitClientGeneralApiWithdrawDeposit WithdrawDeposit { get; }
    }
}