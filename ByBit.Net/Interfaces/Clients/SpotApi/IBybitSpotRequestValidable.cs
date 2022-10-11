using Newtonsoft.Json.Linq;

namespace Bybit.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Base for spot websocket request/response processing
    /// </summary>
    public interface IBybitSpotRequestValidable
    {
        /// <summary>
        /// Validate response after subscription
        /// </summary>
        /// <param name="responseData"> Data </param>
        /// <param name="forcedExit"> Flag if exit without callback </param>
        /// <returns> Flag if data valid </returns>
        bool ValidateResponse(JToken responseData, ref bool forcedExit);

        /// <summary>
        /// Match response after subscription
        /// </summary>
        /// <param name="responseData"> Data </param>
        /// <returns> Flag if data matched </returns>
        bool MatchReponse(JToken responseData);
    }
}
