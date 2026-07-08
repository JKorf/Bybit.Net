using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Travel rule status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TravelRuleStatus>))]
    public enum TravelRuleStatus
    {
        /// <summary>
        /// ["<c>0</c>"] Review passed, proceed with subsequent flow
        /// </summary>
        [Map("0")]
        Approved,
        /// <summary>
        /// ["<c>1</c>"] Counterparty info required, re-submit questionnaire
        /// </summary>
        [Map("1")]
        CollectInfo,
        /// <summary>
        /// ["<c>2</c>"] Under review, poll the deposit query endpoint
        /// </summary>
        [Map("2")]
        Pending,
        /// <summary>
        /// ["<c>3</c>"] Rejected or failed (including cancelled)
        /// </summary>
        [Map("3")]
        Rejected,
    }
}
