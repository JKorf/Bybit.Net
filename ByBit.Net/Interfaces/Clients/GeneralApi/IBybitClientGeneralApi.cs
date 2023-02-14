using CryptoExchange.Net.Interfaces;
using System;

namespace Bybit.Net.Interfaces.Clients.GeneralApi
{
    /// <summary>
    /// Bybit general API endpoints
    /// </summary>
    public interface IBybitClientGeneralApi : IRestApiClient, IDisposable
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