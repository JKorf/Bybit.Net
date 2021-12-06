using System;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Bybit general API endpoints
    /// </summary>
    public interface IBybitClientGeneralApi : IDisposable
    {
        /// <summary>
        /// Endpoints related to asset transfer
        /// </summary>
        IBybitClientGeneralApiTransfer TransferApi { get; }
    }
}