using CryptoExchange.Net.Interfaces;
using System;

namespace Bybit.Net.Interfaces.Clients.GeneralApi
{
    /// <summary>
    /// Bybit general API endpoints
    /// </summary>
    public interface IBybitRestClientGeneralApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to asset transfer
        /// </summary>
        IBybitRestClientGeneralApiTransfer Transfer { get; }
        /// <summary>
        /// Endpoint related to withrawing/depositing
        /// </summary>
        IBybitRestClientGeneralApiWithdrawDeposit WithdrawDeposit { get; }
    }
}