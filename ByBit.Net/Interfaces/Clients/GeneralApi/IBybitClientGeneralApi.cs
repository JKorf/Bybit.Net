using CryptoExchange.Net.Interfaces;
using System;

namespace Bybit.Net.Interfaces.Clients.GeneralApi
{
    /// <summary>
    /// Bybit general API endpoints
    /// </summary>
    public interface IBybitClientGeneralApi : IDisposable
    {
        /// <summary>
        /// The factory for creating requests. Used for unit testing
        /// </summary>
        IRequestFactory RequestFactory { get; set; }

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