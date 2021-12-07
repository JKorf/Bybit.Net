using CryptoExchange.Net.Converters;
using CryptoExchange.Net.ExchangeInterfaces;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Spot
{
    /// <summary>
    /// Spot order info
    /// </summary>
    public class BybitSpotOrderPlaced: BybitSpotOrderBase, ICommonOrderId
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime TransactTime { get; set; }

        string ICommonOrderId.CommonId => Id.ToString();
    }
}
